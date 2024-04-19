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
	- Guest visitors features
	- Members features
	- Admin features
	- Pages with features

## How it works:

Text text text

## Built with:
- Microsoft.AspNetCore 8.0
- Microsoft.EntityFrameworkCore 8.0
- SendGrid 9.29
- Microsoft SQL Server Express
- MVC Areas with Multiple Layouts
- Fontawesome
- Bootstrap 5.0


## Test accounts:
- Member - UserName: test@softuni.bg, Password: softuni
- Admin - UserName: admin@mail.com, Password: softuni-admin

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

- ### Guest visitors can:
	- [x] navigate through shopping experience, informative pages, place order and check-out
	- [x] shop / browse / filter products
	- [x] have a cart: open a mini cart panel or load full cart page
	- [x] check-out / place order: proceed by filling in the required fields
	- [x] see reviews 
	- [x] log in or sign up to become a member via creating an account or externally with Google or Facebook.
	- [x] after registration receive a discount code

- ### Logged members can also:
	- [x] add / edit one review per product and attach photos to it.
	- [x] have auto filled default details at check-out
	- [x] manage their account details:
	- [x] add / remove / edit / choose default own addresses and contact details
	- [x] preview their own order history in a collapsable list. Even if some product details in the shop have changed (e.g. price, name or photo) members continue to see the products in their history as they were when the order was placed.
	- [x] add / remove / preview favourite products

- ### Admins can manage and edit:
	- ### Products:
		- [x] filter / sort / order product list
		- [x] add / delete / hide product cards
		- [x] all product cards details: Name, descriptions, categories, price, etc.
		- [x] track / edit inventory
		- [x] add / rearrange photos
		- [x] rearrange collapsable sections
		- [x] duplicate existing / create a new product template with similar description and/or collapsable sections

	- ### Orders:
		- [x] view / sort / filter orders list
		- [x] change statuses of orders: fulfilled / unfulfilled / cancelled and paid / unpaid
		- [x] add / remove products in placed orders
		- [x] edit quantity of products in placed orders
		- [x] add discount to placed orders

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

	- ### Shop page:
		- [x] filter product cards by categories
		- [x] pagination

	- ### Product page:
		- [x] choose quantity
		- [x] read descriptions in collapsable sections
		- [x] show products rating and reviews (write a review once logged in)




Database Diagram LilsCareDb

![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/536b7a34-51d1-43d0-be23-94e387236e1c)






