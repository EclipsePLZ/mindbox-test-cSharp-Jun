/* We will have movies as our product and movie genres as our categories. */

/* Create the products database, if it has not already been created */
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'products')
BEGIN
	CREATE DATABASE products;
END;


/* Select the products database to work with. */
USE products;


/* Create the items table if it has not already been created, otherwise clear the table
   Items table contains 4 columns (id, name, quantity, price) */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'items' AND type = 'U')
BEGIN
	CREATE TABLE dbo.items (
		id INT PRIMARY KEY,
		name NVARCHAR(150) NOT NULL,
		quantity INT NOT NULL CHECK (quantity >= 0), 
		price DECIMAL(10, 2) NOT NULL CHECK (price > 0)
	);
END
ELSE
BEGIN
	DELETE FROM products.dbo.items;
END


/* Create the categories table if it has not already been created, otherwise clear the table
   Categories table contains 2 columns (id, name) */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'categories' AND type = 'U')
BEGIN
	CREATE TABLE dbo.categories (
		id INT PRIMARY KEY,
		name NVARCHAR(150) NOT NULL
	);
END
BEGIN
	DELETE FROM products.dbo.categories;
END


/* Create a table to display the many to many relationship between the items and categories table if it has not already been created, otherwise clear the table
   Categories table contains 2 columns (id_item, id_category) */
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'items_categories' AND type = 'U')
BEGIN
	CREATE TABLE dbo.items_categories (
		item_id INT NOT NULL,
		category_id INT NOT NULL,
		PRIMARY KEY (item_id, category_id),
		CONSTRAINT fk_item_id FOREIGN KEY (item_id) REFERENCES items(id) ON DELETE CASCADE,
		CONSTRAINT fk_category_id FOREIGN KEY (category_id) REFERENCES categories(id) ON DELETE CASCADE
	);
END
ELSE
BEGIN
	DELETE FROM products.dbo.items_categories;
END


/* Insert values into items table */
INSERT INTO items (id, name, quantity, price)
VALUES (1, 'Die Hard', 3, 230),
	   (2, 'Interstellar', 12, 430),
	   (3, 'FIght Club', 23, 120),
	   (4, 'Inception', 45, 11),
	   (5, 'Drive', 12, 320),
	   (6, 'Knives Out', 3, 122),
	   (7, 'Limitless', 11, 100),
	   (8, 'The Green Mile', 24, 200),
	   (9, 'Green Book', 8, 900),
	   (10, 'Tenet', 9, 350),
	   (11, 'American Psycho', 18, 330),
	   (12, 'Saw X', 28, 350);


/* Insert values into categories table */
INSERT INTO categories (id, name)
VALUES (1, 'Thriller'),
	   (2, 'Drama'),
	   (3, 'Criminal'),
	   (4, 'Fiction'),
	   (5, 'Action movie'),
	   (6, 'Detective'),
	   (7, 'Comedy'),
	   (8, 'Fantasy'),
	   (9, 'Biography');


/* Insert values into categories table */
INSERT INTO items_categories (item_id, category_id)
VALUES (3, 1), (3, 2), (3, 3), (4, 4),
	   (4, 5), (4, 1), (4, 2), (4, 6),
	   (5, 3), (5, 2), (5, 1), (6, 6),
	   (6, 7), (6, 2), (6, 3), (7, 1),
	   (7, 2), (7, 8), (8, 2), (8, 8),
	   (8, 3), (9, 9), (9, 7), (9, 2),
	   (10, 4), (10, 8), (10, 1), (11, 2),
	   (11, 3), (11, 1), (1, 4), (1, 1),
	   (1, 3), (2, 8), (2, 2);


/* Query to output all products and categories for them */
SELECT i.name AS 'Имя продукта', c.name AS 'Имя категории'
FROM items_categories it
	JOIN categories c ON it.category_id = c.id
	RIGHT JOIN items i ON it.item_id = i.id;