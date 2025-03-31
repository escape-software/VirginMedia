VirginMedia - ProductSales
--------------------------

Introduction
------------
The ProductSales solution was originally created to solve the Data spreadsheet technical test but later I designed it further to practice the use of different .NET technologies and techniques.

It was subsequently designed to support different types of client applications that need to work with the imported spreadsheet data such as MVC, Web API, Blazor Web App, Blazor Web Assembly, etc. However, I have removed all but the Blazor Web App client in this solution to make it simpler.

There are functionality in this solution, such as ASP.NET Identity classes and Identity DB context in the Blazor Web App and Infrastructure projects that is redundant for this test and can be safely ignored but remains due to time constraints.

The Application project contains a lot of CQRS classes to support the management of the support data (products, discounts, segments and countries) which has been included but is mostly redundant for this test.

Lastly authentication and authorization was previously included to control access to the different Blazor components but I have disabled or removed this functionality to make the test simpler.

Installation
------------
Extract all files from the zip file to a target folder. e.g. D:\Projects\ProductSales

Create a new empty ProductSales database on your chosen SQL Server database server.

Open ProductSales solution in Visual Studio using the same network account that was used to create the ProductSales DB.

In BlazorWebApp project modify the following config settings in appsettings.json:

Change ProductSalesConnection connection string to set the Data Source to use the correct DB Server name instance where the ProductSales database has been created.

Note: I have used Integrated Security=True to use a Windows domain account. The account that is used to run BlazorWebApp in Visual Studio should have permission to connect to and interact with the ProductSales database.

Change ImportFilePath to the full filepath of the ImportData folder in BlazorWebApp project. e.g. D:\Projects\ProductSales\ProductSales.BlazorWebApp\ImportData

Note: The ImportData folder needs sufficient file permissions to allow reading and writing files for the user account that is running Visual Studio.

Open Package Manager Console in Visual Studio.

In the Console, change the Default Project to ProductSales.Infrastructure

At the command prompt enter the Migrations command: update-database 20240719115455_Initial -context ProductSalesDbContext

Note: Alternatively you can run the following SQL script directly on the ProductSales database to create the required supporting ProductSales DB tables.
\ProductSales.Infrastructure\Scripts\ProductSalesCreation.sql

After Migrations has successfully updated the database (or the ProductSalesCreation script was executed successfully) run the following script on ProductSales DB to insert the default supporting data (countries, segments, discounts and products).
\ProductSales.Infrastructure\Scripts\ProductSalesInsertData.sql

Set BlazorWebApp as the startup project in Visual Studio.

The ProductSales solution should now be ready to run in Visual Studio.

Running ProductSales
--------------------
After completing the installation process debug run BlazorWebApp (startup project) in Visual Studio using the https launch profile.

Open a Browser window and enter the application URL of https://localhost:7228 to access the Blazor Web App.

Click on Import Data on the menu.

Click on Choose File button in Import Product Sales Data panel.

In the File Explorer dialog navigate to the solution root folder and select the Data spreadsheet by clicking on Open button.

The product sales data from the spreadsheet should appear in a grid on the Product Sales Items panel which includes valid data rows only.

The user can navigate through the grid pages using the grid pager controls.

The Invalid Product Sale Items panel shows a grid of imported data rows that has invalid data such as no product name.

Clicking on Save Product Sales button will save all the valid imported data rows into the database.

Note: The Enabled grid column was originally going to allow the user to manually select which imported data rows could be saved into the database by toggling the state of Enabled per grid row before selecting the Save Product Sales button. However this functionality has not been implemented due to time constraints.

Clicking on the Country menu option provides a simple example of how the supporting data such as countries could be managed by the user to add/edit countries.
