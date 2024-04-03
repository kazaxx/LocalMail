Create database Local

use local

Create Table Mesages(
 ID_Message INT PRIMARY KEY identity(1,1),
 Mesage VARCHAR(400) NOT NULL,
 ID_Sender int NOT NULL FOREIGN KEY (ID_Sender) REFERENCES Users(ID_Users),
 Dates Date NOT NULL ,
 ID_Recipient int NOT NULL FOREIGN KEY (ID_Recipient) REFERENCES Users(ID_Users),
 Theme varchar(50) NOT NULL,
 Importance varchar(10)
 )

 CREATE TABLE Users(
    ID_Users int PRIMARY KEY IDENTITY(1,1) NOT NULL,
    Username varchar (50) NOT NULL,
    Password varchar (50) NOT NULL,
    Name varchar (50) NOT NULL,
    Surname varchar(50) NOT NULL,
    Role varchar(50) NOT NULL,
    Department varchar(50) NOT NULL)