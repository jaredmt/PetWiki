using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PetWiki.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PetWiki.Controllers
{

    public interface IDogBreedsSingleton
    {
        public PetBreeds[] dogBreeds{get;}
    }

    public class DogBreedsSingleton : IDogBreedsSingleton
    {
        private IConfiguration _configuration;
        private PetBreeds[] _dogBreeds;
        public DogBreedsSingleton(IConfiguration configuration)
        {
            _configuration = configuration;
            this.getBreeds();
        }

        private void getBreeds()
        {
            string Url = _configuration.GetSection("DogAPI:breeds").Value;
            var client = new WebClient();
            dynamic dObj = JsonConvert.DeserializeObject<dynamic>(client.DownloadString(Url));
            IList<PetBreeds> dogBreedsList = new List<PetBreeds>();
            foreach (dynamic dog in dObj)
            {
                PetBreeds db = new PetBreeds();
                db.breed = dog.name.Value;
                if (dog.description != null)
                    db.description = dog.description.Value;
                else
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append( $"The {db.breed} breed has a lifespan of about {dog.life_span.Value}. ");
                    if (dog.bred_for != null)
                        sb.Append($"This dog is bred for {dog.bred_for.Value.ToLower()}. ");
                    if (dog.temperament != null)
                        sb.Append($"The temperament of {db.breed} can be described as: {dog.temperament.Value.ToLower()}.");
                    db.description = sb.ToString();
                }
                if (dog.image != null && dog.image.url != null)
                    db.imageURL = dog.image.url.Value;
                else
                    continue;
                dogBreedsList.Add(db);

            }
            this._dogBreeds = dogBreedsList.ToArray();
        }

        public PetBreeds[] dogBreeds { get { return _dogBreeds; } }
    }


    [EnableCors(CorsPolicies.myCorsPolicy)]
    [ApiController]
    [Route("api/[controller]")]
    public class DogBreedsController : Controller
    {
        private IConfiguration _configuration;
        private PetBreeds[] dogBreeds=null;
        public DogBreedsController(IConfiguration configuration,IDogBreedsSingleton dogBreedsSingleton)
        {
            _configuration = configuration;
            dogBreeds = dogBreedsSingleton.dogBreeds;
        }

        [HttpGet]
        public JsonResult Get()
        {
            Random rn = new Random();
            int randomIndex = rn.Next(0, dogBreeds.Length - 1);
            return new JsonResult(dogBreeds[randomIndex]);
        }
    }
}
