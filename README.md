# GShop(GamingShop)

This project is an ASP.NET MVC application for selling gaming products. It includes user registration,shopping cart,orders and admin panel for managing products.

## Project Overview

### User Features

- **Registeration and Login**: Register or login for the site.
- **Home Page**: View products with category and subcategory filters.
- **Shopping Cart**: Add, remove, and manage items in the shopping cart then countinue with checkout.
- **User Information**: Edit personal information.
- **Order Management**: View your orders and track the order status.


### Admin Features

- **Product Management**: Add, edit, and delete products.
- **Category Management**: Add, edit, and delete product categories.
- **Subcategory Management**: Add, edit, and delete product subcategories.
- **Stock Management**: Monitor and update stock levels.
- **Order Management**: View and process orders(Update order status and payment).


### Admin and Default User Credentials

- **Admin Username**: `admin`
- **Admin Password**: `123`
- **Default User Username**: `kaan.aslan`
- **Default User Password**: `123`


### Project Structure

/src
* ApplicationCore
* DataAccess
* Web


### Migrations

/DataAccess
* Add-Migration InitialCreate -o Context/Migrations -c AppDbContext
* Update-Database -Context AppDbContext
* Add-Migration InitialCreate -o Context/Identity/Migrations -c AppIdentityDbContext
* Update-Database -Context AppIdentityDbContext

### Packages

/ApplicationCore
* Install-Package Microsoft.AspNetCore.Http.Features -v 5.0.17
* Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 8.0.6
* Install-Package Microsoft.AspNetCore.Mvc.ViewFeatures -v 2.2.0

/DataAccess
* Install-Package autofac -v 8.0.0
* Install-Package automapper -v 13.0.1
* Install-Package fluentvalidation -v 11.9.1
* Install-Package fluentvalidation.aspnetcore -v 11.3.0
* Install-Package microsoft.entityframeworkcore -v 8.0.6
* Install-Package microsoft.entityframeworkcore.tools -v 8.0.6
* Install-Package npgsql.entityframeworkcore.postgresql -v 8.0.4

/Web
* Install-Package autofac -v 8.0.0
* Install-Package autofac.extensions.dependencyinjection -v 9.0.0
* Install-Package automapper -v 13.0.1
* Install-Package fluentvalidation -v 11.9.1
* Install-Package fluentvalidation.aspnetcore -v 11.3.0
* Install-Package microsoft.entityframeworkcore -v 8.0.6
* Install-Package microsoft.entityframeworkcore.design -v 8.0.6
* Install-Package microsoft.entityframeworkcore.tools -v 8.0.6
* Install-Package Microsoft.VisualStudio.Web.CodeGeneration.Design -v 8.0.2
* Install-Package npgsql.entityframeworkcore.postgresql -v 8.0.4
