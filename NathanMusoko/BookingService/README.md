# ServiceName
BookingService

# General

The service provides the logic to create , read , update and delete the order of the user .This service will contain
an access to the database Booking that will contain orders.

# BookController Methods

| Method            |                        Description                                                        |
| ------------      | ----------------------------------------------------------------------------              |
| CreateOrder       |  creates an new order in the database in the databse                                      |
|                   |                                                                                           |
| GetOrderByUser    | This method will get the list of order in database                                        |   
|                   |                                                                                           |
| UpdateOrder       | Take an order as parameter and Verify if the order exist and update the order             |
|                   |                                                                                           |
| DeleteOrder       | Take an order as a parameter and verify if the order exist in the Database and delete it  |


# Cases

**Feature** : CreateOrder
**As a** User 
**I want to**create a new Order  

**Scenario 1** : The user enter an Order that already exists 
**Given** the userId, the BookId, tha date  
**Then** we will create a new order 


**Scenario 2** : The user enter an order that does not exist 
**Given** the UserId, the BookId, tha date  
**Then** we will create a new order 

**Feature** :UpdateOrder
**As a** User
**I want to** update this order

**Scenario 1** : the user enter a valid order that exists
**Given** the UserId, the BookId and the date
**Then** we update the order 

**Feature** : DeleteOrder
**As a** User
**I want to**Delete this order from the database

**Scenario 1** : the user enter a valid order that exists
**Given** the UserId, the BookId and the date
**Then** we delete the order 

**Scenario 2** : The user enter an order that does not exist 
**Given** the UserId, the BookId and the date
**Then** we will not delete and throw a bad request