SELECT * FROM user_db.user_tbl;

CREATE TABLE Employees (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(100) NOT NULL,
    LastName VARCHAR(100) NOT NULL,
    ContactNumber VARCHAR(50),
    Email VARCHAR(150)
);

CREATE TABLE AuditLogs (
	UserID INT,
	Username VARCHAR(255),
    Role VARCHAR(7),
	LogName VARCHAR(100) NOT NULL,
    Details LONGTEXT,
    Date DATETIME
);