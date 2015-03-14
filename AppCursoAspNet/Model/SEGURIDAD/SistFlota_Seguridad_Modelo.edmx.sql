
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/13/2015 14:33:34
-- Generated from EDMX file: C:\Users\Windows 7\Documents\GitHub\proyecto-flota-online\AppCursoAspNet\Model\SEGURIDAD\SistFlota_Seguridad_Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SistFlota_Seguridad];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioGrupo] DROP CONSTRAINT [FK_UsuarioGrupo_Usuario];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Grupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioGrupo] DROP CONSTRAINT [FK_UsuarioGrupo_Grupo];
GO
IF OBJECT_ID(N'[dbo].[FK_GrupoPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_GrupoPerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_PerfilPermiso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_PerfilPermiso];
GO
IF OBJECT_ID(N'[dbo].[FK_FormularioPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_FormularioPerfil];
GO
IF OBJECT_ID(N'[dbo].[FK_UsuarioFlota]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Usuarios] DROP CONSTRAINT [FK_UsuarioFlota];
GO
IF OBJECT_ID(N'[dbo].[FK_FlotaLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licencias] DROP CONSTRAINT [FK_FlotaLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_LicenciaTipoLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licencias] DROP CONSTRAINT [FK_LicenciaTipoLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_Demo_inherits_TipoLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tiposdelicencia_Demo] DROP CONSTRAINT [FK_Demo_inherits_TipoLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_Premium_inherits_TipoLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tiposdelicencia_Premium] DROP CONSTRAINT [FK_Premium_inherits_TipoLicencia];
GO
IF OBJECT_ID(N'[dbo].[FK_Basica_inherits_TipoLicencia]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tiposdelicencia_Basica] DROP CONSTRAINT [FK_Basica_inherits_TipoLicencia];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Permisos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permisos];
GO
IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];
GO
IF OBJECT_ID(N'[dbo].[Formularios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formularios];
GO
IF OBJECT_ID(N'[dbo].[Grupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grupos];
GO
IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];
GO
IF OBJECT_ID(N'[dbo].[Flotas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Flotas];
GO
IF OBJECT_ID(N'[dbo].[Tiposdelicencia]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tiposdelicencia];
GO
IF OBJECT_ID(N'[dbo].[Licencias]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licencias];
GO
IF OBJECT_ID(N'[dbo].[Tiposdelicencia_Demo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tiposdelicencia_Demo];
GO
IF OBJECT_ID(N'[dbo].[Tiposdelicencia_Premium]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tiposdelicencia_Premium];
GO
IF OBJECT_ID(N'[dbo].[Tiposdelicencia_Basica]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tiposdelicencia_Basica];
GO
IF OBJECT_ID(N'[dbo].[UsuarioGrupo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioGrupo];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Permisos'
CREATE TABLE [dbo].[Permisos] (
    [IDPermiso] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [IDPerfil] int IDENTITY(1,1) NOT NULL,
    [Grupo_IDGrupo] nvarchar(50)  NOT NULL,
    [Permiso_IDPermiso] nvarchar(50)  NOT NULL,
    [Formulario_IDFormulario] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Formularios'
CREATE TABLE [dbo].[Formularios] (
    [IDFormulario] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Grupos'
CREATE TABLE [dbo].[Grupos] (
    [IDGrupo] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [IDUsuario] nvarchar(50)  NOT NULL,
    [NombreApellido] nvarchar(max)  NOT NULL,
    [Contraseña] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Habilitado] bit  NOT NULL,
    [Online] bit  NOT NULL,
    [PrimeraVez] bit  NOT NULL,
    [Activo] smallint  NOT NULL,
    [Flota_Id] int  NOT NULL
);
GO

-- Creating table 'Flotas'
CREATE TABLE [dbo].[Flotas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RazonSocial] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Tiposdelicencia'
CREATE TABLE [dbo].[Tiposdelicencia] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Duracion] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Activo] smallint  NOT NULL
);
GO

-- Creating table 'Licencias'
CREATE TABLE [dbo].[Licencias] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FechaInicio] datetime  NOT NULL,
    [FechaFin] datetime  NOT NULL,
    [FechaPago] datetime  NULL,
    [NroTransaccion] nvarchar(max)  NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [Flota_Id] int  NOT NULL,
    [TipoLicencia_Id] int  NOT NULL
);
GO

-- Creating table 'Tiposdelicencia_Demo'
CREATE TABLE [dbo].[Tiposdelicencia_Demo] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'Tiposdelicencia_Premium'
CREATE TABLE [dbo].[Tiposdelicencia_Premium] (
    [CantUsuarios] int  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'Tiposdelicencia_Basica'
CREATE TABLE [dbo].[Tiposdelicencia_Basica] (
    [Patrocinador] nvarchar(max)  NOT NULL,
    [Precio] decimal(18,0)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'UsuarioGrupo'
CREATE TABLE [dbo].[UsuarioGrupo] (
    [Usuario_IDUsuario] nvarchar(50)  NOT NULL,
    [Grupo_IDGrupo] nvarchar(50)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDPermiso] in table 'Permisos'
ALTER TABLE [dbo].[Permisos]
ADD CONSTRAINT [PK_Permisos]
    PRIMARY KEY CLUSTERED ([IDPermiso] ASC);
GO

-- Creating primary key on [IDPerfil] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([IDPerfil] ASC);
GO

-- Creating primary key on [IDFormulario] in table 'Formularios'
ALTER TABLE [dbo].[Formularios]
ADD CONSTRAINT [PK_Formularios]
    PRIMARY KEY CLUSTERED ([IDFormulario] ASC);
GO

-- Creating primary key on [IDGrupo] in table 'Grupos'
ALTER TABLE [dbo].[Grupos]
ADD CONSTRAINT [PK_Grupos]
    PRIMARY KEY CLUSTERED ([IDGrupo] ASC);
GO

-- Creating primary key on [IDUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([IDUsuario] ASC);
GO

-- Creating primary key on [Id] in table 'Flotas'
ALTER TABLE [dbo].[Flotas]
ADD CONSTRAINT [PK_Flotas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tiposdelicencia'
ALTER TABLE [dbo].[Tiposdelicencia]
ADD CONSTRAINT [PK_Tiposdelicencia]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Licencias'
ALTER TABLE [dbo].[Licencias]
ADD CONSTRAINT [PK_Licencias]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tiposdelicencia_Demo'
ALTER TABLE [dbo].[Tiposdelicencia_Demo]
ADD CONSTRAINT [PK_Tiposdelicencia_Demo]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tiposdelicencia_Premium'
ALTER TABLE [dbo].[Tiposdelicencia_Premium]
ADD CONSTRAINT [PK_Tiposdelicencia_Premium]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Tiposdelicencia_Basica'
ALTER TABLE [dbo].[Tiposdelicencia_Basica]
ADD CONSTRAINT [PK_Tiposdelicencia_Basica]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Usuario_IDUsuario], [Grupo_IDGrupo] in table 'UsuarioGrupo'
ALTER TABLE [dbo].[UsuarioGrupo]
ADD CONSTRAINT [PK_UsuarioGrupo]
    PRIMARY KEY CLUSTERED ([Usuario_IDUsuario], [Grupo_IDGrupo] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Usuario_IDUsuario] in table 'UsuarioGrupo'
ALTER TABLE [dbo].[UsuarioGrupo]
ADD CONSTRAINT [FK_UsuarioGrupo_Usuario]
    FOREIGN KEY ([Usuario_IDUsuario])
    REFERENCES [dbo].[Usuarios]
        ([IDUsuario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Grupo_IDGrupo] in table 'UsuarioGrupo'
ALTER TABLE [dbo].[UsuarioGrupo]
ADD CONSTRAINT [FK_UsuarioGrupo_Grupo]
    FOREIGN KEY ([Grupo_IDGrupo])
    REFERENCES [dbo].[Grupos]
        ([IDGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioGrupo_Grupo'
CREATE INDEX [IX_FK_UsuarioGrupo_Grupo]
ON [dbo].[UsuarioGrupo]
    ([Grupo_IDGrupo]);
GO

-- Creating foreign key on [Grupo_IDGrupo] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_GrupoPerfil]
    FOREIGN KEY ([Grupo_IDGrupo])
    REFERENCES [dbo].[Grupos]
        ([IDGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoPerfil'
CREATE INDEX [IX_FK_GrupoPerfil]
ON [dbo].[Perfiles]
    ([Grupo_IDGrupo]);
GO

-- Creating foreign key on [Permiso_IDPermiso] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_PerfilPermiso]
    FOREIGN KEY ([Permiso_IDPermiso])
    REFERENCES [dbo].[Permisos]
        ([IDPermiso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilPermiso'
CREATE INDEX [IX_FK_PerfilPermiso]
ON [dbo].[Perfiles]
    ([Permiso_IDPermiso]);
GO

-- Creating foreign key on [Formulario_IDFormulario] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_FormularioPerfil]
    FOREIGN KEY ([Formulario_IDFormulario])
    REFERENCES [dbo].[Formularios]
        ([IDFormulario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FormularioPerfil'
CREATE INDEX [IX_FK_FormularioPerfil]
ON [dbo].[Perfiles]
    ([Formulario_IDFormulario]);
GO

-- Creating foreign key on [Flota_Id] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [FK_UsuarioFlota]
    FOREIGN KEY ([Flota_Id])
    REFERENCES [dbo].[Flotas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioFlota'
CREATE INDEX [IX_FK_UsuarioFlota]
ON [dbo].[Usuarios]
    ([Flota_Id]);
GO

-- Creating foreign key on [Flota_Id] in table 'Licencias'
ALTER TABLE [dbo].[Licencias]
ADD CONSTRAINT [FK_FlotaLicencia]
    FOREIGN KEY ([Flota_Id])
    REFERENCES [dbo].[Flotas]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FlotaLicencia'
CREATE INDEX [IX_FK_FlotaLicencia]
ON [dbo].[Licencias]
    ([Flota_Id]);
GO

-- Creating foreign key on [TipoLicencia_Id] in table 'Licencias'
ALTER TABLE [dbo].[Licencias]
ADD CONSTRAINT [FK_LicenciaTipoLicencia]
    FOREIGN KEY ([TipoLicencia_Id])
    REFERENCES [dbo].[Tiposdelicencia]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicenciaTipoLicencia'
CREATE INDEX [IX_FK_LicenciaTipoLicencia]
ON [dbo].[Licencias]
    ([TipoLicencia_Id]);
GO

-- Creating foreign key on [Id] in table 'Tiposdelicencia_Demo'
ALTER TABLE [dbo].[Tiposdelicencia_Demo]
ADD CONSTRAINT [FK_Demo_inherits_TipoLicencia]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Tiposdelicencia]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Tiposdelicencia_Premium'
ALTER TABLE [dbo].[Tiposdelicencia_Premium]
ADD CONSTRAINT [FK_Premium_inherits_TipoLicencia]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Tiposdelicencia]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'Tiposdelicencia_Basica'
ALTER TABLE [dbo].[Tiposdelicencia_Basica]
ADD CONSTRAINT [FK_Basica_inherits_TipoLicencia]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[Tiposdelicencia]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------