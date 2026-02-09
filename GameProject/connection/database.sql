-- Create database
CREATE DATABASE IF NOT EXISTS LoanDB;
USE LoanDB;

-- Customer Table
CREATE TABLE Customer (
    CID VARCHAR(10) PRIMARY KEY,
    firstname VARCHAR(50) NOT NULL,
    lastname VARCHAR(50) NOT NULL,
    gender CHAR(1),
    placeOfBirth VARCHAR(100),
    dateOfBirth DATE,
    currentAddress VARCHAR(200),
    status VARCHAR(20)
);

-- Term Table
CREATE TABLE Term (
    TID INT AUTO_INCREMENT PRIMARY KEY,
    term INT NOT NULL,
    annualInterest DECIMAL(5,2)
);

-- LoanContract Table
CREATE TABLE LoanContract (
    LC VARCHAR(10) PRIMARY KEY,
    CID VARCHAR(10) NOT NULL,
    loanAmount DECIMAL(12,2) NOT NULL,
    TermID INT NOT NULL,
    MonthlyInterest DECIMAL(12,2),
    LoanDate DATE,
    startPaymentDate DATE,
    status VARCHAR(20),
    scheduleStatus VARCHAR(20),
    FOREIGN KEY (CID) REFERENCES Customer(CID),
    FOREIGN KEY (TermID) REFERENCES Term(TID)
);

-- PaymentSchedule Table
CREATE TABLE PaymentSchedule (
    ScheduleID INT AUTO_INCREMENT PRIMARY KEY,
    LC VARCHAR(10) NOT NULL,
    dueDate DATE NOT NULL,
    monthlyPayment DECIMAL(12,2),
    principal DECIMAL(12,2),
    interest DECIMAL(12,2),
    service DECIMAL(12,2),
    balance DECIMAL(12,2),
    action VARCHAR(50),
    FOREIGN KEY (LC) REFERENCES LoanContract(LC)
);

-- Example Data
INSERT INTO Customer (CID, firstname, lastname, gender, placeOfBirth, dateOfBirth, currentAddress, status)
VALUES ('C00001', 'John', 'Doe', 'M', 'Phnom Penh', '1990-01-01', '123 Street', 'Active');

INSERT INTO Term (term, annualInterest)
VALUES (60, 12.00);

INSERT INTO LoanContract (LC, CID, loanAmount, TermID, MonthlyInterest, LoanDate, startPaymentDate, status, scheduleStatus)
VALUES ('LC001', 'C00001', 20000.00, 1, 100.00, '2026-01-01', '2026-02-01', 'Active', 'Pending');

INSERT INTO PaymentSchedule (LC, dueDate, monthlyPayment, principal, interest, service, balance, action)
VALUES ('LC001', '2026-02-01', 300.00, 199.00, 100.00, 1.00, 19800.00, 'Pending');
