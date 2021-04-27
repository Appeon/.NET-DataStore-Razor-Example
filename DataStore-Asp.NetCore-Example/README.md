# SnapObjects-Asp.Net Core Example

This ASP.NET Core project makes use of the Razor page, and reference to a Class Library project, [SnapObjects-Example](https://github.com/Appeon/SnapObjects-Example), to perform CRUD operations and transaction management with SqlModelMapper from [SnapObjects.Data](https://www.nuget.org/packages/SnapObjects.Data/).

##### Project Structure

The project contains an ASP.Net Core Web Application project. it is implemented using [Razor Pages](https://docs.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-2.2&tabs=visual-studio). 

The project is structured as follows.

```
|—— Appeon.SnapObjectsDemo.Web			Project implemented with Razor Pages
	|—— wwwroot							Includes the site js and css files
	|—— Models							Includes the model classes
	|—— Pages							Includes the Razor Pages
    	|-- SalesOrders					Include  the Razor Page for the SalesOrder model
```
##### Setting Up the Project

1. Dowload the project and save it to your local directory. 

2. Download the Class Library (.NET Core) project [SnapObjects-Example](https://github.com/Appeon/SnapObjects-Example), and save it to the same folder as this project. 

3. Open the *SnapObjects-Asp.NetCore-Example.sln* solution in Visual Studio 2017 or another C# development IDE.

4. Add the *Appeon.SnapObjectsDemo.Service.SqlServer* project from the Class Library (.NET Core) project to *SnapObjects-Asp.NetCore-Example.sln*.

5. Add reference to *Appeon.SnapObjectsDemo.Service.SqlServer* in *Appeon.SnapObjectsDemo.Web*.

   Currently, this project can only work with the SQL Server database.  

6. Download the SQL Server database backup file from [.NET-Project-Example-Database](https://github.com/Appeon/.NET-Project-Example-Database), and restore the database using the downloaded database backup file.

7. Open the configuration file *appsettings.json* in the *Appeon.SnapObjectsDemo.Web* project, modify the ConnectionStrings with the SQL Server database connection information. 

   ```json
   //Keep the database connection name as the default “AdventureWorks” or change it to a name you prefer to use, and change the Data Source, User ID, Password and Initial Catalog according to the actual settings
   "ConnectionStrings": { "AdventureWorks": "Data Source=127.0.0.1; Initial Catalog=AdventureWorks; Integrated Security=False; User ID=sa; Password=123456; Pooling=True; Min Pool Size=0; Max Pool Size=100; ApplicationIntent=ReadWrite" } 
   ```

8. In the ConfigureServices method of *Startup.cs*, go to the following line, and make sure the ConnectionString name is the same as the database connection name specified in step #7.

   ```C#
   //Note: Change "OrderContext" if you have changed the default DataContext file name; change the "AdventureWorks" if you have changed the database connection name in appsettings.json 
   services.AddDataContext<OrderContext>(m => m.UseSqlServer(Configuration["ConnectionStrings:AdventureWorks"])); 
   ```

