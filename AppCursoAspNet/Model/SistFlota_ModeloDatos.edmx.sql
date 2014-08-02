
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/02/2014 19:46:01
-- Generated from EDMX file: C:\Users\Admin\Documents\GitHub\proyecto-flota-online\AppCursoAspNet\Model\SistFlota_ModeloDatos.edmx
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


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
    [TurnoId] int  NOT NULL
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
    [Foto] nvarchar(max)  NOT NULL
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

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------