CREATE TABLE [dbo].[Entry] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (MAX) NOT NULL,
    [Description] NVARCHAR (MAX) NOT NULL,
    [Path]        NVARCHAR (MAX) NOT NULL,
    [Date]        NVARCHAR (50)  NOT NULL,
    [Age_rating]  NVARCHAR (50)  NOT NULL,
    [Genres]      NVARCHAR (MAX) NULL,
    [Score]       NVARCHAR (MAX) NULL,
    [Duration]    NVARCHAR (50)  NULL,
    [Note]        NVARCHAR (MAX) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Genres] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Genre] NVARCHAR (30) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Entry_has_genre] (
    [Id]      INT           IDENTITY (1, 1) NOT NULL,
    [EntryID] NVARCHAR (10) NOT NULL,
    [GenreID] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);