# ECOMMERCE APPLICATION

## Super Dogs For Sale
---
### We are deployed on Azure!

https://superpets.azurewebsites.net/

---
## Web Application
Hello and welcome to the wonderful world of super dogs.
We sell a range of breeds of Dogs.
We currently have 10 animals to select from.
We are hoping to implement accessories at some point.

---

## Tools Used
Microsoft Visual Studio Community 2019 

- C#
- ASP.Net Core
- Entity Framework
- MVC
- xUnit
- Bootstrap
- Azure

---

## Recent Updates


#### V 1.4
*Added Auth for Credit Card* 

---

## Getting Started

Clone this repository to your local machine.

```
$ git clone https://dev.azure.com/E-Commerce-Squad/_git/ECommerce-App
```
Once downloaded, you can either use the dotnet CLI utilities or Visual Studio 2017 (or greater) to build the web application. The solution file is located in the ECommerce_Application subdirectory at the root of the repository.
```
cd YourRepo/YourProject
dotnet build
```
The dotnet tools will automatically restore any NuGet dependencies. Before running the application, the provided code-first migration will need to be applied to the SQL server of your choice configured in the appsettings.json file. This requires the Microsoft.EntityFrameworkCore.Tools NuGet package and can be run from the NuGet Package Manager Console:
```
Update-Database
```
Once the database has been created, the application can be run. Options for running and debugging the application using IIS Express or Kestrel are provided within Visual Studio. From the command line, the following will start an instance of the Kestrel server to host the application:
```
cd YourRepo/YourProject
dotnet run
```
Unit testing is included in the ECommerceTesting/Testing project using the xUnit test framework. Tests have been provided for models, view models, controllers, and utility classes for the application.

---

## Usage
***[Provide some images of your app with brief description as title]***

### Overview Super Dogs Website
![Overview of Recent Posts](https://via.placeholder.com/500x250)

### Creating a Post
![Post Creation](https://via.placeholder.com/500x250)

### Enriching a Post
![Enriching Post](https://via.placeholder.com/500x250)

### Viewing Post Details
![Details of Post](https://via.placeholder.com/500x250)

---
## Data Flow (Frontend, Backend, REST API)
***[Add a clean and clear explanation of what the data flow is. Walk me through it.]***
![Data Flow Diagram](/assets/img/Flowchart.png)

---
## Data Model

### Overall Project Schema
***[Add a description of your DB schema. Explain the relationships to me.]***
![Database Schema](/assets/img/ERD.png)

---
## Model Properties and Requirements

### Super Dogs - Product

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Name | string | YES |
| SKU | string | YES |
| Price | decimal | NO |
| Description | string | NO |
| Breed | string | NO |
| Age | int | NO |
| SuperPower | string | NO |
| Color | string | YES |
| Image | string | YES |
| Quantity | int | YES |
| Category | string | YES |
| IsFeature | bool | YES |


### User

| Parameter | Type | Required |
| --- | --- | --- |
| ID  | int | YES |
| Name | string | YES |
| User Email | string | YES |

---

## Change Log
1.5: *Added checkout page* - 23 Aug 2020  
1.4: *Added admin page* - 19 Aug 2020  
1.3: *Allow user to see individual product details* - 19 Aug 2020  
1.2: *Products displayed on home page* - 18 Aug 2020
1.1: *Added ability for user to login and register* - 12 Aug 2020

---

## Authors
Bryant Davis & Lami Beach

---

### Resources:

Bootstrap for design and layout: https://getbootstrap.com/

Bootstrap hover functionality: https://miketricking.github.io/bootstrap-image-hover/

Dog Pictures: https://www.pexels.com/search/dog/

BatSuperDog: https://longreads.com/2018/03/22/my-dog-is-10-3-supermutt/ (Krista Stevens)

RobinSuperDog: https://petcentral.chewy.com/your-dog-will-save-the-day-with-these-halloween-superhero-costumes/ (Pet Central)

PetCostumedDog: https://www.familyminded.com/s/pet-costumes-for-your-furry-friend-311d952248e04966 (Jessie Fetterling)

BootstrapCheckOutTheme: https://mdbootstrap.com/education/bootstrap/ (MDBootstrap.com) 
