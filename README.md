# Walking With Style

# Documentation: Walking With Style E-commerce Platform

## Requirements Specification

The application Walking With Style is an e-commerce platform that's purpose is to let users show products, 
add them to a shopping cart and leave comments on the products. Requirements for this application is:
Possibility for users to browse through products and show detailed information of each product.
Functionality for users to add products to a shopping cart.
Opportunity for users to add a comment about the products and share their opinions and experiences with other users.
Functionality to make sure only admins can edit products.

At the time of this assignments deadline there are some functions that are not fully operational due to difficulties we have had with our database. Making modifications to the content of the database has been unsuccessful and trying to perform migrations resulted in Entity Framework thinking that we want to re-create the database each time a migration is made. Since there already is models and data in the database, the migrations stops itself before creating duplicates of the tables. The outcome of it is that we end up with half-done migrations that has to be manually removed and if possible, having to perform the action via SQL queries instead which isn't always the case. 

There are improvements to be made and had the project worked as well as we hoped, we would have added: 

Admin:  Added functionality to log in as admin and have access to advanced settings that customers doesn't have access too. The current build has an admin-dropdown with CRUD-operations for handling customers and product, however the menu is visible for everybody that visits the page and the CRUD-operations for the customers isn't functioning. 

Shoppingcart: We wanted to add a function where a number was displayed next to the shoppingcart-icon. With the limitations from the database and not accounting in that guest users also should be able to add products to the car, we were unable to implement this function. How we set up the relations in our database made it so each cart is connected to a CustomerId and us trying to disable this for testing meant that we had to make changes to the database which wasn't a possibility (as mentioned before).

## System architecture

This application is built with ASP.NET MVC-framework and uses Entity Framework Core for database management. 
The following is an overview of the system architecture:
Model: Representing the data structure for the application, including entities like products, comments and shopping carts. 
View: Handles the user interface and shows information to the users. Using Razor-syntax to mix HTML with C# code to render dynamic contents.
Controller: Handles user interaction and acts like middleware between the model and view. Contains measures to handle HTTP-requests to perform business logic.

The database is implemented with an SQL Server-database which stores information about products, comments, users and shopping carts. 
Entity Framework Core is used to interact with the database and perform CRUD-operations. 

## User documentation

### Product visablity through database input

To give the user (in this case teacher) an simple way of experience the functionality in the system we have included a txt file 
who can be used to insert products in the database. This file consists of example products and their attributes. To use this 
function, follow these simple steps (after opening the project and doing migrations + update database):
1. Find the file 'dataForProducts.txt' which is included on the first page of this project.
2. Open the file.
3. Copy it into the database (for example with SQL Server Management).
4. When the products are added they should be visible and available in the project.

### Browse products

Navigate to the product page to show a list of available products.
Click on a product to show detailed information about the product, including picture, name, description, price and how many are in stock.

### Add to shopping cart

In the product details page, pick how many of the products you want and click “Add to cart” to add it to the shopping cart.
Navigate to the shopping cart page to show and edit the products in your shopping cart.

### Leave a comment

On the detail page, fill the form below “add a comment” with your name and comment.
Press “Submit” to add your comment. The comment will stay on the detail site for other customers to see.

## Code based documentation

### Controllers

* HomeController.cs: Is responsible for the handling of basic navigation measures and page views within the WWStyle-application. It contains the following methods:
* Index(): Shows the applications main page and logs different messages that are errors, warnings and information to track the applications state.
* Privacy(): Returns a view that shows the application's privacy policy. 
* Error(): Shows an error-handling page and uses the ErrorViewModel to show relevant error information. The ResponseCache attribute is set to not cache in order to make sure that the error message is always contemporary.
* ProductController.cs: Regulates HTTP-requests for the product site, including measures to show detailed product details.
* AdminCustomerController.cs: Operates CRUD operations (create, read, update, delete) for customers in the application.
* AdminProductController.cs: Runs CRUD operations for products in the application. Such as add, list, edit and delete.
* CustomerController.cs: Maintaining operations related to users in the application. Including showing information, geting details, confirming deleting of users in the application.

  
### Context

* AspnetWwstyleContext.cs: Defines the database model and configuration for the Entity Framework Core context.
* ApplicationDbContext.cs: Purpose is to get data access in an ASP.NET application with identity functionality. It inherits from IdentityDbContext which includes authentication and user handling tables. The constructor receives settings for the DbContext.   

### Classes

* Product.cs: Represent a product entity with properties such as ProductId, ProductName, Description and Price.
* Comment.cs: Serves as a comment class with properties that are id for comments, products, users, text, date of creation and navigation properties for products and users.
* Customer.cs: Produces a customer with properties that includes id for customer, first name, last name, addresses, city, state, zipcode and country. There are also properties such as the customers phone number, email and a navigation property associated with users. There is a collection of orders and shopping carts. 
* Order.cs: Shows an order with properties like order id, customer id, total amount, date of ordering, status and navigation properties for an associated customer and a collection of order details that represents the details for each entry of the order.
* OrderDetail.cs: Enact as a detailed entry for an order. It includes fields for order id, belonging orders id, product id, quantity and price per unit. Additionally it contains navigation properties to the associated order and specific product that the order contains.
* ShoppingCart.cs: Represents a user's shopping cart and includes properties of cart id, customer id, product id and quantity. There are also navigation properties to the associated customer and product, which connects each shopping cart entry to a specific customer and product.
* AspNet~:  All of the AspNet classes follow along when creating the MVC project that includes authorization. They contain all the tables that handle the registering, logging in, user management and the authorization part on the website.
* Program.cs: Configures and builts the ASP.NET MVC web application with built in authorization from the Identity framework. 
* Imports necessary namespaces for Identity, Entity Framework Core and configuration.
* Creates an instance of WebApplication with help of WebApplicationBuilder.
* Configures services that are used in the application, this includes settings for database connections and uses Entity Framework Core to handle database operations.
* Configuration of authentication and authorization settings with the help of ASP.NET Identity, this includes requirements of confirmed userprofile upon logging in. 
* Addition of MVC services to handle web-API and views. 
* Configuration of the HTTP pipeline, this includes error handling, usage of HTTPS, static files, routing, authentication and authorization.
* Mapping of standard and customized control routes for the application. 
* Configuration of Razor Pages to support sites that are generated by the Razor view motor. 
* Starting the application by building and running it. 





