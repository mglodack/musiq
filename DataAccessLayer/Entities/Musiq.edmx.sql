
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/19/2014 20:14:47
-- Generated from EDMX file: C:\Users\Glodack\Desktop\musiq\DataAccessLayer\Entities\Musiq.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_SongPlays_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongPlays] DROP CONSTRAINT [FK_SongPlays_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_SongPlays_Songs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongPlays] DROP CONSTRAINT [FK_SongPlays_Songs];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountAccount_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountAccount] DROP CONSTRAINT [FK_AccountAccount_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountAccount_Accounts1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountAccount] DROP CONSTRAINT [FK_AccountAccount_Accounts1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountPlaylist_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountPlaylist] DROP CONSTRAINT [FK_AccountPlaylist_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountPlaylist_Playlists]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountPlaylist] DROP CONSTRAINT [FK_AccountPlaylist_Playlists];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountSong_Accounts]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSong] DROP CONSTRAINT [FK_AccountSong_Accounts];
GO
IF OBJECT_ID(N'[dbo].[FK_AccountSong_Songs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccountSong] DROP CONSTRAINT [FK_AccountSong_Songs];
GO
IF OBJECT_ID(N'[dbo].[FK_SongPlaylist_Playlists]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongPlaylist] DROP CONSTRAINT [FK_SongPlaylist_Playlists];
GO
IF OBJECT_ID(N'[dbo].[FK_SongPlaylist_Songs]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SongPlaylist] DROP CONSTRAINT [FK_SongPlaylist_Songs];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Accounts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Accounts];
GO
IF OBJECT_ID(N'[dbo].[Playlists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Playlists];
GO
IF OBJECT_ID(N'[dbo].[SongPlays]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongPlays];
GO
IF OBJECT_ID(N'[dbo].[Songs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Songs];
GO
IF OBJECT_ID(N'[dbo].[AccountAccount]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountAccount];
GO
IF OBJECT_ID(N'[dbo].[AccountPlaylist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountPlaylist];
GO
IF OBJECT_ID(N'[dbo].[AccountSong]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccountSong];
GO
IF OBJECT_ID(N'[dbo].[SongPlaylist]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SongPlaylist];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Accounts'
CREATE TABLE [dbo].[Accounts] (
    [AccountId] int IDENTITY(1,1) NOT NULL,
    [Username] nvarchar(max)  NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [ProfilePicURL] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Playlists'
CREATE TABLE [dbo].[Playlists] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SongPlays'
CREATE TABLE [dbo].[SongPlays] (
    [AccountId] int  NOT NULL,
    [SongId] int  NOT NULL,
    [NumberOfPlays] int  NOT NULL,
    [DatePlayed] datetime  NOT NULL
);
GO

-- Creating table 'Songs'
CREATE TABLE [dbo].[Songs] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Length] nvarchar(max)  NOT NULL,
    [FilePath] nvarchar(max)  NOT NULL,
    [Artist] nvarchar(max)  NOT NULL,
    [Genre] nvarchar(max)  NOT NULL,
    [Album] nvarchar(max)  NOT NULL,
    [isAdded] bit  NOT NULL,
    [NumberOfPlays] int  NOT NULL,
    [ArtworkURL] nvarchar(max)  NULL
);
GO

-- Creating table 'AccountAccount'
CREATE TABLE [dbo].[AccountAccount] (
    [Followers_AccountId] int  NOT NULL,
    [Following_AccountId] int  NOT NULL
);
GO

-- Creating table 'AccountPlaylist'
CREATE TABLE [dbo].[AccountPlaylist] (
    [Accounts_AccountId] int  NOT NULL,
    [Playlists_Id] int  NOT NULL
);
GO

-- Creating table 'AccountSong'
CREATE TABLE [dbo].[AccountSong] (
    [Accounts_AccountId] int  NOT NULL,
    [Songs_Id] int  NOT NULL
);
GO

-- Creating table 'SongPlaylist'
CREATE TABLE [dbo].[SongPlaylist] (
    [Playlists_Id] int  NOT NULL,
    [Songs_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AccountId] in table 'Accounts'
ALTER TABLE [dbo].[Accounts]
ADD CONSTRAINT [PK_Accounts]
    PRIMARY KEY CLUSTERED ([AccountId] ASC);
GO

-- Creating primary key on [Id] in table 'Playlists'
ALTER TABLE [dbo].[Playlists]
ADD CONSTRAINT [PK_Playlists]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [AccountId], [SongId] in table 'SongPlays'
ALTER TABLE [dbo].[SongPlays]
ADD CONSTRAINT [PK_SongPlays]
    PRIMARY KEY CLUSTERED ([AccountId], [SongId] ASC);
GO

-- Creating primary key on [Id] in table 'Songs'
ALTER TABLE [dbo].[Songs]
ADD CONSTRAINT [PK_Songs]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Followers_AccountId], [Following_AccountId] in table 'AccountAccount'
ALTER TABLE [dbo].[AccountAccount]
ADD CONSTRAINT [PK_AccountAccount]
    PRIMARY KEY CLUSTERED ([Followers_AccountId], [Following_AccountId] ASC);
GO

-- Creating primary key on [Accounts_AccountId], [Playlists_Id] in table 'AccountPlaylist'
ALTER TABLE [dbo].[AccountPlaylist]
ADD CONSTRAINT [PK_AccountPlaylist]
    PRIMARY KEY CLUSTERED ([Accounts_AccountId], [Playlists_Id] ASC);
GO

-- Creating primary key on [Accounts_AccountId], [Songs_Id] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [PK_AccountSong]
    PRIMARY KEY CLUSTERED ([Accounts_AccountId], [Songs_Id] ASC);
GO

-- Creating primary key on [Playlists_Id], [Songs_Id] in table 'SongPlaylist'
ALTER TABLE [dbo].[SongPlaylist]
ADD CONSTRAINT [PK_SongPlaylist]
    PRIMARY KEY CLUSTERED ([Playlists_Id], [Songs_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AccountId] in table 'SongPlays'
ALTER TABLE [dbo].[SongPlays]
ADD CONSTRAINT [FK_SongPlays_Accounts]
    FOREIGN KEY ([AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SongId] in table 'SongPlays'
ALTER TABLE [dbo].[SongPlays]
ADD CONSTRAINT [FK_SongPlays_Songs]
    FOREIGN KEY ([SongId])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongPlays_Songs'
CREATE INDEX [IX_FK_SongPlays_Songs]
ON [dbo].[SongPlays]
    ([SongId]);
GO

-- Creating foreign key on [Followers_AccountId] in table 'AccountAccount'
ALTER TABLE [dbo].[AccountAccount]
ADD CONSTRAINT [FK_AccountAccount_Accounts]
    FOREIGN KEY ([Followers_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Following_AccountId] in table 'AccountAccount'
ALTER TABLE [dbo].[AccountAccount]
ADD CONSTRAINT [FK_AccountAccount_Accounts1]
    FOREIGN KEY ([Following_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountAccount_Accounts1'
CREATE INDEX [IX_FK_AccountAccount_Accounts1]
ON [dbo].[AccountAccount]
    ([Following_AccountId]);
GO

-- Creating foreign key on [Accounts_AccountId] in table 'AccountPlaylist'
ALTER TABLE [dbo].[AccountPlaylist]
ADD CONSTRAINT [FK_AccountPlaylist_Accounts]
    FOREIGN KEY ([Accounts_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Playlists_Id] in table 'AccountPlaylist'
ALTER TABLE [dbo].[AccountPlaylist]
ADD CONSTRAINT [FK_AccountPlaylist_Playlists]
    FOREIGN KEY ([Playlists_Id])
    REFERENCES [dbo].[Playlists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountPlaylist_Playlists'
CREATE INDEX [IX_FK_AccountPlaylist_Playlists]
ON [dbo].[AccountPlaylist]
    ([Playlists_Id]);
GO

-- Creating foreign key on [Accounts_AccountId] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [FK_AccountSong_Accounts]
    FOREIGN KEY ([Accounts_AccountId])
    REFERENCES [dbo].[Accounts]
        ([AccountId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Songs_Id] in table 'AccountSong'
ALTER TABLE [dbo].[AccountSong]
ADD CONSTRAINT [FK_AccountSong_Songs]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccountSong_Songs'
CREATE INDEX [IX_FK_AccountSong_Songs]
ON [dbo].[AccountSong]
    ([Songs_Id]);
GO

-- Creating foreign key on [Playlists_Id] in table 'SongPlaylist'
ALTER TABLE [dbo].[SongPlaylist]
ADD CONSTRAINT [FK_SongPlaylist_Playlists]
    FOREIGN KEY ([Playlists_Id])
    REFERENCES [dbo].[Playlists]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Songs_Id] in table 'SongPlaylist'
ALTER TABLE [dbo].[SongPlaylist]
ADD CONSTRAINT [FK_SongPlaylist_Songs]
    FOREIGN KEY ([Songs_Id])
    REFERENCES [dbo].[Songs]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_SongPlaylist_Songs'
CREATE INDEX [IX_FK_SongPlaylist_Songs]
ON [dbo].[SongPlaylist]
    ([Songs_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------