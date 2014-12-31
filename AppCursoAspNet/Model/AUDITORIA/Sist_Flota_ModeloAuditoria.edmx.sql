
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/09/2014 20:48:42
-- Generated from EDMX file: C:\Users\atrinidad\Documents\Backup vp\Mio\Facu\AppCursoAspNet\Model\AUDITORIA\Sist_Flota_ModeloAuditoria.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SistFlota_Auditoria];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AudGastos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AudGastos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AudGastos'
CREATE TABLE [dbo].[AudGastos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdGasto] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [HoraEmision] datetime  NULL,
    [FechaEmision] datetime  NULL,
    [TipoGasto] int  NOT NULL,
    [Vehiculo] nvarchar(max)  NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [FechayHora] datetime  NOT NULL,
    [Operacion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LogInsOuts'
CREATE TABLE [dbo].[LogInsOuts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [FechayHora] datetime  NOT NULL,
    [Operacion] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AudGastos'
ALTER TABLE [dbo].[AudGastos]
ADD CONSTRAINT [PK_AudGastos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LogInsOuts'
ALTER TABLE [dbo].[LogInsOuts]
ADD CONSTRAINT [PK_LogInsOuts]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------