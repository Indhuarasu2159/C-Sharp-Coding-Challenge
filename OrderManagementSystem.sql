use OrderManagementSystemDB
SELECT * FROM Users
SELECT * FROM Products
SELECT * FROM Orders
DELETE FROM Users WHERE UserId IN (5, 6); 
DELETE FROM Users WHERE UserId IN (7); 
DELETE FROM Users WHERE UserId IN (4); 
DELETE FROM Products WHERE ProductId IN (5,6,7,8); 