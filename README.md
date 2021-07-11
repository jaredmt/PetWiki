# PetWiki 
This is a website where you can get facts about cats and dogs. The website was built using C#/ASP.NET for the backend and REST API. Angular was used for the front end. 
This was built for fun but also to get more comfortable with ASP.NET/Angular. Most of the time spent on this project was messing with different ways to set up (MVC,SPA,single port, back/front end on separate ports,etc) 
Note: I also added a VUE version for the front end for fun.

## Data Sets
The data was grabbed from other API's. I wanted to start this project in a way that makes it easy for others to deploy.

## Run this app
Step 1: open command prompt in desired folder and type the commands:
```
	git clone https://github.com/jaredmt/PetWiki .
	dotnet run

```
Step 2: there are two options to run the front end:
Step 2a: run this project using angular:
```
	cd PetViews
	npm install
	ng serve --open

```
This should open http://localhost:4200 

Step 2b: run this project using Vue:
```
	cd pet-view-vue2
	npm install
	npm run serve
```
Go to http://localhost:8080

Note that both the backend and frontend must be running separately. 
