# EntityFrameworkConsole

The EntityFrameworkConsole application displays using the Repository pattern with Entity Framework.

This current implementation could use refactoring regarding the Repository interfaces. There is redundant method calls within 
Repository interfaces. A generic Repository interface could be created and implemented to alieviate redundancy.

Again, Dependency Injection is used to pass the context (EntityDbContext) to Repositories. Therefore repositories act
as wrappers to the DbContext, and thus can return data in more useful forms.

To run, make sure the App.config BandDB connection string is targeting a valid SQL Server instance. 
