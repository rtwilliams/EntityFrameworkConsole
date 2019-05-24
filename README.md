# EntityFrameworkConsole

The EntityFrameworkConsole application uses the Repository pattern with Entity Framework for selecting, adding, updating, and deleting SQL data.

The current implementation uses a geneic repository for database operations. Dependency Injection is used to pass the DBContext (BandDb) to the repository. Therefore the repository act as a wrapper to the DbContext, and thus can return data in more useful forms.

### To run, make sure the App.config BandDB connection string is targeting a valid SQL Server instance. 
