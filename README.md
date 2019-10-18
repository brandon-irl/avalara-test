# Avalara Coding Challenge

Using your favorite IDE or text editor, create a program which accomplishes the following:

* The program should be written in C#.
* The program should predict the weather at the RDU Airport, without making any external HTTP calls to do so. Weather data for the RDU Airport can be accessed here.
* The program should return the predicted temperature and precipitation for the current day (if a day was NOT passed in) or for the given day (if a day WAS passed in).
* The response should be in JSON format.
* The code should be well organized, documented, and unit tested.
* Bonus points if they account for climate change >.<

## The Program: RDUWeatherPredictor 🌧🌡
RDUWeatherPredictor is a console application built in C# and running on .NET Core (v2.2). It bundles all data and business logic into a portable executable. The purpose of this program is to demonstrate several different techniques and architectural principles that are important to app development. Therefore, some decisions seem over-architected in relation to the simplicity of the challenge. I attempt to explain these decisions through code comments and/or this documentation.

## Organization
The source code is split into three projects, united with a solution:
1. *RDUWeatherPredictor*: Console app
2. *RDUWeatherPredictor.Code*: Infrastructure and buisiness logic
3. *RDUWeatherPredictor.Tests*: XUnit test suite targeting RDUWeatherPredictor

For more information on each project, see the correlating READMEs.

This directory also includes precompiled binaries for this project for Windows 10 x64 machines under the `\binaries` directory.

## To run binary
1. Open a terminal app on a Windows 10 x64 machine (*NOTE: if on a different runtime, you must compile the code yourself*)
2. Navigate to `.\binaries\win-x64`
3. Execute a command (see examples in the `RDUWeatherPredictor`)

## To Run from code
For a full tutorial,  see .NET Core documentation
1. Ensure you have .NET Core 2.2 installed
2. Open a terminal app
3. Run `dotnet build` from this directory 
4. `cd .\RDUWeatherPredictor\`
5. `dotnet run`

## Why SQLite?
* Lightweight and portable (so code can be transferred easily and run without configuration).
* Ready-made EF provider for it
* Avalara uses SQL so it was an opportunity to demonstrate my knowledge of SQL and EF
* Even though the provided weather data is read-heavy and non-relational, something like LiteDB would have been a better fit, but I don't have any experience with it.

## Why .NET Core?
* It can be built for multiple runtimes, since this was not defined by requirements

## What does this project need?
* More error checking
* Better tests using a mocking library
* Better prediction logic
* Better client application

Author: Brandon Alexander balexader.eng@gmail.com