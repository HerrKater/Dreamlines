
Setup steps:
1) Configure the database connection in the Dreamlines.Presentation.Api/appsettings.json
   Make sure that the database user has the right to create databases as the project should run the migration and initial data insert on startup.
2) Configure the startup projects in the solution so that both the Api and the MvcPortal project are started
3) Make sure that the listens on https://localhost:5002 as the address is hardcoded.
