CREATE DATABASE RetailStore;
GO

USE RetailStore;
GO
CREATE TABLE Products (
    ProductID INT PRIMARY KEY,
    ProductName VARCHAR(100),
    Category VARCHAR(50),
    Price DECIMAL(10, 2)
);
INSERT INTO Products VALUES 
(1, 'Laptop', 'Electronics', 1000),
(2, 'Smartphone', 'Electronics', 700),
(3, 'Tablet', 'Electronics', 700),
(4, 'Headphones', 'Electronics', 150),
(5, 'Jeans', 'Clothing', 50),
(6, 'Jacket', 'Clothing', 120),
(7, 'Shoes', 'Clothing', 80),
(8, 'T-Shirt', 'Clothing', 20),
(9, 'Refrigerator', 'Appliances', 900),
(10, 'Microwave', 'Appliances', 300),
(11, 'Blender', 'Appliances', 300),
(12, 'Toaster', 'Appliances', 80);
