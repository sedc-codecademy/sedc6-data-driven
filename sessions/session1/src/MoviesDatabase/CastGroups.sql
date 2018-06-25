CREATE TABLE [dbo].[CastGroups]
(
    [MovieId] NVARCHAR(MAX) NOT NULL, 
    [ArtistId] INT NOT NULL, 
    CONSTRAINT [PK_CastGroups] PRIMARY KEY ([MovieId], [ArtistId]) 
)
