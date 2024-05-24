# LilsCareApp 


Online store

## Description:
The aim of the project was to create a brand’s online store. It is made to be effective for both modest product line оr wider range of items. The website is functional and user friendly. It supports different features for guests, members and admins.

### Some key features:
place orders, manage account and account details, edit and manage orders and manage products, inventory tracking, personal discounts, order history.

## Table of contents:

- [How it works:](https://github.com/RostislavIv/LIL-S-CARE/tree/master?tab=readme-ov-file#how-it-works)
- [Built with:](https://github.com/RostislavIv/LIL-S-CARE/tree/master?tab=readme-ov-file#built-with)
- [Test accounts and app settings:](https://github.com/RostislavIv/LIL-S-CARE/tree/master?tab=readme-ov-file#test-accounts)
	- Member
	- Admin
	- App settings
- [What it does:](https://github.com/RostislavIv/LIL-S-CARE/tree/master?tab=readme-ov-file#what-it-does)
	- Pages with features
  	- Guest visitors features
	- Members features
	- Admin features

## Built with:
- Microsoft.AspNetCore 8.0
- Microsoft.EntityFrameworkCore 8.0
- SendGrid
- NUnit
- Moq
- MVC Areas with Multiple Layouts
- Microsoft SQL Server Express
- Fontawesome
- Bootstrap 5.0

## Test accounts and application settings:
- Member - UserName: test@softuni.bg, Password: softuni
- Admin - UserName: admin@mail.com, Password: lilia-admin-app

Before running the application, ensure you have the necessary configurations in the appsettings.json file. Replace every occurrence of "Your" with the actual value: connection string to MSSQL server, Google authentication, Facebook authentication, SendGrid keys and email.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "YourDefaultConnection"
  },
  "AuthMessageSenderOptions": {
    "SendGridKey": "YourSendGridKey"
  },
  "EmailAdministrator": "YourEmailFromSendGrid",
  "GoogleAuth": {
    "ClientId": "YourClientId",
    "ClientSecret": "YourClientSecret"
  },
  "FacebookAuth": {
    "AppId": "YourAppId",
    "AppSecret": "YourAppSecret"
  }
}
```

## What it does:
Utilising the database the website provides informative and functional webpages for browsing products and navigating through user friendly shopping.The website can be used as a guest visitor, member or admin.

- ### Pages with features:

	- ### Cart and checkout:
		- [x] cart users can add / remove products and adjust the quantity of each
		- [x] show price of each item and Sub Total
		- [x] free delivery if the order value is greater than a certain number
		- [x] saves cart even after log in / sign up
		- [x] autofill address
		- [x] delivery methods: address and couriers options
		- [x] notes: customers can write a note to their order
		- [x] add / remove discount codes / coupons to order
		- [x] choose from account saved discounts / coupons
  		- [x] show summary of order page
            
          ![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/f6312756-c2e5-4143-b166-955d64f9b369)
        
  		- [x] and send automatic order conirmaion email wih order summary
          
          ![11](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/7bab2437-8113-4e5e-897f-3da7b72d7917)
  

	- ### Products page:
		- [x] filter product cards by categories
		- [x] pagination

	- ### Product details page:
		- [x] choose quantity
		- [x] read descriptions in collapsable sections
		- [x] show products rating and reviews (write a review once logged in)
        
        ![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/dfbb5be8-36de-4af3-9122-0946be7263c6)

- ### Guest visitors can:
	- [x] navigate through shopping experience, informative pages, place order and check-out
	- [x] shop / browse / filter products
	- [x] have a cart: open a mini cart panel or load full cart page
	- [x] see reviews 
  
  ![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/a4978b83-34ce-4f6e-b6ae-e6dd1d22d6bd)


	- [x] check-out / place order: proceed by filling in the required fields
 	- [x] after registration receive a discount code
  
  ![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/9cc5a632-e4db-4390-81b0-750a0fc5e6e0)
  

	- [x] log in or sign up to become a member via creating an account or externally with Google or Facebook.
 
  ![2](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/a399509f-7eca-413f-8cd5-cb8e6f965fda)


- ### Logged members can also:
	- [x] add / edit one review per product and attach photos to it
       
        ![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/e59a7f94-88c6-447d-881a-8229c369da45)
       
        ![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/0e0855e3-637d-40f0-9dea-1b3be732047c)


	- [x] have auto filled default details at check-out
	- [x] manage their account details:
 		- [x] edit account details
		- [x] add / remove / preview favourite products
		- [x] add / remove / edit / choose default own addresses and contact details
  
        ![13](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/8773fad6-468b-4f0e-bf9d-1f462e5e3d22)

		- [x] preview their own order history in a collapsable list. Even if some product details in the shop have changed (e.g. price, name or photo) members continue to see the products in their history as they were when the order was placed.

        ![12](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/fad1e5ab-5627-4afa-983c-3bfaab91b7c3)


- ### Admins can manage and edit:
	- ### Products:
		- [x] filter / sort / order product list
		- [x] add / delete / edit visibility in shop of product cards
		- [x] track / edit inventory
		- [x] duplicate existing / create a new product template with similar description and/or collapsable sections

        ![14](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/4e313620-436c-4faa-9729-0efbfa697437)

		- [x] edit all product cards details: Name, descriptions, categories, price, etc.
		- [x] add / rearrange photos
		- [x] rearrange collapsable sections

        ![15](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/eaf37c73-de0b-421b-9eca-0f1b43d66cc0)

	- ### Orders:
		- [x] view / sort / filter orders list
		- [x] change statuses of orders: fulfilled / unfulfilled / cancelled / recieved / returned and paid / unpaid

        ![16](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/1be0ed4d-fc22-45f9-bf35-8ea29e07b3b9)

		- [x] add / remove products in placed orders
		- [x] edit quantity of products in placed orders
		- [x] add discount to placed orders

        ![17](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/f8c534d7-3c9f-4b09-a316-1af468c25d71)


Database Diagram LilsCareDb

![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/536b7a34-51d1-43d0-be23-94e387236e1c)












