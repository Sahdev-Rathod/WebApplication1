Create Database CategoryAuthentication

Use CategoryAuthentication

Create Table Role
(
Id int Primary key identity,
Name varchar(100) not null
)

Create Table [User]
(
Id int primary key identity,
Name varchar(100) not null,
LastName varchar(100) , 
Email varchar(100),
Password varchar(100) , 
RoleId int foreign key references Role(Id)
)

Insert into Role Values ('Admin') , ('User') , ('Courier') , ('Merchant')

Insert into [User] Values ('Sahdev' , 'Rathod' , 'SahdevRathod@gmail.com' , 'SahdevRathod@123' , 1) , ('Shailesh' , 'Ade' , 'Shaileshade@gmail.com' , 'Shaileshade@123' , 2)

Select * from [User]

Create Table Product
(
Id int primary key identity,
Name varchar(100) not null,
price int ,
Stock int ,
productCompany varchar(100)
)

INSERT INTO Product (Name, Price, Stock, ProductCompany) VALUES
('Laptop', 55000, 10, 'Dell'),
('Mobile', 20000, 25, 'Samsung'),
('Tablet', 15000, 15, 'Apple'),
('Monitor', 12000, 8, 'LG'),
('Keyboard', 800, 50, 'Logitech'),
('Mouse', 500, 60, 'HP'),
('Printer', 7000, 5, 'Canon'),
('Headphones', 1500, 30, 'Sony'),
('Smart Watch', 3000, 20, 'Noise'),
('Speaker', 2500, 18, 'JBL');

Select * From Product