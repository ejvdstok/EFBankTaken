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

