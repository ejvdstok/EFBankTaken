IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Klanten] (
    [KlantId] int NOT NULL IDENTITY,
    [Naam] nvarchar(max) NULL,
    CONSTRAINT [PK_Klanten] PRIMARY KEY ([KlantId])
);

GO

CREATE TABLE [Rekeningen] (
    [RekeningId] int NOT NULL IDENTITY,
    [RekeningNr] nvarchar(19) NULL,
    [KlantId] int NOT NULL,
    [Saldo] decimal(18,2) NOT NULL,
    [Soort] nvarchar(1) NOT NULL,
    CONSTRAINT [PK_Rekeningen] PRIMARY KEY ([RekeningId]),
    CONSTRAINT [FK_Rekeningen_Klanten_KlantId] FOREIGN KEY ([KlantId]) REFERENCES [Klanten] ([KlantId]) ON DELETE CASCADE
);

GO

CREATE INDEX [IX_Rekeningen_KlantId] ON [Rekeningen] ([KlantId]);

GO

CREATE UNIQUE INDEX [IX_Rekeningen_RekeningNr] ON [Rekeningen] ([RekeningNr]) WHERE [RekeningNr] IS NOT NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201113104206_Initial', N'3.1.9');

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'KlantId', N'Naam') AND [object_id] = OBJECT_ID(N'[Klanten]'))
    SET IDENTITY_INSERT [Klanten] ON;
INSERT INTO [Klanten] ([KlantId], [Naam])
VALUES (1, N'Marge'),
(2, N'Homer'),
(3, N'Lisa'),
(4, N'Maggie'),
(5, N'Bart');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'KlantId', N'Naam') AND [object_id] = OBJECT_ID(N'[Klanten]'))
    SET IDENTITY_INSERT [Klanten] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RekeningId', N'KlantId', N'RekeningNr', N'Saldo', N'Soort') AND [object_id] = OBJECT_ID(N'[Rekeningen]'))
    SET IDENTITY_INSERT [Rekeningen] ON;
INSERT INTO [Rekeningen] ([RekeningId], [KlantId], [RekeningNr], [Saldo], [Soort])
VALUES (1, 1, N'BE68 1234 5678 9012', 1000.0, N'Z');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RekeningId', N'KlantId', N'RekeningNr', N'Saldo', N'Soort') AND [object_id] = OBJECT_ID(N'[Rekeningen]'))
    SET IDENTITY_INSERT [Rekeningen] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RekeningId', N'KlantId', N'RekeningNr', N'Saldo', N'Soort') AND [object_id] = OBJECT_ID(N'[Rekeningen]'))
    SET IDENTITY_INSERT [Rekeningen] ON;
INSERT INTO [Rekeningen] ([RekeningId], [KlantId], [RekeningNr], [Saldo], [Soort])
VALUES (2, 1, N'BE68 2345 6789 0169', 2000.0, N'S');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RekeningId', N'KlantId', N'RekeningNr', N'Saldo', N'Soort') AND [object_id] = OBJECT_ID(N'[Rekeningen]'))
    SET IDENTITY_INSERT [Rekeningen] OFF;

GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RekeningId', N'KlantId', N'RekeningNr', N'Saldo', N'Soort') AND [object_id] = OBJECT_ID(N'[Rekeningen]'))
    SET IDENTITY_INSERT [Rekeningen] ON;
INSERT INTO [Rekeningen] ([RekeningId], [KlantId], [RekeningNr], [Saldo], [Soort])
VALUES (3, 2, N'BE68 3456 7890 1212', 500.0, N'S');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'RekeningId', N'KlantId', N'RekeningNr', N'Saldo', N'Soort') AND [object_id] = OBJECT_ID(N'[Rekeningen]'))
    SET IDENTITY_INSERT [Rekeningen] OFF;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20201117145852_Initial Seeding', N'3.1.9');

GO

