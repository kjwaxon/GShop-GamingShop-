# GShop(GamingShop)

This project is an ASP.NET MVC application for selling gaming products. It includes user registration,shopping cart,orders and admin panel for managing products.

## Project Overview

### User Features

- **Registration and Login**: Register or login for the site.
    
 ![Ekran görüntüsü 2024-06-25 211850](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/7d1faede-f19f-44ea-8cf1-5656fc7f726f)
  
 ![Ekran görüntüsü 2024-06-25 211956](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/626db213-6cb6-4bfd-9021-a40494b23d6c)
- **Home Page**: View products with category and subcategory filters.
  
  ![Ekran görüntüsü 2024-06-25 212050](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/8d59bb6d-2721-444d-98b6-f7834341913b)
  
  ![Ekran görüntüsü 2024-06-25 212113](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/85caecc4-9a21-4ee1-a3e6-62005062cfd0)
- **Shopping Cart**: Add, remove, and manage items in the shopping cart then countinue with checkout.
  
  ![Ekran görüntüsü 2024-06-25 212135](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/e004117d-7160-43bb-920b-2c69e1ea2773)
  
  ![Ekran görüntüsü 2024-06-25 212144](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/75eccfdc-ab22-4a6d-a178-214b46d1e123)
- **User Information**: Edit personal information.
  
  ![Ekran görüntüsü 2024-06-25 212203](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/bb6ee75e-d6a2-4c5c-8ee8-bef7addb3051)
- **Order Management**: View your orders and track the order status.
  
  ![Ekran görüntüsü 2024-06-25 212234](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/8dc4675f-ce03-4146-ab07-eca569333523)


### Admin Features

- **Product Management**: Add, edit, and delete products.
  
  ![Ekran görüntüsü 2024-06-25 212321](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/6b287cad-3f8b-4f4e-af6f-ab96e3286b28)
- **Category Management**: Add, edit, and delete product categories.

  ![Ekran görüntüsü 2024-06-25 212333](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/72db44e4-f19b-4079-9d22-75b78f0c3d52)
- **Subcategory Management**: Add, edit, and delete product subcategories.

  ![Ekran görüntüsü 2024-06-25 212350](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/a7608877-f45c-44d9-a1d6-11d7679b53e9)
- **Stock Management**: Monitor and update stock levels.

  ![Ekran görüntüsü 2024-06-25 212401](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/7bff3b4c-c466-416c-891e-70f42ea47d7b)
- **Order Management**: View and process orders(Update order status and payment).
- 
![Ekran görüntüsü 2024-06-25 221739](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/d74f2cbb-a836-46b0-a00c-c565a3dcdee9)

![Ekran görüntüsü 2024-06-25 221824](https://github.com/kjwaxon/GShop-GamingShop-/assets/103565536/3307d095-e543-4db5-aaf4-651af560c4f6)



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
