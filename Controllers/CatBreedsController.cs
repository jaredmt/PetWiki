using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Cors;
using PetWiki.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PetWiki.Controllers
{
    public interface ICatBreedsSingleton
    {
        public PetBreeds[] catBreeds { get; }
    }
    /**
     * the purpose to this class is to make a single api call to retreive all data on cat breeds
     * rather than doing this for every get request, it could just occur once and store in memory
     * https://docs.thecatapi.com/api-reference/breeds/breeds-list
     * -this has more information on the api
     */
    public class CatBreedsSingleton : ICatBreedsSingleton
    {
        private IConfiguration _configuration;
        private PetBreeds[] _catBreeds;
        public PetBreeds[] catBreeds {get {return _catBreeds;} }
        

        public CatBreedsSingleton(IConfiguration configuration)
        {
            _configuration = configuration;
            this.GetBreeds();
            Debug.Print("constructed");
        }
        private void GetBreeds()
        {
            //get list of all cat breeds (api doesn't allow just 1 random at a time)
            string authKey = _configuration.GetValue<string>("AuthKey");
            string url = _configuration.GetSection("CatAPI:breeds").Value;

            //var client = new HttpClient();
            //var method = HttpMethod.Head;
            //test: http://localhost:56862/api/catbreeds
            var client = new WebClient();
            string strJson = client.DownloadString(url);
            dynamic dobj = JsonConvert.DeserializeObject<dynamic>(strJson);
            IList<PetBreeds> catbreeds = new List<PetBreeds>();
            foreach (dynamic cat in dobj)
            {
                var catbreed = new PetBreeds();
                catbreed.breed = cat["name"].Value;
                catbreed.description = cat["description"].Value;
                if (cat.image != null && cat.image.url != null)
                    catbreed.imageURL = cat.image.url.Value;
                else
                    continue;//only add cats that contain images
                catbreeds.Add(catbreed);
                //Debug.Print(catbreed.breed);
            }

            this._catBreeds = catbreeds.ToArray();

        }
    }


    [EnableCors(CorsPolicies.myCorsPolicy)]
    [ApiController]
    [Route("api/[Controller]")]
    public class CatBreedsController : Controller
    {
        private IConfiguration _configuration;
        private PetBreeds[] catBreeds=null;
        public CatBreedsController(IConfiguration configuration,ICatBreedsSingleton catBreedsSingleton)
        {
            _configuration = configuration;

            catBreeds = catBreedsSingleton.catBreeds;
        }

        [HttpGet]
        public JsonResult Get()
        {
            //return a random cat breed
            Random r = new Random();
            int randomIndex = r.Next(0, this.catBreeds.Length - 1);
            return new JsonResult(this.catBreeds[randomIndex]);
        }

    }
}
