-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Usuario]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioGrupo] DROP CONSTRAINT [FK_UsuarioGrupo_Usuario];

IF OBJECT_ID(N'[dbo].[FK_UsuarioGrupo_Grupo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UsuarioGrupo] DROP CONSTRAINT [FK_UsuarioGrupo_Grupo];

IF OBJECT_ID(N'[dbo].[FK_GrupoPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_GrupoPerfil];

IF OBJECT_ID(N'[dbo].[FK_PerfilPermiso]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_PerfilPermiso];

IF OBJECT_ID(N'[dbo].[FK_FormularioPerfil]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Perfiles] DROP CONSTRAINT [FK_FormularioPerfil];


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Permisos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permisos];

IF OBJECT_ID(N'[dbo].[Perfiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Perfiles];

IF OBJECT_ID(N'[dbo].[Formularios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Formularios];

IF OBJECT_ID(N'[dbo].[Grupos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Grupos];

IF OBJECT_ID(N'[dbo].[Usuarios]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Usuarios];

IF OBJECT_ID(N'[dbo].[UsuarioGrupo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsuarioGrupo];


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Permisos'
CREATE TABLE [dbo].[Permisos] (
    [IDPermiso] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);


-- Creating table 'Perfiles'
CREATE TABLE [dbo].[Perfiles] (
    [IDPerfil] int IDENTITY(1,1) NOT NULL,
    [Grupo_IDGrupo] nvarchar(50)  NOT NULL,
    [Permiso_IDPermiso] nvarchar(50)  NOT NULL,
    [Formulario_IDFormulario] nvarchar(50)  NOT NULL
);


-- Creating table 'Formularios'
CREATE TABLE [dbo].[Formularios] (
    [IDFormulario] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);


-- Creating table 'Grupos'
CREATE TABLE [dbo].[Grupos] (
    [IDGrupo] nvarchar(50)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);


-- Creating table 'Usuarios'
CREATE TABLE [dbo].[Usuarios] (
    [IDUsuario] nvarchar(50)  NOT NULL,
    [NombreApellido] nvarchar(max)  NOT NULL,
    [Contraseña] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Habilitado] bit  NOT NULL,
    [Activo] bit  NOT NULL,
    [PrimeraVez] bit  NOT NULL
);


-- Creating table 'UsuarioGrupo'
CREATE TABLE [dbo].[UsuarioGrupo] (
    [Usuario_IDUsuario] nvarchar(50)  NOT NULL,
    [Grupo_IDGrupo] nvarchar(50)  NOT NULL
);


-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IDPermiso] in table 'Permisos'
ALTER TABLE [dbo].[Permisos]
ADD CONSTRAINT [PK_Permisos]
    PRIMARY KEY CLUSTERED ([IDPermiso] ASC);


-- Creating primary key on [IDPerfil] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [PK_Perfiles]
    PRIMARY KEY CLUSTERED ([IDPerfil] ASC);


-- Creating primary key on [IDFormulario] in table 'Formularios'
ALTER TABLE [dbo].[Formularios]
ADD CONSTRAINT [PK_Formularios]
    PRIMARY KEY CLUSTERED ([IDFormulario] ASC);


-- Creating primary key on [IDGrupo] in table 'Grupos'
ALTER TABLE [dbo].[Grupos]
ADD CONSTRAINT [PK_Grupos]
    PRIMARY KEY CLUSTERED ([IDGrupo] ASC);


-- Creating primary key on [IDUsuario] in table 'Usuarios'
ALTER TABLE [dbo].[Usuarios]
ADD CONSTRAINT [PK_Usuarios]
    PRIMARY KEY CLUSTERED ([IDUsuario] ASC);


-- Creating primary key on [Usuario_IDUsuario], [Grupo_IDGrupo] in table 'UsuarioGrupo'
ALTER TABLE [dbo].[UsuarioGrupo]
ADD CONSTRAINT [PK_UsuarioGrupo]
    PRIMARY KEY CLUSTERED ([Usuario_IDUsuario], [Grupo_IDGrupo] ASC);


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


-- Creating foreign key on [Grupo_IDGrupo] in table 'UsuarioGrupo'
ALTER TABLE [dbo].[UsuarioGrupo]
ADD CONSTRAINT [FK_UsuarioGrupo_Grupo]
    FOREIGN KEY ([Grupo_IDGrupo])
    REFERENCES [dbo].[Grupos]
        ([IDGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_UsuarioGrupo_Grupo'
CREATE INDEX [IX_FK_UsuarioGrupo_Grupo]
ON [dbo].[UsuarioGrupo]
    ([Grupo_IDGrupo]);


-- Creating foreign key on [Grupo_IDGrupo] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_GrupoPerfil]
    FOREIGN KEY ([Grupo_IDGrupo])
    REFERENCES [dbo].[Grupos]
        ([IDGrupo])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_GrupoPerfil'
CREATE INDEX [IX_FK_GrupoPerfil]
ON [dbo].[Perfiles]
    ([Grupo_IDGrupo]);


-- Creating foreign key on [Permiso_IDPermiso] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_PerfilPermiso]
    FOREIGN KEY ([Permiso_IDPermiso])
    REFERENCES [dbo].[Permisos]
        ([IDPermiso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_PerfilPermiso'
CREATE INDEX [IX_FK_PerfilPermiso]
ON [dbo].[Perfiles]
    ([Permiso_IDPermiso]);


-- Creating foreign key on [Formulario_IDFormulario] in table 'Perfiles'
ALTER TABLE [dbo].[Perfiles]
ADD CONSTRAINT [FK_FormularioPerfil]
    FOREIGN KEY ([Formulario_IDFormulario])
    REFERENCES [dbo].[Formularios]
        ([IDFormulario])
    ON DELETE NO ACTION ON UPDATE NO ACTION;


-- Creating non-clustered index for FOREIGN KEY 'FK_FormularioPerfil'
CREATE INDEX [IX_FK_FormularioPerfil]
ON [dbo].[Perfiles]
    ([Formulario_IDFormulario]);


-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------