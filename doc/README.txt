Background

Although the spcification asked for the frontend to be Angular 4+ it got implemented with Asp.net MVC core. 
The development with the latest Angular version is beyond my current knowledge, although a big chunk of time was spent on experimenting 
with the different Angular features. I've decided that the limited time I had on this task was better to be spent on a proper architecture.
The solution follows the onion architecture, this allows better separation of concerns, by centralising the business logic of the application into the core
and externalising the dependant technologies into the outer layers.

https://jeffreypalermo.com/2008/07/the-onion-architecture-part-1/

Setup steps

1) Configure the database connection in the Dreamlines.Presentation.Api/appsettings.json
   Make sure that the database user has the right to create databases as the project should run the migration and initial data insert on startup.
2) Configure the startup projects in the solution so that both the Api and the MvcPortal project are started
3) Make sure that the listens on https://localhost:5002 as the address is hardcoded.

Areas of improvement

1) The bookings should be presented in a more user friendly way. At the minute all the bookins are loaded for a given sales unit, which can be a lot.
Either some sort of scrolling or more granular search should be implemented. 

2) The current implementation doesn't have much logging or error handling capabilities.
We should log any uncaught exceptions in the log table. We should also stick in an error handling middleware that logs the http request/responses.
This is required because the invalid request doesn't reach the aspnet pipeline.

3) Some test would be also beneficial.
