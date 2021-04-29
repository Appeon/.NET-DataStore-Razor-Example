# .NET DataStore - ASP.NET Core Example

This ASP.NET Core project makes use of the Razor page, and reference to a Class Library project, to perform CRUD operations and transaction management with DataStore from [DWNet.Data](https://www.nuget.org/packages/DWNet.Data/). 

##### Project Structure

The project contains an ASP.Net Core Web Application project. it is implemented using [Razor Pages](https://docs.microsoft.com/aspnet/core/razor-pages/?view=aspnetcore-3.1&tabs=visual-studio). 

The project is structured as follows.

```
|—— Appeon.DataStoreDemo.Web			Project implemented with Razor Pages
	|—— wwwroot							Includes the site js and css files
	|—— Models							Includes the model classes
	|—— Pages							Includes the Razor Pages
    	|-- SalesOrders					Include  the Razor Page for the SalesOrder model
|-- Appeon.DataStoreDemo.Service.SqlServer Project implemented with DataStore
    |-- Datacontext         			Includes the class that manages database connection to SQL 
    |-- Models							Includes the model classes
    |-- Services						Includes the service interfaces and implementations
```
##### Setting Up the Project

1. Dowload the project and save it to your local directory. 

2. Open the *DataStore-Asp.NetCore-Example.sln* solution in Visual Studio 2019 or another C# development IDE.

3. Download the SQL Server database backup file from [.NET-Project-Example-Database](https://github.com/Appeon/.NET-Project-Example-Database), and restore the database using the downloaded database backup file.

4. Open the configuration file *appsettings.json* in the *Appeon.DataStoreDemo.Web* project, modify the ConnectionStrings with the SQL Server database connection information. 

   ```json
   //Keep the database connection name as the default “AdventureWorks2012” or change it to a name you prefer to use, and change the Data Source, User ID, Password and Initial Catalog according to the actual settings
   "ConnectionStrings": { "AdventureWorks2012": "Data Source=127.0.0.1; Initial Catalog=AdventureWorks; Integrated Security=False; User ID=sa; Password=123456; Pooling=True; Min Pool Size=0; Max Pool Size=100; ApplicationIntent=ReadWrite" } 
   ```

5. In the ConfigureServices method of *Startup.cs*, go to the following line, and make sure the ConnectionString name is the same as the database connection name specified in step #4.

   ```C#
   //Note: Change "OrderContext" if you have changed the default DataContext file name; change the "AdventureWorks" if you have changed the database connection name in appsettings.json 
   services.AddDataContext<OrderContext>(m => m.UseSqlServer(Configuration["ConnectionStrings:AdventureWorks2012"])); 
   ```

