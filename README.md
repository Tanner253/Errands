
---------------------------------
---------------------------------

# Project Errands
---------------------------------
//Coming soon
## We are deployed on Azure!

[project url here]

---------------------------------
## Web Application
This web application aims to solve the problems with food delivery services. Errands will be an application that connects two users (Errand runner, and Errand Requestor) to deliver a product. The Errand requestor can use distance preferences to view available runners in the area. A Requestor can view the profiles of each runner, and choose according to personal criteria of the user. Once the Requestor has chosen a runner, the Requestor can Text/Call an online runner. From there the requestor can ask the runner if they would be willing to go to point A and to the client point B for an agreed upon price. This application will not regulate chatrooms for the users, or prices for the users, that is between the Requestor and the Runner.

The web application consists of a frontend written in Razor views, HTML, CSS, The backend was written in C# using ASP.NET Core 2, Entity Framework Core, and the MVC framework.


---------------------------------

## Tools Used
Microsoft Visual Studio Community 2019 

- C#
- ASP.Net Core
- ASP Roles
- Identity
- Entity Framework
- MVC
- xUnit
- Bootstrap
- Azure
- Parallel Dots API

---------------------------------

## Recent Updates

#### V 1.4
Initial update to repo 9/18/19

---------------------------

## Getting Started

Clone this repository to your local machine.
```
$ git clone https://github.com/
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the root directory.
```
cd Errands/Errands.sln
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the /Errands/Errands/appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd Errands/Errands.sln
dotnet run
```
Unit testing is included in the Errands/FrontendTesting project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---------------------------------

## Usage
***[Provide some images of your app with brief description as title]***

### Overview of Recent Errands


### Creating a Errand


### Enriching a Errand


### Viewing Errand Details


---------------------------
## Data Flow (Frontend, Backend, REST API)
***[Add a clean and clear explanation of what the data flow is. Walk me through it.]***
![Data Flow Diagram](/assets/img/Flowchart.png)

---------------------------
## Data Model

### Overall Project Schema

---------------------------
## Model Properties and Requirements

### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| FirstName | string | YES |
| LastName | string | YES |
| PhoneNumber | string | YES |
| Picture | img jpeg/png | NO |
| Location | string | YES |
| RegisterDate | date/time object | YES |