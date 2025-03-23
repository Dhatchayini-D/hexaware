create database Techshop;
use Techshop;
create table customers (customerid int primary key ,firstname varchar(50)not null ,lastname varchar(20)not null,email varchar(50) not null ,phone varchar(20),address varchar(200));
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


