
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


-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AudGastos'
ALTER TABLE [dbo].[AudGastos]
ADD CONSTRAINT [PK_AudGastos]
    PRIMARY KEY CLUSTERED ([Id] ASC);


-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------