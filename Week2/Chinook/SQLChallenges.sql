-- SETUP:
    -- Create a database server (docker)
        -- docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<password>" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
    -- Connect to the server (Azure Data Studio / Database extension)
    -- Test your connection with a simple query (like a select)
    -- Execute the Chinook database (to create Chinook resources in your db)
USE VTDatabase;
-- See all tables
SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE';

-- Test query
SELECT TOP 5 * FROM Artist;

SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG = 'VTDatabase';
-- On the Chinook DB, practice writing queries with the following exercises

-- BASIC CHALLENGES
-- List all customers (full name, customer id, and country) who are not in the USA
SELECT * FROM Customer;
--**********************************************************************************
SELECT 
    CONCAT(FirstName, ' ', LastName) AS FullName,
    CustomerId,
    Country
FROM Customer
WHERE Country != 'USA';
-- List all customers from Brazil
SELECT 
    CONCAT(FirstName, ' ', LastName) AS FullName,
    CustomerId,
    City
FROM Customer
WHERE Country = 'Brazil';    
-- List all sales agents
SELECT * FROM Employee;
--***************************************************************************
SELECT
    CONCAT(FirstName, ' ', LastName) AS FullName,
    EmployeeId, 
    Title
From Employee
WHERE Title Like '%Sales%Agent%' OR Title Like '%Sales Support%';
--***************************************************************************
SELECT * FROM Invoice;
-- Retrieve a list of all countries in billing addresses on invoices
SELECT BillingCountry
FROM Invoice
ORDER BY BillingCountry;
-- Retrieve how many invoices there were in 2009, and what was the sales total for that year?
SELECT 
    COUNT(*) AS InvoiceCount,
    SUM(Total) AS TotalSales
FROM Invoice
WHERE YEAR(InvoiceDate) = 2009;
    -- (challenge: find the invoice count sales total for every year using one query)
    SELECT 
    YEAR(InvoiceDate) AS Year,
    COUNT(*) AS InvoiceCount,
    SUM(Total) AS TotalSales
FROM Invoice
GROUP BY YEAR(InvoiceDate)
ORDER BY Year;
--***********************************************************************************
SELECT * FROM InvoiceLine;
-- how many line items were there for invoice #37
SELECT COUNT(*) AS LineItems
FROM InvoiceLine
WHERE InvoiceId = 37;
-- how many invoices per country? BillingCountry  # of invoices -
SELECT 
    BillingCountry,
    COUNT(*) AS NumberOfInvoices
FROM Invoice
GROUP BY BillingCountry
ORDER BY NumberOfInvoices DESC;
-- Retrieve the total sales per country, ordered by the highest total sales first.
SELECT 
    BillingCountry,
    SUM(Total) AS TotalSales
FROM Invoice
GROUP BY BillingCountry
ORDER BY TotalSales DESC;
-- JOINS CHALLENGES
SELECT * FROM Artist;
SELECT * FROM Album;
-- Every Album by Artist
SELECT 
    ar.Name AS ArtistName,
    al.Title AS AlbumTitle
FROM Artist ar
JOIN Album al ON ar.ArtistId = al.ArtistId
ORDER BY ar.Name, al.Title;
--***************************************************************************************
SELECT * FROM Genre;
-- All songs of the rock genre
SELECT 
    t.Name AS TrackName,
    al.Title AS AlbumTitle,
    ar.Name AS ArtistName
FROM Track t
JOIN Album al ON t.AlbumId = al.AlbumId
JOIN Artist ar ON al.ArtistId = ar.ArtistId
JOIN Genre g ON t.GenreId = g.GenreId
WHERE g.Name = 'Rock'
ORDER BY ar.Name, al.Title, t.Name;
-- Show all invoices of customers from brazil (mailing address not billing)
SELECT 
    i.InvoiceId,
    i.InvoiceDate,
    i.Total,
    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName
FROM Invoice i
JOIN Customer c ON i.CustomerId = c.CustomerId
WHERE c.Country = 'Brazil'
ORDER BY i.InvoiceDate;
-- Show all invoices together with the name of the sales agent for each one
SELECT 
    i.InvoiceId,
    i.InvoiceDate,
    i.Total,
    CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
    CONCAT(e.FirstName, ' ', e.LastName) AS SalesAgentName
