

IF NOT EXISTS (select * from sys.sysobjects where name = 'Patient')
BEGIN
CREATE TABLE Patient(
	PatientID	INT NOT NULL IDENTITY(1,1),
	FirstName	varchar(200),
	LastName	VARCHAR(200),
	MedicalHistory VARCHAR(MAX),
	Gender VARCHAR(1),
	Telephone VARCHAR(20),
	EmergencyContactTelephone VARCHAR(20),
	BirthDay DATE,
	CONSTRAINT PK_Patient PRIMARY KEY CLUSTERED (PatientID)
)
END



IF NOT EXISTS (select * from sys.sysobjects where name = 'OrderType')
BEGIN
CREATE TABLE OrderType(
	OrderTypeID	INT NOT NULL IDENTITY(1,1),	
	NameType VARCHAR(200)
	CONSTRAINT PK_OrderType PRIMARY KEY CLUSTERED (OrderTypeID)
)
END

IF NOT EXISTS (select * from sys.sysobjects where name = 'OrderState')
BEGIN
CREATE TABLE OrderState(
	OrderStateID	INT NOT NULL IDENTITY(1,1),	
	NameOrderState VARCHAR(200)
	CONSTRAINT PK_OrderState PRIMARY KEY CLUSTERED (OrderStateID)
)
END

IF NOT EXISTS (select * from sys.sysobjects where name = 'OrderPriority')
BEGIN
CREATE TABLE OrderPriority(
	OrderPriorityID	INT NOT NULL IDENTITY(1,1),	
	NameOrderPriority VARCHAR(200)
	CONSTRAINT PK_OrderPriority PRIMARY KEY CLUSTERED (OrderPriorityID)
)
END

IF NOT EXISTS (select * from sys.sysobjects where name = 'OrderPatient')
BEGIN
CREATE TABLE OrderPatient(
	OrderPatientID	INT NOT NULL IDENTITY(1,1),
	Posology	varchar(MAX),
	OrderTypeID	INT,
	OrderStateID INT,
	OrderPriorityID INT,
	PatientID INT NOT NULL
	CONSTRAINT PK_OrderPatient PRIMARY KEY CLUSTERED (OrderPatientID)
)
END


ALTER TABLE OrderPatient  WITH CHECK ADD  CONSTRAINT [FK_OrderPatient_OrderType] FOREIGN KEY([OrderTypeID]) REFERENCES [OrderType] ([OrderTypeID])
ALTER TABLE OrderPatient CHECK CONSTRAINT [FK_OrderPatient_OrderType]

ALTER TABLE OrderPatient  WITH CHECK ADD  CONSTRAINT [FK_OrderPatient_Patient] FOREIGN KEY(PatientID) REFERENCES [Patient] (PatientID)
ALTER TABLE OrderPatient CHECK CONSTRAINT [FK_OrderPatient_Patient]

ALTER TABLE OrderPatient  WITH CHECK ADD  CONSTRAINT [FK_OrderPatient_OrderState] FOREIGN KEY([OrderStateID]) REFERENCES [OrderState] ([OrderStateID])
ALTER TABLE OrderPatient CHECK CONSTRAINT [FK_OrderPatient_OrderState]

ALTER TABLE OrderPatient  WITH CHECK ADD  CONSTRAINT [FK_OrderPatient_OrderPriority] FOREIGN KEY([OrderPriorityID]) REFERENCES [OrderPriority] ([OrderPriorityID])
ALTER TABLE OrderPatient CHECK CONSTRAINT [FK_OrderPatient_OrderPriority]



---------------

CREATE PROC usp_select_OrderPatient_ByPatientID

@PatientID INT

AS

SELECT [OrderPatientID]
      ,[Posology]
      ,[OrderTypeID]
      ,[OrderStateID]
      ,[OrderPriorityID]
      ,[PatientID]
  FROM [dbo].[OrderPatient]
  WHERE PatientID = @PatientID




CREATE PROC usp_insert_OrderPatient

@Posology VARCHAR(max),
@OrderTypeID INT,
@OrderStateID INT,
@OrderPriorityID INT,
@PatientID INT
AS
INSERT INTO OrderPatient
           ([Posology]
           ,[OrderTypeID]
           ,[OrderStateID]
           ,[OrderPriorityID]
           ,[PatientID])
     VALUES
           (@Posology
           ,@OrderTypeID
           ,@OrderStateID
           ,@OrderPriorityID
           ,@PatientID)
GO




CREATE PROC usp_update_OrderPatient
@OrderPatientID INT,
@Posology VARCHAR(MAX),
@OrderTypeID INT,
@OrderStateID INT,
@OrderPriorityID INT,
@PatientID INT
AS
UPDATE [dbo].[OrderPatient]
   SET [Posology] = @Posology
      ,[OrderTypeID] = @OrderTypeID
      ,[OrderStateID] = @OrderStateID
      ,[OrderPriorityID] = @OrderPriorityID
      ,[PatientID] = @PatientID
 WHERE OrderPatientID = @OrderPatientID
GO

