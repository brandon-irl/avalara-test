# RDUWeatherPredictor Console

## Synopsis
This project is a console application written in C# and targeting .NET Core (v2.2). It's purpose is to demonstrate a project making use of the modules in RDUWeatherPredictor.Core.

## Why a console app?
* Ease/speed of development
* Ease of use
* Challenge parameters didn't require anything more complicated

## USAGE
`RDUWeatherPredictor [--help][--version][--climate-change][--julian][--predictor] [\<args\>]`

*args* is in the format `day` `month` `year` with `day` being required;

## OPTIONS

  -j, --julian            Treat day input as the day of the year. Month and year will not be considered

  -c, --climate-change    Include chinese hoaxes in predictions

  -p, --predictor         (Default: dumb) Determines which prediction model is used

  --help                  Display this help screen.

  --version               Display version information.

## EXAMPLES
 Predict the weather for a day later this month
Argument correlates to the day of the month for the predicted date
`RDUWeatherPredictor 27`

 Predict the weather for a specific date:
`RDUWeatherPredictor 27 6 2019`

Predict the weather for a julian day:
`RDUWeatherPredictor 323 --julian`

Take into account climate change:
`RDUWeatherPredictor 1 1 2050 --climate-change`


### weather.db
This project contains a SQLite database that is included with the program files when built. It was manually generated from Entity Framework tools and populated with the `seed-db.sql` script.

### Note on performance:
* Results can take up to 2 seconds to appear. 99% of this time is due to time taken to connect to the SQLite db.
* This performance would be much faster with reused/persistent db connections (e.g. in a web app).

Author: Brandon Alexander balexader.eng@gmail.com