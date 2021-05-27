# CurryLounge Web Application #
This web application is an Indian Food Order System that contains:
* Checkout System - Including Error and Success Pages.
* Login/Register system with Google Auth.
* Database to store users order and food items.
* Admin Page to remove or add items.
* Customer accounts have restricted access to some parts of the website.
* Menu with item order counter.
* Details page for the menu items.
* View/Edit order list.

## Before running application ##
You will need a PayPal Sandbox account and create a merchant account for a dummy transaction for PayPalFunctions.cs. The APIUsername, APIPassword and APISignature are required.
Create a fake username and password for the Admin account ot sign into when application runs in UserRoleActions.cs.
Create a database connection in your local machine to be included in the web.config.
Not essential is to create a Google Developer Console account and get the ClientId and key to add in Startup.Auth.cs.

