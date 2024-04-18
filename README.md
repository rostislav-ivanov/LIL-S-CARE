# LilsCareApp
Title:
Online store LIL’S CARE

Description:
What the application does?
The aim of this project was to create a brand’s online store. It is made to be effective for both modest product line оr wider range of items. The website is functional and user friendly. It supports different features for guests, members and admins:

Some key features: place orders, manage account and account details, edit and manage orders and manage products, inventory tracking, personal discounts, order history.

	Why did you use the technologies you used?
	What are some of the challenges you faced and features you hope to implement in the future?
Table of contents: (optional)

How it works:
Built with:
Test accounts and app settings:
Member
	Admin
	App settings
What it does: 
Guest visitors features
Members features
Admin features
Pages with features



How it works:

Text text text

Built with:
Microsoft.AspNetCore 8.0
Microsoft.EntityFrameworkCore 8.0
SendGrid 9.29
Microsoft SQL Server Express
MVC Areas with Multiple Layouts
Fontawesome
Bootstrap 5.0


Test accounts:
	Member: test@softuni.bg : softuni
	Admin: admin@mail.com : softuni-admin

Additionally: in appsettings.json set your connection string to MSSQL server, Google authentication, Facebook authentication and SendGrid keys.

{
  "ConnectionStrings": {
    "DefaultConnection": "YourDefaultConnection"
  },
  "AuthMessageSenderOptions": {
    "SendGridKey": "YourSendGridKey"
  },
  "GoogleAuth": {
    "ClientId": "YourClientId",
    "ClientSecret": "YourClientSecret"
  },
  "FacebookAuth": {
    "AppId": "YourAppId",
    "AppSecret": "YourAppSecret"
  }
}


What it does:
	Utilising the database the website provides informative and functional webpages for browsing products and navigating through user friendly shopping.The website can be used as a guest visitor, member or admin.
Guest visitors can:
navigate through shopping experience, informative pages, place order and check-out
shop / browse / filter products
have a cart: open a mini cart panel or load full cart page
Check-out / place order: proceed by filling in the required fields
see reviews 
see add to favourite
log in or sign up to become a member via creating an account or externally with Google or Facebook.

Logged members can also:
add / edit one review per product and attach photos to it.
have auto filled default details at check-out
manage their account details:
add / remove / edit / choose default own addresses and contact details
preview their own order history in a collapsable list. Even if some product details in the shop have changed (e.g. price, name or photo) members continue to see the products in their history as they were when the order was placed.
add / remove / preview favourite products
Admins can manage and edit:
Products:
filter / sort / order product list
add / delete / hide product cards
all product cards details: Name, descriptions, categories, price, etc.
track / edit inventory
add / rearrange photos
rearrange collapsable sections
duplicate / create a new existing product template with similar description and/or collapsable sections
Orders:
view / sort / filter orders list
change statuses of orders: fulfilled / unfulfilled / cancelled and paid / unpaid
add / remove products in placed orders
edit quantity of products in placed orders
add discount to placed orders

Pages with features:
Cart and checkout:
cart users can add / remove products and adjust the quantity of each.
show price of each item and Sub Total
free delivery if the order value is greater than a certain number
saves cart even after log in / sign up
autofill address
delivery methods: address and couriers options
notes: customers can write a note to their order
add / remove discount codes / coupons to order.
choose from account saved discounts / coupons



Shop page:
filter product cards by categories
pagination

Product page:
choose quantity
read descriptions in collapsable sections
show products rating and reviews (write a review once logged in)




Database Diagram LilsCareDb

![image](https://github.com/RostislavIv/LIL-S-CARE/assets/122882308/536b7a34-51d1-43d0-be23-94e387236e1c)






