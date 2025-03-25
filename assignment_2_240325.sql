create database tech_shop;
use tech_shop;
create table customers (customerid int primary key ,firstname varchar(50) ,lastname varchar(20),email varchar(50),phone varchar(20),address varchar(200));
create table products (productid int primary key ,productname varchar(100) not null ,description TEXT,price decimal (10,2)not null);
create table orders(orderid int primary key,customerid int,orderdate date not null ,totalamount decimal (10,2) not null, foreign key (customerid) references customers(customerid)); 
create table orderdetails(orderdetailid int primary key,orderid int,productid int,quantity int not null,foreign key (orderid) references orders(orderid),foreign key (productid) references products(productid));
create table inventory(inventoryid int primary key ,productid int,quantityinstock int not null, laststockupdate DATE,foreign key (productid) references products(productid)); 
insert into customers (customerid, firstname, lastname, email, phone, address)
VALUES
(1, 'John', 'Doe', 'john.doe@email.com', '555-1001', '1234 Elm St, Springfield'),
(2, 'Jane', 'Smith', 'jane.smith@email.com', '555-1002', '5678 Oak St, Rivertown'),
(3, 'Michael', 'Johnson', 'michael.johnson@email.com', '555-1003', '1357 Maple Ave, Pleasantville'),
(4, 'Emily', 'Davis', 'emily.davis@email.com', '555-1004', '2468 Pine St, Lakeside'),
(5, 'William', 'Brown', 'william.brown@email.com', '555-1005', '9876 Birch Rd, Highland Park'),
(6, 'Olivia', 'Miller', 'olivia.miller@email.com', '555-1006', '1359 Cedar Blvd, Summit City'),
(7, 'Daniel', 'Wilson', 'daniel.wilson@email.com', '555-1007', '3690 Willow Ln, Greenfield'),
(8, 'Sophia', 'Moore', 'sophia.moore@email.com', '555-1008', '7531 Maple Dr, Westbrook'),
(9, 'James', 'Taylor', 'james.taylor@email.com', '555-1009', '8642 Elmwood Ave, Crestwood'),
(10, 'Liam', 'Anderson', 'liam.anderson@email.com', '555-1010', '9753 Oakwood St, Redwood City');
insert into products (productid, productname, description, price) VALUES
(1, 'Laptop', 'A high-performance laptop', 899.99),
(2, 'Smartphone', 'A cutting-edge smartphone', 599.99),
(3, 'Headphones', 'Noise-cancelling headphones', 49.99),
(4, 'Mouse', 'Wireless mouse', 19.99),
(5, 'Keyboard', 'Mechanical keyboard', 29.99),
(6, 'Monitor', '24-inch LED monitor', 299.99),
(7, 'Charger', 'Fast charging USB charger', 14.99),
(8, 'Smartwatch', 'Fitness tracking smartwatch', 199.99),
(9, 'Tablet', '10-inch Android tablet', 349.99),
(10, 'External Hard Drive', '1TB external hard drive', 99.99);
insert into orders (orderid, customerid, orderdate, totalamount) VALUES
(1, 1, '2025-03-20', 899.99),
(2, 2, '2025-03-21', 1199.98),
(3, 3, '2025-03-22', 49.99),
(4, 4, '2025-03-22', 29.99),
(5, 5, '2025-03-23', 399.98),
(6, 6, '2025-03-23', 599.97),
(7, 7, '2025-03-24', 899.99),
(8, 8, '2025-03-24', 199.99),
(9, 9, '2025-03-25', 249.99),
(10, 10, '2025-03-25', 699.98);
insert into orderdetails (orderdetailid, orderid, productid, quantity) VALUES
(1, 1, 1, 1),  
(2, 2, 2, 2), 
(3, 3, 3, 1), 
(4, 4, 4, 1), 
(5, 5, 5, 2),  
(6, 6, 6, 2), 
(7, 7, 7, 1), 
(8, 8, 8, 1), 
(9, 9, 9, 1), 
(10, 10, 10, 2);
insert into inventory (inventoryid, productid, quantityinstock ,laststockupdate) VALUES
(1, 1, 50, '2025-03-20'),
(2, 2, 100, '2025-03-21'),
(3, 3, 150, '2025-03-22'),
(4, 4, 200, '2025-03-23'),
(5, 5, 120, '2025-03-23'),
(6, 6, 30, '2025-03-24'),
(7, 7, 250, '2025-03-25'),
(8, 8, 75, '2025-03-26'),
(9, 9, 60, '2025-03-27'),
(10, 10, 80, '2025-03-28');


