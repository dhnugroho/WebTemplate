Create procedure [dbo].[AddEmp]    
(    
   @Name varchar (50),    
   @City varchar (50),    
   @Address varchar (50)    
)    
as    
begin    
   Insert into Employee values(@Name,@City,@Address)    
End  

CREATE TABLE [dbo].[Employee] (
    [id] INT IDENTITY (1, 1) NOT NULL,
    [Name]		             VARCHAR (50) NULL,
    [City]		             VARCHAR (50) NULL,
    [Address]               VARCHAR (50) NULL
    PRIMARY KEY CLUSTERED ([id] ASC)
);

SELECT * FROM [dbo].[Employee]
