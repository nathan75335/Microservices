# ServiceName
CatalogService

# General

The service provides the logic to create , read , update and delete the catalog of books .This service will contain
an access to the database Library that will contain books.

# BookController Methods

| Method            |                        Description                                                    |
| ------------      | ----------------------------------------------------------------------------          |
| CreateBook        | Verify if the Book exists (bad reques) if not it creates an new Book in the databse   |
|                   |                                                                                       |
| GetBooksByGenre   | This method will get the list of Books in database and return a List(Book by genre)   |   
|                   |                                                                                       |
| GetBook           | Take an id as a parameter and return a book from the database or if the book does     |
|                   | not exist it returns a bad request                                                    |
|                   |                                                                                       |
| UpdateBook        | Take a book as parameter and Verify if the book exist and update the book             |
|                   |                                                                                       |
| DeleteBook        | Take a book as a parameter and verify if the book exist in the Db and delete it       |


# Cases

**Feature** : CreateBook
**As a** Admin 
**I want to**create a new Book  

**Scenario 1** : The admin enter a Book that already exists 
**Given** the Name , the genre and the House Edition of the Book 
**Then** we will Throw a bad request to the Book that the admin entered already exists


**Scenario 2** : The admin enter a Book that does not exist 
**Given** the Name , the genre and the House Edition of the Book
**Then** we will add the Book to the data base the Book 

**Feature** :UpdateBook
**As a** admin
**I want to** update this book

**Scenario 1** : the admin enter a valid book that exists
**Given** the Name , the genre and the House Edition of the Book
**Then** we update the book 

**Feature** : DeleteBook
**As a** Admin 
**I want to**Delete this book from the database

**Scenario 1** : the admin enter a valid book that exists
**Given** the Name , the genre and the House Edition of the Book
**Then** we delete the book 

**Scenario 2** : The admin enter a Book that does not exist 
**Given** the Name , the genre and the House Edition of the Book
**Then** we will not delete and throw a bad request