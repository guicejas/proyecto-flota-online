
-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AudGastosSet'
CREATE TABLE [dbo].[AudGastosSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdGasto] int  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [Monto] decimal(18,0)  NOT NULL,
    [Estado] nvarchar(max)  NOT NULL,
    [FechaVencimiento] datetime  NOT NULL,
    [HoraEmision] datetime  NULL,
    [FechaEmision] datetime  NULL,
    [TipodeGasto] int  NOT NULL,
    [Vehiculo] nvarchar(7)  NOT NULL,
    [Usuario] nvarchar(max)  NOT NULL,
    [FechayHora] datetime  NOT NULL,
    [Operacion] nvarchar(max)  NOT NULL
);


-- Creating table 'LogInsOuts'
CREATE TABLE [dbo].[LogInsOuts] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Usuario] nvarchar(50)  NOT NULL,
    [FechayHora] datetime  NOT NULL,
    [Operacion] nvarchar(max)  NOT NULL
);


-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AudGastosSet'
ALTER TABLE [dbo].[AudGastosSet]
ADD CONSTRAINT [PK_AudGastosSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);


-- Creating primary key on [Id] in table 'LogInsOuts'
ALTER TABLE [dbo].[LogInsOuts]
ADD CONSTRAINT [PK_LogInsOuts]
    PRIMARY KEY CLUSTERED ([Id] ASC);


-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------