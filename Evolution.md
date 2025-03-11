# Evolution of the project #

I thought it might be a good idea to write some lines on how this project evolved from a basic ASP.NET Core Web service into what it is now.

### The starting step ###
As the first step all I did was create an ASP.NET Core Web API using the basic template from **Visual Studio**. I chose `.NET 8.0` because at the time of creating the project that was the *LTS* version.
I set up the API without authentication for starters, however enabled HTTPS configuration and **Linux** container support in the form of a `Dockerfile`.
I also enabled OpenAPI and the use of controllers.

### Initial project setup and the first commit ###
After a tiny bit of research I came across a couple good tips on how to set up a .NET project from scratch. I added the `.editorconfig`, `Directory.Build.props`, and `Directory.Packages.props` files for my solution along with a `.gitignore` to only keep track of those files which are necessary.  
I also tested that the service starts properly and its endpoint is accessible when launched from within a container. Afterwards I was ready to make the initial commit to the [repository](https://github.com/tamasgazdik/BookStore).

### Enter PostgreSQL (and pgAdmin4) ###
I knew that eventually I would want my service to communicate with a database to provide information for its clients. I had some experience with Microsoft's **SQL Server**, however I wanted to try something new.
[PostgreSQL](https://www.postgresql.org/) is a widely used relational database in the industry, and it's also available on the [Docker Hub](https://hub.docker.com/).  
Now I just needed some graphical interface to get instant feedback that the changes which I apply from my service do get reflected in the database. [pgAdmin](https://www.pgadmin.org/) is the recommended administration tool for **PostgreSQL**, so I decided not to go down the rabbit whole of looking for the perfect tool.  
Both of them need some environment variable set to start properly. For now I decided to put these in their separate `.env` files. Obviously it's not a good idea to store credentials in files without any encryption, however since I just wanted to see whether they work, I decided that it would suffice.  
I also created a `postgres.docker-compose.yaml` file which is responsible for starting both containerized services together. The use of the shared network `postgres_network` would allow `pgadmin` to reach the database using the hostname `postgres` when connecting to it, while the volume `postgres_data` serves as a way to keep the data consistent through container lifecycles.

### Some more project arrangement ###
In order to adhere somewhat more to [Clean Architecture](https://www.csharp.com/article/a-guide-for-building-a-net-project-with-clean-architecture/) I decided to separate production code from tests by creating folders *Source* and *Test*.  
I renamed the **BookStore** project (essentially the starter ASP.NET Core Web API project) to **WebAPI**, and moved it into the appropriate *Source* folder. I also created projects **Domain**, **Application**, and **Infrastructure**.
In the future I plan to move every class, interface and whatnot to where it belongs, instead of just putting them all into the same assembly / folder.

### Setting up HTTPS and SSL manually ###
So far whenever I wanted to start the web service, I always did using the built-in launch profile *Container (Dockerfile)* provided by **Visual Studio**, which makes things super simple. Just with one click it does everything for us including compiling the solution, building the container, setting up HTTPS and SSL, etc. However, I am aware that in production environments **Visual Studio** is unlikely to be there to spoil us. Therefore I wanted to make sure that the service can be built and ran from the console line. And that's when the problems rose.  
Due to the changed folder structure of my project I had to adjust the `Dockerfile` to be able to find the necessary `.csproj` to use for the various phases inside. The build context used for **Docker** is also changed, but that's only relevant when building the image. After some trial and error I managed to bring the container image to build without failures and to bring the service inside to life. Only to find myself not being able to reach the service neither with HTTP or HTTPS protocols. The port mapping seemed fined, the service started inside the container, yet something was just not right.  
Disabling the use of HTTPS redirection in the `Program.cs` solved the former issue:
```csharp
// app.UseHttpsRedirection();
```
The latter one took some more time. After consulting with my favourite LLM advisor it seemed obvious that I need to set some environment variables for my ASP.NET Core Web service as well as configuring an SSL to be used in case of HTTPS. I created the appropriate `.env` file to be used with this content:
```
ASPNETCORE_URLS=https://+:8081;http://+:8080
ASPNETCORE_HTTPS_PORTS=8081
ASPNETCORE_HTTP_PORTS=8080
ASPNETCORE_Kestrel__Certificates__Default__Path=/https-certs/bookstorecert.pfx
ASPNETCORE_Kestrel__Certificates__Default__Password=BookStore
```
This file would later then be used during the container start command:
```
docker run --env-file .\Source\WebAPI\.env -Pd -v .\bookstorecert.pfx:/https-certs/bookstorecert.pfx bookstore:dev
```
It's also clear that I had to creat this `bookstorecert.pfx` file. That I did with the help of this dotnet command:
```
dotnet dev-certs https -ep bookstorecert.pfx -p "BookStore"
```
Here `-ep` stands for export path, while with the help of `-p` I could specify the password to be used on the command line.  
I know, I know... passwords typed into `.env` files and the command line... I'm planning on using secrets, just bear with me.  
Anyways these settings actually solved the issue. The only hiccup I'm left with is in connection with HTTPS redirection which I commented out previously. If I want it to work as expected, then I have to configure both the ASP.NET Core Web service and the docker port mappings so that they are identical.  
The problem description in short:
1. the client (from outside the container) sends its request on e.g. port 34322
2. Docker transfers this to the container's 8080 HTTP port thanks to port mapping given during container start
3. Redirection is used, therefore the service specifies that the request should be redirected to the HTTPS port, which is 8081
4. The client from outside the container tries to send the request to [host]:8081, however there is no service listening there, as the containerized service actually listens on [host]:34323 (or whatever else the configuration was).  
  
  This can be circumvented by using the same ports on both the host and the service within Docker, but I believe there should be a better solution that I just haven't found yet.
```
docker run --env-file .\Source\WebAPI\.env -p 8080:8080 -p 8081:8081 -d -v .\bookstorecert.pfx:/https-certs/bookstorecert.pfx bookstore:dev
```
Using this workaround actually makes the redirection work.  
Anyways I think mainly the last problem scope is what prompted me to start writing down the things I had to overcome during the development of this project so that should I encounter similar problems in the future I can always have a reference.