select * from customers;
select * from products;
select * from orders;
select * from orderdetails;
select * from inventory;


----Retrieve the names and emails of all customers

SELECT firstname, lastname, email
FROM customers;

---List all orders with their order dates and corresponding customer names
SELECT 
    orderid,
    orderdate,
    (SELECT firstname FROM customers WHERE customers.customerid = orders.customerid) AS firstname,
    (SELECT lastname FROM customers WHERE customers.customerid = orders.customerid) AS lastname
FROM orders;

-----Insert a new customer record into the "Customers" table (example values)

INSERT INTO customers (customerid, firstname, lastname, email, phone, address)
VALUES (11, 'Ava', 'Clark', 'ava.clark@email.com', '555-1011', '123 River St,Brooktown');
select* from customers;

-----Update the prices of all electronic gadgets in the "Products" table by increasing them by 10%

SELECT productid,productname,
    price AS old_price,
    price * 1.10 AS simulated_new_price
FROM products
WHERE productname IN ('Laptop', 'Smartphone', 'Tablet', 'Smartwatch', 'Headphones', 'Charger');



------Delete a specific order and its associated order details (user provides @OrderID)
DECLARE @OrderID INT = 3; 
DELETE FROM orderdetails
WHERE orderid = @OrderID;
DELETE FROM orders
WHERE orderid = @OrderID;

-----Insert a new order into the Orders table
insert  INTO Orders (orderid, customerid, orderdate, totalamount)
VALUES (11, 5, '2025-03-26', 499.99);


----update the contact information (email and address) of a specific customer in the Customers table
DECLARE @CustomerID INT = 3; 
DECLARE @NewEmail VARCHAR(50) = 'updated.email@email.com'; 
DECLARE @NewAddress VARCHAR(200) = 'Updated Address, New City'; 

UPDATE Customers
SET email = @NewEmail,
    address = @NewAddress
WHERE customerid = @CustomerID;



---(8)update the total cost of each order in the Orders table based on the prices and quantities in the OrderDetails table, you can use the following query:



SELECT o.orderid, 
       (SELECT SUM(od.quantity * p.price) 
        FROM orderdetails od, products p WHERE od.productid = p.productid AND od.orderid = o.orderid) AS recalculated_total 
FROM orders o;


-----(9)Delete all orders and their associated order details for a specific customer

 
 DECLARE @Customer_ID INT = 3;  
DELETE FROM orderdetails
WHERE orderid IN (SELECT orderid FROM orders WHERE customerid = @Customer_ID);
DELETE FROM orders
WHERE customerid = @Customer_ID;
select* from customers;






--(10)Insert a new electronic gadget product into the Products table

INSERT INTO Products (productid, productname, description, price)
VALUES (11, 'Wireless Earbuds', 'Bluetooth-enabled wireless earbuds with noise cancellation', 129.99);



--(11)

ALTER TABLE Orders
ADD state VARCHAR(20);
DECLARE @Order_ID INT = 5; 
DECLARE @NewStatus VARCHAR(20) = 'Shipped';  
UPDATE Orders
SET state = @NewStatus
WHERE orderid = @OrderID;



-----(12)
ALTER TABLE Customers
ADD order_count INT DEFAULT 0;
UPDATE Customers 
SET order_count = (
    SELECT COUNT(*)
    FROM Orders o
    WHERE o.customerid = customerid
);











