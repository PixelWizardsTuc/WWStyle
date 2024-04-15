# Walking With Style

# KRAV
Fokuser på att få de grundläggande funktionalitet i uppgiften mer än på hur många sidor blir det i slutet. 
Att ni har ett admin och en vanlig användare. Kundregister där alla kan se lista av kunder medan admin kan 
redigera och lägga till kund. En produktkatalog med minst ett bild, beskrivning och pris, varukorg, orderhisprik. 
Bara admin kan hantera produkter. En kommentarsfunktion för produker för inloggad användare. 
Jag forsökte korta ner de viktiga delar, hoppas att det hjälper.

# Documentation: Walking With Style E-commerce Platform

## Requirements Specification

The application Walking With Style is an e-commerce platform that's purpose is to let users show products, add them to a shopping cart and leave comments on the products. Requirements for this application is:
Possibility for users to browse through products and show detailed information of each product.
Functionality for users to add products to a shopping cart.
Opportunity for users to add a comment about the products and share their opinions and experiences with other users.
Functionality to make sure only admins can edit products.

## System architecture
This application is built with ASP.NET MVC-framework and uses Entity Framework Core for database management. The following is an overview of the system architecture:
Model: Representing the data structure for the application, including entities like products, comments and shopping carts. 
View: Handles the user interface and shows information to the users. Using Razor-syntax to mix HTML with C# code to render dynamic contents.
Controller: Handles user interaction and acts like middleware between the model and view. Contains measures to handle HTTP-requests to perform business logic.

The database is implemented with an SQL Server-database which stores information about products, comments and shopping carts. Entity Framework Core is used to interact with the database and perform CRUD-operations. 

## User documentation

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
* ProductController.cs: Handles HTTP-requests for the product site, including measures to show detailed product details.

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
*Configures services that are used in the application, this includes settings for database connections and uses Entity Framework Core to handle database operations.
*Configuration of authentication and authorization settings with the help of ASP.NET Identity, this includes requirements of confirmed userprofile upon logging in. 
* Addition of MVC services to handle web-API and views. 
* Configuration of the HTTP pipeline, this includes error handling, usage of HTTPS, static files, routing, authentication and authorization.
* Mapping of standard and customized control routes for the application. 
* Configuration of Razor Pages to support sites that are generated by the Razor view motor. 
* Starting the application by building and running it. 





