/* Create database (SQL Server way) */
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'LoanDB')
BEGIN
    CREATE DATABASE LoanDB;
END
GO

USE LoanDB;
GO


CREATE TABLE Customer (
    CID VARCHAR(10) PRIMARY KEY,
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    gender VARCHAR(10),
    placeOfBirth VARCHAR(100),
    dateOfBirth DATE,
    currentAddress VARCHAR(200),
    status VARCHAR(20)
);


CREATE TABLE Term (
    TID INT IDENTITY(1,1) PRIMARY KEY,
    term INT NOT NULL,
    annualInterest DECIMAL(5,2)
);


CREATE TABLE LoanContract (
    LC VARCHAR(10) PRIMARY KEY,
    CID VARCHAR(10) NOT NULL,
    loanAmount DECIMAL(12,2) NOT NULL,
    TermID INT NULL,
    MonthlyInterest DECIMAL(12,2),
    LoanDate DATE,
    startPaymentDate DATE,
    status VARCHAR(20),
    scheduleStatus VARCHAR(20),

    CONSTRAINT FK_LoanContract_Customer
        FOREIGN KEY (CID) REFERENCES Customer(CID),

    CONSTRAINT FK_LoanContract_Term
        FOREIGN KEY (TermID) REFERENCES Term(TID)
);



CREATE TABLE PaymentSchedule (
    ScheduleID INT IDENTITY(1,1) PRIMARY KEY,
    LC VARCHAR(10) NOT NULL,
    dueDate DATE NOT NULL,
    monthlyPayment DECIMAL(12,2),
    principal DECIMAL(12,2),
    interest DECIMAL(12,2),
    service DECIMAL(12,2),
    balance DECIMAL(12,2),
    action VARCHAR(50),

    CONSTRAINT FK_PaymentSchedule_LoanContract
        FOREIGN KEY (LC) REFERENCES LoanContract(LC)
);



INSERT INTO Customer
(CID, firstname, lastname, gender, placeOfBirth, dateOfBirth, currentAddress, status)
VALUES
('C00001', 'John', 'Doe', 'Male', 'Phnom Penh', '1990-01-01', '123 Street', 'Active');
INSERT INTO Term (term, annualInterest)
VALUES (60, 12.00);
INSERT INTO LoanContract
(LC, CID, loanAmount, TermID, MonthlyInterest, LoanDate, startPaymentDate, status, scheduleStatus)
VALUES
('LC001', 'C00001', 20000.00, 1, 100.00, '2026-01-01', '2026-02-01', 'Active', 'Pending');
INSERT INTO PaymentSchedule
(LC, dueDate, monthlyPayment, principal, interest, service, balance, action)
VALUES
('LC001', '2026-02-01', 300.00, 199.00, 100.00, 1.00, 19800.00, 'Pending');





SELECT
    FORMAT(ps.dueDate, 'dd/MM/yyyy')      AS [Date],
    ps.LC                                 AS [LC],
    lc.CID                                AS [CID],
    ps.monthlyPayment                     AS [Monthly Payment],
    ps.principal                          AS [Principle],
    ps.interest                           AS [Interest],
    ps.service                            AS [Service],
    ps.balance                            AS [Balance],
    FORMAT(ps.dueDate, 'dd/MM/yyyy')      AS [Due Date],
    ps.action                             AS [Action]
FROM PaymentSchedule ps
INNER JOIN LoanContract lc ON ps.LC = lc.LC
INNER JOIN Customer c ON lc.CID = c.CID
ORDER BY ps.dueDate;
