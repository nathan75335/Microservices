# ServiceName
IdentityService

# General

The service provides logic for Authentication of user in the application.when the user want to use the application he will be redirected
to a page where he will provide his credential then the service will provide a token for his authenctication.This service works
with Identity Server and Jwt Bearer Token.

# AuthorizeController Methods

| Method            | Description                                                                        |
| ----------------  | --------------------------------------------------------------------------------   |
| Authorize         | Take the credentals of the user and Use Jwt to generate and return a Token to the  |
|                   | user.                                                                              |
| RefreshToken      | Take a token as parameter and use jwt to generate a new valid token                |
| GetUserClaims     | Retur a the list of the user Claims                                                |




# AccountController Methods

| Method            | Description                                                                        |
| ------------      | ----------------------------------------------------------------------------       |
| CreateUser        | This method will take a user as parameter and verify if the user exists (Bad|      |
|                   | request).if not this method will register him.                                     |
|                   |                                                                                    |
| Login             | Take the Credentials of the user as parameters ,verify if the user is exist        |                    
|                   | in the data base and generate a Token to authenticate the.if not it throws a       |
|                   | bad request.                                                                       |
| Logout            | Verify if the user is logged in and and log out the user                           |
|                   |                                                                                    |
| UpdateUser        | Take the user as a parameter and Update His credentials in the database            |
| DeleteUser        | Take a user parameter and if the user exist it deletes the user                    |
| UpdatePassword    | Take the user parameter and update his password in the database if he exists.      |
| ResetPassword     | Reset the password of the user if the user can not remember his password(user as   |
|                   | parameter)                                                                         |
| UpdateUserClaims  |                                                                                    |


# Cases

**Feature** : CreateUser
**As a** user 
**I want to** add a new user 

**Scenario 1** : The user entered  credentials that exist in the database 
**Given** email password 
**Then** we will Throw a bad request to the user that this user already exists


**Scenario 2** : The user entered new credentials 
**Given** email and password
**Then** we will register him and give him the token for authentication

**Feature** :Authorize
**As a** user
**I want to** get the Token

**Scenario 1** : The user credential is not null
**Given** email and password
**Then** we generate the token for him

**Feature** : Login
**As a** user 
**I want to** login

**Scenario 1** : The user entered  credentials that does not exist in the database 
**Given** email password 
**Then** we will Throw a bad request to the user that this user already exists

**Scenario 2** : The user entered  credentials that exist in the database 
**Given** email password 
**Then** we will login the user


**Feature** : Logout
**As a** user 
**I want to** logout

**Scenario 1** : the user is not loggedin
**Given** email password 
**Then** we will Throw a bad request to the user that this user is not logged in

**Scenario 2** : the user is  loggedin
**Given** email password 
**Then** we will logout the user


**Feature** : UpdateUser
**As a** user 
**I want to** update the user 

**Scenario 1** : the user provdides valid credentials
**Given** email password 
**Then** we will update the user

**Feature** : DeleteUser
**As a** user 
**I want to** Delete the user 

**Scenario 1** : the user provdides valid credentials
**Given** email password 
**Then** we will Delete the user

**Feature** : UpdatePassword
**As a** user 
**I want to** Update the Password 

**Scenario 1** : the user provdides valid credentials
**Given** email password and new Password
**Then** we will Update the password

**Feature** : ResetPassword
**As a** user 
**I want to** Update the Password 

**Scenario 1** : the user provdides valid credentials
**Given** email and new Password
**Then** we will Reset the password

## Technologies 

PostgreSql.
The PostgreSql server contains excellent compression and encrytion capabilities that result in improved data storage and 
retrievial funtions. The PostgreSql server is one of the most secure database servers with encryption algorithms making it virtually impossible to crack the security layers enforced by the user. MS SQL server is not an open-source database server which reduces the risk of attacks on the database server. PostgreSql server is fully aware of the importance of your data. Hence MS SQL Server contains many sophisticated features that allow you to recover and restore the data which has been lost or damaged. The structure of this service does not need to be changed that's why we will use a sql database.

### O.R.M(Object relational mapping)
We will be using EntityFramework as an orm for this application because it provides a way to generate the database form the model.


##### Database Structure

| Users               | 
| ------------------- |
| Id                  |
|                     |
| FirstName           |
|                     |                                                        
| LastName            |  
|                     |                                                  
| Email               | 
|                     |
| Password            |
|                     |
| RegistrationDate    |
|                     |
| UserName            |
|                     |
| NormalizedUserName  |
|                     |
| NormalizedEmail     |
|                     |
| EmailConfirmed      |
|                     |  
| PasswordHash        |
|                     |
| SecurityStamp       |
|                     |
| ConcurrencyStamp    |
|                     |
| PhoneNumber         |
|                     |
| PhoneNumberConfirmed|
|                     |
| TwoFactorEnabled    |
|                     |
| LockoutEnd          |
|                     |
| LockoutEnabled      |
|                     |
| AccessFailedCount   |
|                     |


| Claims              | 
| ------------------- |
| Id                  |
|                     |
| UserId              |
|                     |
| ClaimType           |
|                     |
| ClaimValue          |
|                     |
| Discriminator       |
|                     |


| Tokens              |
| ------------------- |
| UserId              |
|                     |
| LoginProvider       |
|                     |
| Name                |
|                     |
| Value               |
|                     |
| Discriminator       |
|                     |


| AspNetUserLogins    |
| ------------------- |
| LoginProvider       |
|                     |
| ProviderKey         |
|                     |
| ProviderDisplayName |
|                     |
| UserId              |
|                     |


| AspNetUserRoles     |
| ------------------- |
| UserId              |
|                     |
| RoleId              |
|                     |


| Roles               |
| ------------------- |
| Id                  |
|                     |
| Name                |
|                     |
| Description         |
|                     |
| NormalizedName      |
|                     |
| ConcurrencyStamp    |
|                     |


| AspNetRoleClaims    |
| ------------------- |
| Id                  |
|                     |
| RoleId              |
|                     |
| ClaimType           |
|                     |
| ClaimValue          |
|                     |


| UserRefreshTokens       |
| ----------------------- |
| Id                      |
|                         |
| UserId                  |
|                         |
| RefreshToken            |
|                         |
| CreationDate            |
|                         |
|LifeRefreshTokenInMinutes|