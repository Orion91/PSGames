CREATE TABLE [dbo].[Platforms] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [ShortName] NVARCHAR (MAX) NULL,
    [FullName]  NVARCHAR (MAX) NULL,
    [IconUrl]   NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Platforms] PRIMARY KEY CLUSTERED ([Id] ASC)
);

