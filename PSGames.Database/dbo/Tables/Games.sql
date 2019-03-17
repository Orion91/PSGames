CREATE TABLE [dbo].[Games] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Title]      NVARCHAR (MAX) NULL,
    [PlatformId] INT            NULL,
    CONSTRAINT [PK_Games] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Games_Platforms_PlatformId] FOREIGN KEY ([PlatformId]) REFERENCES [dbo].[Platforms] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Games_PlatformId]
    ON [dbo].[Games]([PlatformId] ASC);