FROM Invoice i
JOIN Customer c ON i.CustomerId = c.CustomerId
JOIN Employee e ON c.SupportRepId = e.EmployeeId
ORDER BY i.InvoiceDate;
-- Which sales agent made the most sales in 2009?
SELECT TOP 1
    CONCAT(e.FirstName, ' ', e.LastName) AS SalesAgentName,
    SUM(i.Total) AS TotalSales,
    COUNT(i.InvoiceId) AS NumberOfSales
FROM Invoice i
JOIN Customer c ON i.CustomerId = c.CustomerId
JOIN Employee e ON c.SupportRepId = e.EmployeeId
WHERE YEAR(i.InvoiceDate) = 2009
GROUP BY e.EmployeeId, e.FirstName, e.LastName
ORDER BY TotalSales DESC;
-- How many customers are assigned to each sales agent?
SELECT 
    CONCAT(e.FirstName, ' ', e.LastName) AS SalesAgentName,
    COUNT(c.CustomerId) AS NumberOfCustomers
FROM Employee e
LEFT JOIN Customer c ON e.EmployeeId = c.SupportRepId
WHERE e.Title LIKE '%Sales%Agent%' OR e.Title LIKE '%Sales Support%'
GROUP BY e.EmployeeId, e.FirstName, e.LastName
ORDER BY NumberOfCustomers DESC;
-- Which track was purchased the most ing 2010?
SELECT TOP 1
    t.Name AS TrackName,
    al.Title AS AlbumTitle,
    ar.Name AS ArtistName,
    COUNT(il.TrackId) AS TimesPurchased
FROM InvoiceLine il
JOIN Invoice i ON il.InvoiceId = i.InvoiceId
JOIN Track t ON il.TrackId = t.TrackId
JOIN Album al ON t.AlbumId = al.AlbumId
JOIN Artist ar ON al.ArtistId = ar.ArtistId
WHERE YEAR(i.InvoiceDate) = 2010
GROUP BY t.TrackId, t.Name, al.Title, ar.Name
ORDER BY TimesPurchased DESC;
-- Show the top three best selling artists.
SELECT TOP 3
    ar.Name AS ArtistName,
    SUM(il.UnitPrice * il.Quantity) AS TotalSales
FROM Artist ar
JOIN Album al ON ar.ArtistId = al.ArtistId
JOIN Track t ON al.AlbumId = t.AlbumId
JOIN InvoiceLine il ON t.TrackId = il.TrackId
GROUP BY ar.ArtistId, ar.Name
ORDER BY TotalSales DESC;
-- Which customers have the same initials as at least one other customer?
SELECT 
    LEFT(FirstName, 1) + LEFT(LastName, 1) AS Initials,
    COUNT(*) AS CustomerCount,
    STRING_AGG(CONCAT(FirstName, ' ', LastName), ', ') AS Customers
FROM Customer
GROUP BY LEFT(FirstName, 1) + LEFT(LastName, 1)
HAVING COUNT(*) > 1
ORDER BY CustomerCount DESC;
-- ADVACED CHALLENGES
-- solve these with a mixture of joins, subqueries, CTE, and set operators.
-- solve at least one of them in two different ways, and see if the execution
-- plan for them is the same, or different.

-- 1. which artists did not make any albums at all?

-- 2. which artists did not record any tracks of the Latin genre?

-- 3. which video track has the longest length? (use media type table)

-- 4. find the names of the customers who live in the same city as the
--    boss employee (the one who reports to nobody)

-- 5. how many audio tracks were bought by German customers, and what was
--    the total price paid for them?

-- 6. list the names and countries of the customers supported by an employee
--    who was hired younger than 35.


-- DML exercises

-- 1. insert two new records into the employee table.

-- 2. insert two new records into the tracks table.

-- 3. update customer Aaron Mitchell's name to Robert Walter

-- 4. delete one of the employees you inserted.

-- 5. delete customer Robert Walter.
