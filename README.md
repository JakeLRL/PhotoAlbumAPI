# PhotoAlbumAPI Instructions

Design and create a RESTful API in ASP.NET Core. The API should call, combine, and return these 2 API endpoints into a single HTTP response. The response should show the combined collection so that each Album contains a collection of its Photos. (i.e. photo.albumId == album.Id)
- http://jsonplaceholder.typicode.com/photos
- http://jsonplaceholder.typicode.com/albums
Your API should consist of 2 operations; one to return all the data from the above endpoints, and one to return data relating to a single User Id. The design of the endpoints and schema of your API is up to you, but you must include all the data from the provided endpoints. You can find documentation for the endpoints here: http://jsonplaceholder.typicode.com/guide/ 
Requirements **I misread the instructions so implemented 3 endpoints**
- Your API should be written in C# 
- You should use either .NET Core 3.1 or .NET 5
- You may use any IDE, but you must supply a valid .sln file 
- Your solution must compile and run in a single step 
- Avoid including artefacts from your local build, e.g. NuGet packages, bin/obj folders
- You should upload your code to GitHub, or supply a download link to a ZIP file from OneDrive

## How to call the API

To get all PhotoAlbum items when running locally from IIS, call the endpoint:
``
https://localhost:44314/api/photoalbum
``

To get all PhotoAlbum items by userId {id}, call the endpoint:
``
https://localhost:44314/api/photoalbum/userId/{id}
``

To get a single PhotoAlbum item by an albumId {id}, call the endpoint:
``
https://localhost:44314/api/photoalbum/albumId/{id}
``

## TODO: 

- Would ideally have some logging added to the solution, but skipped due to time constraints
- Current testing only covers happy paths
- Would add some acceptance tests for deploying the solution, but as it is a hassle to run locally they are skipped

