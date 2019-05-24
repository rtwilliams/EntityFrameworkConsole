# EntityFrameworkConsole

The EntityFrameworkConsole application displays using the Repository pattern with Entity Framework.

The current implementation uses a geneic repository for database operations. Dependency Injection is used to pass the context (BandDb) to the repository(s). Therefore repository(s) act as a wrapper to the DbContext, and thus can return data in more useful forms.

To run, make sure the App.config BandDB connection string is targeting a valid SQL Server instance. 
