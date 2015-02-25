
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/25/2015 12:10:01
-- Generated from EDMX file: C:\Users\Windows 7\Documents\GitHub\proyecto-flota-online\AppCursoAspNet\Model\SistFlota_ModeloDatos.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SistFlota_db];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_TipodeGastoGasto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gastos] DROP CONSTRAINT [FK_TipodeGastoGasto];
GO
IF OBJECT_ID(N'[dbo].[FK_VehiculoGasto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gastos] DROP CONSTRAINT [FK_VehiculoGasto];
GO
IF OBJECT_ID(N'[dbo].[FK_VehiculoTurno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Turnos] DROP CONSTRAINT [FK_VehiculoTurno];
GO
IF OBJECT_ID(N'[dbo].[FK_TurnoChofer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Turnos] DROP CONSTRAINT [FK_TurnoChofer];
GO
IF OBJECT_ID(N'[dbo].[FK_GastoTurno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gastos] DROP CONSTRAINT [FK_GastoTurno];
GO
IF OBJECT_ID(N'[dbo].[FK_CuentaCorrienteTurno]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaCorrientes] DROP CONSTRAINT [FK_CuentaCorrienteTurno];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpresaCuentaCorriente]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CuentaCorrientes] DROP CONSTRAINT [FK_EmpresaCuentaCorriente];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[TiposdeGasto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TiposdeGasto];
GO
IF OBJECT_ID(N'[dbo].[Gastos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gastos];
GO
IF OBJECT_ID(N'[dbo].[Vehiculos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Vehiculos];
GO
IF OBJECT_ID(N'[dbo].[Turnos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Turnos];
GO
IF OBJECT_ID(N'[dbo].[Choferes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Choferes];
GO
IF OBJECT_ID(N'[dbo].[CuentaCorrientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CuentaCorrientes];
GO
IF OBJECT_ID(N'[dbo].[Empresas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empresas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'TiposdeGasto'
CREATE TABLE [dbo].[TiposdeGasto] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Gastos'
CREATE TABLE [dbo].[Gastos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [HoraEmision] datetime  NULL,
    [FechaEmision] datetime  NULL,
    [Usuario] nvarchar(max)  NULL,
    [FechayHora] datetime  NULL,
    [Operacion] nvarchar(max)  NULL,
    [fIDFlota] int  NOT NULL,
    [Activo] smallint  NOT NULL,
    [TipodeGasto_Id] int  NOT NULL,
    [Vehiculo_Patente] nvarchar(7)  NOT NULL,
    [Turno_Id] int  NULL
);
GO

-- Creating table 'Vehiculos'
CREATE TABLE [dbo].[Vehiculos] (
    [Patente] nvarchar(7)  NOT NULL,
    [PatenteTaxi] int  NULL,
    [Marca] nvarchar(max)  NOT NULL,
    [Modelo] nvarchar(max)  NOT NULL,
    [Año] int  NOT NULL,
    [Color] nvarchar(max)  NOT NULL,
    [Kilometraje] int  NOT NULL,
    [TurnoId] int  NOT NULL,
    [fIDFlota] int  NOT NULL,
    [Activo] smallint  NOT NULL
);
GO

-- Creating table 'Turnos'
CREATE TABLE [dbo].[Turnos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [HoraInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [HoraFin] datetime  NOT NULL,
    [KmRecorridos] decimal(18,0)  NOT NULL,
    [KmOcupados] decimal(18,0)  NOT NULL,
    [CantidadViajes] int  NOT NULL,
    [RecaudacionEfectivo] decimal(18,0)  NOT NULL,
    [Comentarios] nvarchar(max)  NOT NULL,
    [GastoId] int  NULL,
    [fIDFlota] bigint  NOT NULL,
    [Activo] smallint  NOT NULL,
    [Vehiculo_Patente] nvarchar(7)  NOT NULL,
    [Chofer_Documento] int  NOT NULL
);
GO

-- Creating table 'Choferes'
CREATE TABLE [dbo].[Choferes] (
    [Documento] int  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Licencia] nvarchar(max)  NOT NULL,
    [Domicilio] nvarchar(max)  NOT NULL,
    [Localidad] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [FechaNacimiento] datetime  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [Foto] nvarchar(max)  NOT NULL,
    [fIDFlota] int  NOT NULL,
    [Activo] smallint  NOT NULL
);
GO

-- Creating table 'CuentaCorrientes'
CREATE TABLE [dbo].[CuentaCorrientes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Fecha] datetime  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [fIDFlota] int  NOT NULL,
    [Activo] smallint  NOT NULL,
    [Turno_Id] int  NOT NULL,
    [Empresa_Cuit] bigint  NOT NULL
);
GO

-- Creating table 'Empresas'
CREATE TABLE [dbo].[Empresas] (
    [Cuit] bigint  NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL,
    [Domicilio] nvarchar(max)  NOT NULL,
    [Telefono] nvarchar(max)  NOT NULL,
    [Localidad] nvarchar(max)  NOT NULL,
    [Correo] nvarchar(max)  NOT NULL,
    [fIDFlota] int  NOT NULL,
    [Activo] smallint  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'TiposdeGasto'
ALTER TABLE [dbo].[TiposdeGasto]
ADD CONSTRAINT [PK_TiposdeGasto]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Gastos'
ALTER TABLE [dbo].[Gastos]
ADD CONSTRAINT [PK_Gastos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Patente] in table 'Vehiculos'
ALTER TABLE [dbo].[Vehiculos]
ADD CONSTRAINT [PK_Vehiculos]
    PRIMARY KEY CLUSTERED ([Patente] ASC);
GO

-- Creating primary key on [Id] in table 'Turnos'
ALTER TABLE [dbo].[Turnos]
ADD CONSTRAINT [PK_Turnos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Documento] in table 'Choferes'
ALTER TABLE [dbo].[Choferes]
ADD CONSTRAINT [PK_Choferes]
    PRIMARY KEY CLUSTERED ([Documento] ASC);
GO

-- Creating primary key on [Id] in table 'CuentaCorrientes'
ALTER TABLE [dbo].[CuentaCorrientes]
ADD CONSTRAINT [PK_CuentaCorrientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Cuit] in table 'Empresas'
ALTER TABLE [dbo].[Empresas]
ADD CONSTRAINT [PK_Empresas]
    PRIMARY KEY CLUSTERED ([Cuit] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [TipodeGasto_Id] in table 'Gastos'
ALTER TABLE [dbo].[Gastos]
ADD CONSTRAINT [FK_TipodeGastoGasto]
    FOREIGN KEY ([TipodeGasto_Id])
    REFERENCES [dbo].[TiposdeGasto]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipodeGastoGasto'
CREATE INDEX [IX_FK_TipodeGastoGasto]
ON [dbo].[Gastos]
    ([TipodeGasto_Id]);
GO

-- Creating foreign key on [Vehiculo_Patente] in table 'Gastos'
ALTER TABLE [dbo].[Gastos]
ADD CONSTRAINT [FK_VehiculoGasto]
    FOREIGN KEY ([Vehiculo_Patente])
    REFERENCES [dbo].[Vehiculos]
        ([Patente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehiculoGasto'
CREATE INDEX [IX_FK_VehiculoGasto]
ON [dbo].[Gastos]
    ([Vehiculo_Patente]);
GO

-- Creating foreign key on [Vehiculo_Patente] in table 'Turnos'
ALTER TABLE [dbo].[Turnos]
ADD CONSTRAINT [FK_VehiculoTurno]
    FOREIGN KEY ([Vehiculo_Patente])
    REFERENCES [dbo].[Vehiculos]
        ([Patente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VehiculoTurno'
CREATE INDEX [IX_FK_VehiculoTurno]
ON [dbo].[Turnos]
    ([Vehiculo_Patente]);
GO

-- Creating foreign key on [Chofer_Documento] in table 'Turnos'
ALTER TABLE [dbo].[Turnos]
ADD CONSTRAINT [FK_TurnoChofer]
    FOREIGN KEY ([Chofer_Documento])
    REFERENCES [dbo].[Choferes]
        ([Documento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TurnoChofer'
CREATE INDEX [IX_FK_TurnoChofer]
ON [dbo].[Turnos]
    ([Chofer_Documento]);
GO

-- Creating foreign key on [Turno_Id] in table 'Gastos'
ALTER TABLE [dbo].[Gastos]
ADD CONSTRAINT [FK_GastoTurno]
    FOREIGN KEY ([Turno_Id])
    REFERENCES [dbo].[Turnos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GastoTurno'
CREATE INDEX [IX_FK_GastoTurno]
ON [dbo].[Gastos]
    ([Turno_Id]);
GO

-- Creating foreign key on [Turno_Id] in table 'CuentaCorrientes'
ALTER TABLE [dbo].[CuentaCorrientes]
ADD CONSTRAINT [FK_CuentaCorrienteTurno]
    FOREIGN KEY ([Turno_Id])
    REFERENCES [dbo].[Turnos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CuentaCorrienteTurno'
CREATE INDEX [IX_FK_CuentaCorrienteTurno]
ON [dbo].[CuentaCorrientes]
    ([Turno_Id]);
GO

-- Creating foreign key on [Empresa_Cuit] in table 'CuentaCorrientes'
ALTER TABLE [dbo].[CuentaCorrientes]
ADD CONSTRAINT [FK_EmpresaCuentaCorriente]
    FOREIGN KEY ([Empresa_Cuit])
    REFERENCES [dbo].[Empresas]
        ([Cuit])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpresaCuentaCorriente'
CREATE INDEX [IX_FK_EmpresaCuentaCorriente]
ON [dbo].[CuentaCorrientes]
    ([Empresa_Cuit]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------