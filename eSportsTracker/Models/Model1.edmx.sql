
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/09/2018 12:45:31
-- Generated from EDMX file: C:\Users\michaeap\source\repos\eSportsTracker\eSportsTracker\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [EsportsTracker];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompetesIn_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetesIn] DROP CONSTRAINT [FK_CompetesIn_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_CompetesIn_Tournament_1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CompetesIn] DROP CONSTRAINT [FK_CompetesIn_Tournament_1];
GO
IF OBJECT_ID(N'[dbo].[FK_Enters_player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enters] DROP CONSTRAINT [FK_Enters_player];
GO
IF OBJECT_ID(N'[dbo].[FK_Enters_Tournament]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Enters] DROP CONSTRAINT [FK_Enters_Tournament];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchAttribute_AttributeTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchAttribute] DROP CONSTRAINT [FK_MatchAttribute_AttributeTable];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchAttribute_Match]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchAttribute] DROP CONSTRAINT [FK_MatchAttribute_Match];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchAttribute_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchAttribute] DROP CONSTRAINT [FK_MatchAttribute_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchOf_MatchID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchOf] DROP CONSTRAINT [FK_MatchOf_MatchID];
GO
IF OBJECT_ID(N'[dbo].[FK_MatchOf_VideoGameID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MatchOf] DROP CONSTRAINT [FK_MatchOf_VideoGameID];
GO
IF OBJECT_ID(N'[dbo].[FK_Owns_OrgID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Owns] DROP CONSTRAINT [FK_Owns_OrgID];
GO
IF OBJECT_ID(N'[dbo].[FK_Owns_TeamID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Owns] DROP CONSTRAINT [FK_Owns_TeamID];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipatesIn_Match]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipatesIn] DROP CONSTRAINT [FK_ParticipatesIn_Match];
GO
IF OBJECT_ID(N'[dbo].[FK_ParticipatesIn_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ParticipatesIn] DROP CONSTRAINT [FK_ParticipatesIn_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_PartOf_MatchID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PartOf] DROP CONSTRAINT [FK_PartOf_MatchID];
GO
IF OBJECT_ID(N'[dbo].[FK_PartOf_TournamentID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PartOf] DROP CONSTRAINT [FK_PartOf_TournamentID];
GO
IF OBJECT_ID(N'[dbo].[FK_PlaysIn_MatchID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaysIn] DROP CONSTRAINT [FK_PlaysIn_MatchID];
GO
IF OBJECT_ID(N'[dbo].[FK_PlaysIn_PlayerID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaysIn] DROP CONSTRAINT [FK_PlaysIn_PlayerID];
GO
IF OBJECT_ID(N'[dbo].[FK_PlaysOn_PlayerID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaysOn] DROP CONSTRAINT [FK_PlaysOn_PlayerID];
GO
IF OBJECT_ID(N'[dbo].[FK_PlaysOn_TeamID]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PlaysOn] DROP CONSTRAINT [FK_PlaysOn_TeamID];
GO
IF OBJECT_ID(N'[dbo].[FK_SOLOMATCH_ISA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoloMatch] DROP CONSTRAINT [FK_SOLOMATCH_ISA];
GO
IF OBJECT_ID(N'[dbo].[FK_SoloMatch_LOSER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoloMatch] DROP CONSTRAINT [FK_SoloMatch_LOSER];
GO
IF OBJECT_ID(N'[dbo].[FK_SoloMatch_SoloMatch]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoloMatch] DROP CONSTRAINT [FK_SoloMatch_SoloMatch];
GO
IF OBJECT_ID(N'[dbo].[FK_SOLOMATCH_WINNER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SoloMatch] DROP CONSTRAINT [FK_SOLOMATCH_WINNER];
GO
IF OBJECT_ID(N'[dbo].[FK_SponsoredBy_Org]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SponsoredBy] DROP CONSTRAINT [FK_SponsoredBy_Org];
GO
IF OBJECT_ID(N'[dbo].[FK_SponsoredBy_Player]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SponsoredBy] DROP CONSTRAINT [FK_SponsoredBy_Player];
GO
IF OBJECT_ID(N'[dbo].[FK_TEAMMATCH_ISA]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamMatch] DROP CONSTRAINT [FK_TEAMMATCH_ISA];
GO
IF OBJECT_ID(N'[dbo].[FK_TEAMMATCH_WINNER]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamMatch] DROP CONSTRAINT [FK_TEAMMATCH_WINNER];
GO
IF OBJECT_ID(N'[dbo].[FK_TOURNAMENT_GAMEPLAYED]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tournament] DROP CONSTRAINT [FK_TOURNAMENT_GAMEPLAYED];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AttributesTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AttributesTable];
GO
IF OBJECT_ID(N'[dbo].[CompetesIn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompetesIn];
GO
IF OBJECT_ID(N'[dbo].[Enters]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Enters];
GO
IF OBJECT_ID(N'[dbo].[Match]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Match];
GO
IF OBJECT_ID(N'[dbo].[MatchAttribute]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MatchAttribute];
GO
IF OBJECT_ID(N'[dbo].[MatchOf]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MatchOf];
GO
IF OBJECT_ID(N'[dbo].[Organization]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Organization];
GO
IF OBJECT_ID(N'[dbo].[Owns]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Owns];
GO
IF OBJECT_ID(N'[dbo].[ParticipatesIn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ParticipatesIn];
GO
IF OBJECT_ID(N'[dbo].[PartOf]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PartOf];
GO
IF OBJECT_ID(N'[dbo].[Player]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Player];
GO
IF OBJECT_ID(N'[dbo].[PlaysIn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaysIn];
GO
IF OBJECT_ID(N'[dbo].[PlaysOn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlaysOn];
GO
IF OBJECT_ID(N'[dbo].[SoloMatch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SoloMatch];
GO
IF OBJECT_ID(N'[dbo].[SponsoredBy]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SponsoredBy];
GO
IF OBJECT_ID(N'[dbo].[Team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Team];
GO
IF OBJECT_ID(N'[dbo].[TeamMatch]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamMatch];
GO
IF OBJECT_ID(N'[dbo].[Tournament]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tournament];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[VideoGame]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VideoGame];
GO
IF OBJECT_ID(N'[EsportsTrackerModelStoreContainer].[MatchesView]', 'U') IS NOT NULL
    DROP TABLE [EsportsTrackerModelStoreContainer].[MatchesView];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AttributesTables'
CREATE TABLE [dbo].[AttributesTables] (
    [AttributeID] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(20)  NULL,
    [Description] varchar(50)  NULL
);
GO

-- Creating table 'Matches'
CREATE TABLE [dbo].[Matches] (
    [MatchID] int IDENTITY(1,1) NOT NULL,
    [TimePlayed] time  NOT NULL,
    [VideoGame_GameID] int  NULL
);
GO

-- Creating table 'MatchAttributes'
CREATE TABLE [dbo].[MatchAttributes] (
    [MatchID] int  NOT NULL,
    [ValueOf] nvarchar(32)  NOT NULL,
    [PlayerID] int  NOT NULL,
    [AttributeID] int  NOT NULL
);
GO

-- Creating table 'Organizations'
CREATE TABLE [dbo].[Organizations] (
    [OrgName] varchar(32)  NULL,
    [OrgID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Players'
CREATE TABLE [dbo].[Players] (
    [Handle] varchar(32)  NOT NULL,
    [DOB] datetime  NULL,
    [LName] varchar(32)  NULL,
    [FName] varchar(32)  NULL,
    [PlayerID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'PlaysIns'
CREATE TABLE [dbo].[PlaysIns] (
    [PlayerID] int  NOT NULL,
    [MatchID] int  NOT NULL,
    [Wins] bit  NOT NULL
);
GO

-- Creating table 'SoloMatches'
CREATE TABLE [dbo].[SoloMatches] (
    [MatchID] int  NOT NULL,
    [Winner] int  NULL,
    [Loser] int  NULL
);
GO

-- Creating table 'SponsoredBies'
CREATE TABLE [dbo].[SponsoredBies] (
    [PlayerID] int  NOT NULL,
    [OrgID] int  NOT NULL,
    [SponsoredByID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [TeamName] varchar(32)  NULL,
    [NumPlayers] int  NOT NULL,
    [TeamID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'TeamMatches'
CREATE TABLE [dbo].[TeamMatches] (
    [MatchID] int  NOT NULL,
    [Winner] int  NULL
);
GO

-- Creating table 'Tournaments'
CREATE TABLE [dbo].[Tournaments] (
    [TournamentDate] datetime  NOT NULL,
    [TournamentName] varchar(32)  NULL,
    [Organizer] varchar(32)  NOT NULL,
    [TournamentLocation] varchar(32)  NOT NULL,
    [TournamentID] int IDENTITY(1,1) NOT NULL,
    [VideoGamePlayed] int  NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Username] nvarchar(50)  NOT NULL,
    [PasswordSalt] varchar(50)  NOT NULL,
    [PasswordHash] varchar(50)  NOT NULL
);
GO

-- Creating table 'VideoGames'
CREATE TABLE [dbo].[VideoGames] (
    [GameName] varchar(32)  NOT NULL,
    [Released] datetime  NULL,
    [Genre] varchar(16)  NULL,
    [Developer] varchar(32)  NULL,
    [Publisher] varchar(32)  NULL,
    [GameID] int IDENTITY(1,1) NOT NULL
);
GO

-- Creating table 'MatchesViews'
CREATE TABLE [dbo].[MatchesViews] (
    [MatchID] int  NOT NULL,
    [TournamentName] varchar(32)  NULL,
    [Winner] varchar(32)  NOT NULL,
    [Loser] varchar(32)  NOT NULL,
    [GameName] varchar(32)  NOT NULL
);
GO

-- Creating table 'TournamentDetails'
CREATE TABLE [dbo].[TournamentDetails] (
    [TournamentID] int  NOT NULL,
    [Date] datetime  NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Organizer] nvarchar(max)  NULL,
    [Location] nvarchar(max)  NULL,
    [Game] nvarchar(max)  NULL,
    [Participant] nvarchar(max)  NULL
);
GO

-- Creating table 'CompetesIn'
CREATE TABLE [dbo].[CompetesIn] (
    [Teams_TeamID] int  NOT NULL,
    [Tournaments_TournamentID] int  NOT NULL
);
GO

-- Creating table 'Enters'
CREATE TABLE [dbo].[Enters] (
    [Players_PlayerID] int  NOT NULL,
    [Tournaments_TournamentID] int  NOT NULL
);
GO

-- Creating table 'Owns'
CREATE TABLE [dbo].[Owns] (
    [Organizations_OrgID] int  NOT NULL,
    [Teams_TeamID] int  NOT NULL
);
GO

-- Creating table 'ParticipatesIn'
CREATE TABLE [dbo].[ParticipatesIn] (
    [Matches_MatchID] int  NOT NULL,
    [Teams_TeamID] int  NOT NULL
);
GO

-- Creating table 'PartOf'
CREATE TABLE [dbo].[PartOf] (
    [Matches_MatchID] int  NOT NULL,
    [Tournaments_TournamentID] int  NOT NULL
);
GO

-- Creating table 'PlaysOn'
CREATE TABLE [dbo].[PlaysOn] (
    [Players_PlayerID] int  NOT NULL,
    [Teams_TeamID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [AttributeID] in table 'AttributesTables'
ALTER TABLE [dbo].[AttributesTables]
ADD CONSTRAINT [PK_AttributesTables]
    PRIMARY KEY CLUSTERED ([AttributeID] ASC);
GO

-- Creating primary key on [MatchID] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [PK_Matches]
    PRIMARY KEY CLUSTERED ([MatchID] ASC);
GO

-- Creating primary key on [MatchID], [ValueOf], [PlayerID], [AttributeID] in table 'MatchAttributes'
ALTER TABLE [dbo].[MatchAttributes]
ADD CONSTRAINT [PK_MatchAttributes]
    PRIMARY KEY CLUSTERED ([MatchID], [ValueOf], [PlayerID], [AttributeID] ASC);
GO

-- Creating primary key on [OrgID] in table 'Organizations'
ALTER TABLE [dbo].[Organizations]
ADD CONSTRAINT [PK_Organizations]
    PRIMARY KEY CLUSTERED ([OrgID] ASC);
GO

-- Creating primary key on [PlayerID] in table 'Players'
ALTER TABLE [dbo].[Players]
ADD CONSTRAINT [PK_Players]
    PRIMARY KEY CLUSTERED ([PlayerID] ASC);
GO

-- Creating primary key on [PlayerID], [MatchID] in table 'PlaysIns'
ALTER TABLE [dbo].[PlaysIns]
ADD CONSTRAINT [PK_PlaysIns]
    PRIMARY KEY CLUSTERED ([PlayerID], [MatchID] ASC);
GO

-- Creating primary key on [MatchID] in table 'SoloMatches'
ALTER TABLE [dbo].[SoloMatches]
ADD CONSTRAINT [PK_SoloMatches]
    PRIMARY KEY CLUSTERED ([MatchID] ASC);
GO

-- Creating primary key on [SponsoredByID] in table 'SponsoredBies'
ALTER TABLE [dbo].[SponsoredBies]
ADD CONSTRAINT [PK_SponsoredBies]
    PRIMARY KEY CLUSTERED ([SponsoredByID] ASC);
GO

-- Creating primary key on [TeamID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([TeamID] ASC);
GO

-- Creating primary key on [MatchID] in table 'TeamMatches'
ALTER TABLE [dbo].[TeamMatches]
ADD CONSTRAINT [PK_TeamMatches]
    PRIMARY KEY CLUSTERED ([MatchID] ASC);
GO

-- Creating primary key on [TournamentID] in table 'Tournaments'
ALTER TABLE [dbo].[Tournaments]
ADD CONSTRAINT [PK_Tournaments]
    PRIMARY KEY CLUSTERED ([TournamentID] ASC);
GO

-- Creating primary key on [Username] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Username] ASC);
GO

-- Creating primary key on [GameID] in table 'VideoGames'
ALTER TABLE [dbo].[VideoGames]
ADD CONSTRAINT [PK_VideoGames]
    PRIMARY KEY CLUSTERED ([GameID] ASC);
GO

-- Creating primary key on [MatchID], [Winner], [Loser], [GameName] in table 'MatchesViews'
ALTER TABLE [dbo].[MatchesViews]
ADD CONSTRAINT [PK_MatchesViews]
    PRIMARY KEY CLUSTERED ([MatchID], [Winner], [Loser], [GameName] ASC);
GO

-- Creating primary key on [TournamentID] in table 'TournamentDetails'
ALTER TABLE [dbo].[TournamentDetails]
ADD CONSTRAINT [PK_TournamentDetails]
    PRIMARY KEY CLUSTERED ([TournamentID] ASC);
GO

-- Creating primary key on [Teams_TeamID], [Tournaments_TournamentID] in table 'CompetesIn'
ALTER TABLE [dbo].[CompetesIn]
ADD CONSTRAINT [PK_CompetesIn]
    PRIMARY KEY CLUSTERED ([Teams_TeamID], [Tournaments_TournamentID] ASC);
GO

-- Creating primary key on [Players_PlayerID], [Tournaments_TournamentID] in table 'Enters'
ALTER TABLE [dbo].[Enters]
ADD CONSTRAINT [PK_Enters]
    PRIMARY KEY CLUSTERED ([Players_PlayerID], [Tournaments_TournamentID] ASC);
GO

-- Creating primary key on [Organizations_OrgID], [Teams_TeamID] in table 'Owns'
ALTER TABLE [dbo].[Owns]
ADD CONSTRAINT [PK_Owns]
    PRIMARY KEY CLUSTERED ([Organizations_OrgID], [Teams_TeamID] ASC);
GO

-- Creating primary key on [Matches_MatchID], [Teams_TeamID] in table 'ParticipatesIn'
ALTER TABLE [dbo].[ParticipatesIn]
ADD CONSTRAINT [PK_ParticipatesIn]
    PRIMARY KEY CLUSTERED ([Matches_MatchID], [Teams_TeamID] ASC);
GO

-- Creating primary key on [Matches_MatchID], [Tournaments_TournamentID] in table 'PartOf'
ALTER TABLE [dbo].[PartOf]
ADD CONSTRAINT [PK_PartOf]
    PRIMARY KEY CLUSTERED ([Matches_MatchID], [Tournaments_TournamentID] ASC);
GO

-- Creating primary key on [Players_PlayerID], [Teams_TeamID] in table 'PlaysOn'
ALTER TABLE [dbo].[PlaysOn]
ADD CONSTRAINT [PK_PlaysOn]
    PRIMARY KEY CLUSTERED ([Players_PlayerID], [Teams_TeamID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [AttributeID] in table 'MatchAttributes'
ALTER TABLE [dbo].[MatchAttributes]
ADD CONSTRAINT [FK_MatchAttribute_AttributeTable]
    FOREIGN KEY ([AttributeID])
    REFERENCES [dbo].[AttributesTables]
        ([AttributeID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchAttribute_AttributeTable'
CREATE INDEX [IX_FK_MatchAttribute_AttributeTable]
ON [dbo].[MatchAttributes]
    ([AttributeID]);
GO

-- Creating foreign key on [MatchID] in table 'MatchAttributes'
ALTER TABLE [dbo].[MatchAttributes]
ADD CONSTRAINT [FK_MatchAttribute_Match]
    FOREIGN KEY ([MatchID])
    REFERENCES [dbo].[Matches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MatchID] in table 'PlaysIns'
ALTER TABLE [dbo].[PlaysIns]
ADD CONSTRAINT [FK_PlaysIn_MatchID]
    FOREIGN KEY ([MatchID])
    REFERENCES [dbo].[Matches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlaysIn_MatchID'
CREATE INDEX [IX_FK_PlaysIn_MatchID]
ON [dbo].[PlaysIns]
    ([MatchID]);
GO

-- Creating foreign key on [MatchID] in table 'SoloMatches'
ALTER TABLE [dbo].[SoloMatches]
ADD CONSTRAINT [FK_SOLOMATCH_ISA]
    FOREIGN KEY ([MatchID])
    REFERENCES [dbo].[Matches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MatchID] in table 'TeamMatches'
ALTER TABLE [dbo].[TeamMatches]
ADD CONSTRAINT [FK_TEAMMATCH_ISA]
    FOREIGN KEY ([MatchID])
    REFERENCES [dbo].[Matches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PlayerID] in table 'MatchAttributes'
ALTER TABLE [dbo].[MatchAttributes]
ADD CONSTRAINT [FK_MatchAttribute_Player]
    FOREIGN KEY ([PlayerID])
    REFERENCES [dbo].[Players]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchAttribute_Player'
CREATE INDEX [IX_FK_MatchAttribute_Player]
ON [dbo].[MatchAttributes]
    ([PlayerID]);
GO

-- Creating foreign key on [OrgID] in table 'SponsoredBies'
ALTER TABLE [dbo].[SponsoredBies]
ADD CONSTRAINT [FK_SponsoredBy_Org]
    FOREIGN KEY ([OrgID])
    REFERENCES [dbo].[Organizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SponsoredBy_Org'
CREATE INDEX [IX_FK_SponsoredBy_Org]
ON [dbo].[SponsoredBies]
    ([OrgID]);
GO

-- Creating foreign key on [PlayerID] in table 'PlaysIns'
ALTER TABLE [dbo].[PlaysIns]
ADD CONSTRAINT [FK_PlaysIn_PlayerID]
    FOREIGN KEY ([PlayerID])
    REFERENCES [dbo].[Players]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Winner] in table 'SoloMatches'
ALTER TABLE [dbo].[SoloMatches]
ADD CONSTRAINT [FK_SOLOMATCH_WINNER]
    FOREIGN KEY ([Winner])
    REFERENCES [dbo].[Players]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SOLOMATCH_WINNER'
CREATE INDEX [IX_FK_SOLOMATCH_WINNER]
ON [dbo].[SoloMatches]
    ([Winner]);
GO

-- Creating foreign key on [PlayerID] in table 'SponsoredBies'
ALTER TABLE [dbo].[SponsoredBies]
ADD CONSTRAINT [FK_SponsoredBy_Player]
    FOREIGN KEY ([PlayerID])
    REFERENCES [dbo].[Players]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SponsoredBy_Player'
CREATE INDEX [IX_FK_SponsoredBy_Player]
ON [dbo].[SponsoredBies]
    ([PlayerID]);
GO

-- Creating foreign key on [Winner] in table 'TeamMatches'
ALTER TABLE [dbo].[TeamMatches]
ADD CONSTRAINT [FK_TEAMMATCH_WINNER]
    FOREIGN KEY ([Winner])
    REFERENCES [dbo].[Teams]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TEAMMATCH_WINNER'
CREATE INDEX [IX_FK_TEAMMATCH_WINNER]
ON [dbo].[TeamMatches]
    ([Winner]);
GO

-- Creating foreign key on [VideoGamePlayed] in table 'Tournaments'
ALTER TABLE [dbo].[Tournaments]
ADD CONSTRAINT [FK_TOURNAMENT_GAMEPLAYED]
    FOREIGN KEY ([VideoGamePlayed])
    REFERENCES [dbo].[VideoGames]
        ([GameID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TOURNAMENT_GAMEPLAYED'
CREATE INDEX [IX_FK_TOURNAMENT_GAMEPLAYED]
ON [dbo].[Tournaments]
    ([VideoGamePlayed]);
GO

-- Creating foreign key on [Teams_TeamID] in table 'CompetesIn'
ALTER TABLE [dbo].[CompetesIn]
ADD CONSTRAINT [FK_CompetesIn_Team]
    FOREIGN KEY ([Teams_TeamID])
    REFERENCES [dbo].[Teams]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tournaments_TournamentID] in table 'CompetesIn'
ALTER TABLE [dbo].[CompetesIn]
ADD CONSTRAINT [FK_CompetesIn_Tournament]
    FOREIGN KEY ([Tournaments_TournamentID])
    REFERENCES [dbo].[Tournaments]
        ([TournamentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompetesIn_Tournament'
CREATE INDEX [IX_FK_CompetesIn_Tournament]
ON [dbo].[CompetesIn]
    ([Tournaments_TournamentID]);
GO

-- Creating foreign key on [Players_PlayerID] in table 'Enters'
ALTER TABLE [dbo].[Enters]
ADD CONSTRAINT [FK_Enters_Player]
    FOREIGN KEY ([Players_PlayerID])
    REFERENCES [dbo].[Players]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tournaments_TournamentID] in table 'Enters'
ALTER TABLE [dbo].[Enters]
ADD CONSTRAINT [FK_Enters_Tournament]
    FOREIGN KEY ([Tournaments_TournamentID])
    REFERENCES [dbo].[Tournaments]
        ([TournamentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Enters_Tournament'
CREATE INDEX [IX_FK_Enters_Tournament]
ON [dbo].[Enters]
    ([Tournaments_TournamentID]);
GO

-- Creating foreign key on [VideoGame_GameID] in table 'Matches'
ALTER TABLE [dbo].[Matches]
ADD CONSTRAINT [FK_MatchOf]
    FOREIGN KEY ([VideoGame_GameID])
    REFERENCES [dbo].[VideoGames]
        ([GameID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MatchOf'
CREATE INDEX [IX_FK_MatchOf]
ON [dbo].[Matches]
    ([VideoGame_GameID]);
GO

-- Creating foreign key on [Organizations_OrgID] in table 'Owns'
ALTER TABLE [dbo].[Owns]
ADD CONSTRAINT [FK_Owns_Organization]
    FOREIGN KEY ([Organizations_OrgID])
    REFERENCES [dbo].[Organizations]
        ([OrgID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teams_TeamID] in table 'Owns'
ALTER TABLE [dbo].[Owns]
ADD CONSTRAINT [FK_Owns_Team]
    FOREIGN KEY ([Teams_TeamID])
    REFERENCES [dbo].[Teams]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Owns_Team'
CREATE INDEX [IX_FK_Owns_Team]
ON [dbo].[Owns]
    ([Teams_TeamID]);
GO

-- Creating foreign key on [Matches_MatchID] in table 'ParticipatesIn'
ALTER TABLE [dbo].[ParticipatesIn]
ADD CONSTRAINT [FK_ParticipatesIn_Match]
    FOREIGN KEY ([Matches_MatchID])
    REFERENCES [dbo].[Matches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teams_TeamID] in table 'ParticipatesIn'
ALTER TABLE [dbo].[ParticipatesIn]
ADD CONSTRAINT [FK_ParticipatesIn_Team]
    FOREIGN KEY ([Teams_TeamID])
    REFERENCES [dbo].[Teams]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParticipatesIn_Team'
CREATE INDEX [IX_FK_ParticipatesIn_Team]
ON [dbo].[ParticipatesIn]
    ([Teams_TeamID]);
GO

-- Creating foreign key on [Matches_MatchID] in table 'PartOf'
ALTER TABLE [dbo].[PartOf]
ADD CONSTRAINT [FK_PartOf_Match]
    FOREIGN KEY ([Matches_MatchID])
    REFERENCES [dbo].[Matches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Tournaments_TournamentID] in table 'PartOf'
ALTER TABLE [dbo].[PartOf]
ADD CONSTRAINT [FK_PartOf_Tournament]
    FOREIGN KEY ([Tournaments_TournamentID])
    REFERENCES [dbo].[Tournaments]
        ([TournamentID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PartOf_Tournament'
CREATE INDEX [IX_FK_PartOf_Tournament]
ON [dbo].[PartOf]
    ([Tournaments_TournamentID]);
GO

-- Creating foreign key on [Players_PlayerID] in table 'PlaysOn'
ALTER TABLE [dbo].[PlaysOn]
ADD CONSTRAINT [FK_PlaysOn_Player]
    FOREIGN KEY ([Players_PlayerID])
    REFERENCES [dbo].[Players]
        ([PlayerID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Teams_TeamID] in table 'PlaysOn'
ALTER TABLE [dbo].[PlaysOn]
ADD CONSTRAINT [FK_PlaysOn_Team]
    FOREIGN KEY ([Teams_TeamID])
    REFERENCES [dbo].[Teams]
        ([TeamID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlaysOn_Team'
CREATE INDEX [IX_FK_PlaysOn_Team]
ON [dbo].[PlaysOn]
    ([Teams_TeamID]);
GO

-- Creating foreign key on [MatchID] in table 'SoloMatches'
ALTER TABLE [dbo].[SoloMatches]
ADD CONSTRAINT [FK_SoloMatch_LOSER]
    FOREIGN KEY ([MatchID])
    REFERENCES [dbo].[SoloMatches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [MatchID] in table 'SoloMatches'
ALTER TABLE [dbo].[SoloMatches]
ADD CONSTRAINT [FK_SoloMatch_SoloMatch]
    FOREIGN KEY ([MatchID])
    REFERENCES [dbo].[SoloMatches]
        ([MatchID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------