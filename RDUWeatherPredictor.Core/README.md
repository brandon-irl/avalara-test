# RDUWeatherPredictor.Core

## Synopsis
This project is a class library written in C# and targeting .NET Standard (v2.0). It contains all of the core business logic and infrastructure code for connecting to a data source containing weather data and using it to predict the weather. The purpose of this library is *not* to accurately predict the weather, but rather to demonstrate basic architectural patterns and S.O.L.I.D. engineering principles.

## Breakdown

### Data
This folder contains classes for getting information from the database. It includes an Entity Framework DB context as well as an asynchronous data repository framework for pulling information from that context.

### Models
This folder contains entities and POCOs. It does not contain any business logic, save for a JSON serialization method. This serialization method could have been it's own service.

### Services
This folder contains the interfaces and implementation for all business and infrastructure logic. This includes a repository manager and classes for generating predictions

Author: Brandon Alexander balexader.eng@gmail.com