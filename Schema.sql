-- Authors table
CREATE TABLE Authors (
    ID INT PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);

-- Books table
CREATE TABLE Books (
    ID INT PRIMARY KEY,
    Title NVARCHAR(200) NOT NULL,
    AuthorID INT NOT NULL FOREIGN KEY REFERENCES Authors(ID),
    PublicationYear INT NOT NULL,
       
       
);

-- Insert authors
INSERT INTO Authors (ID, Name) VALUES
(1, 'Robert C. Martin'),
(2, 'Jeffrey Richter');

-- Insert books
INSERT INTO Books (ID, Title, AuthorID, PublicationYear) VALUES
(1, 'Clean Code', 1, 2008),
(2, 'CLR via C#', 2, 2012),
(3, 'The Clean Coder', 1, 2011);


--  UPDATE A BOOK
UPDATE Books
SET PublicationYear = 2013
WHERE ID = 2;

--DELETE A BOOK
DELETE FROM Books
WHERE ID = 3;


--SELECT BOOKS PUBLISHED AFTER 2010
SELECT b.Title, a.Name AS AuthorName
FROM Books b
JOIN Authors a ON b.AuthorID = a.ID
WHERE b.PublicationYear > 2010;
