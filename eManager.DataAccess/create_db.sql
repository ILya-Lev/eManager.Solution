PM> Update-Database -ProjectName eManager.DataAccess -Verbose
Using StartUp project 'eManager.Web'.
Specify the '-Verbose' flag to view the SQL statements being applied to the target database.
Target database is: 'eManager.Web' (DataSource: (localdb)\MSSQLLocalDB, Provider: System.Data.SqlClient, Origin: Configuration).
No pending explicit migrations.
Applying automatic migration: 201802142328413_AutomaticMigration.

CREATE TABLE [dbo].[Departments] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    CONSTRAINT [PK_dbo.Departments] PRIMARY KEY ([Id])
)
CREATE TABLE [dbo].[Employees] (
    [Id] [int] NOT NULL IDENTITY,
    [Name] [nvarchar](max),
    [Department_Id] [int],
    CONSTRAINT [PK_dbo.Employees] PRIMARY KEY ([Id])
)
CREATE INDEX [IX_Department_Id] ON [dbo].[Employees]([Department_Id])
ALTER TABLE [dbo].[Employees] ADD CONSTRAINT [FK_dbo.Employees_dbo.Departments_Department_Id] FOREIGN KEY ([Department_Id]) REFERENCES [dbo].[Departments] ([Id])
CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId] [nvarchar](150) NOT NULL,
    [ContextKey] [nvarchar](300) NOT NULL,
    [Model] [varbinary](max) NOT NULL,
    [ProductVersion] [nvarchar](32) NOT NULL,
    CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
)
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'201802142328413_AutomaticMigration', N'eManager.DataAccess.Migrations.Configuration',  ... , N'6.2.0-61023')

Running Seed method.
PM> 