IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Guinchos] (
    [Id] int NOT NULL IDENTITY,
    [Porte] nvarchar(max) NOT NULL,
    [Status] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Guinchos] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Pneus] (
    [Id] int NOT NULL IDENTITY,
    [Aro] int NOT NULL,
    [Quantidade] int NOT NULL,
    CONSTRAINT [PK_Pneus] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210513225144_AdicionaTabelas', N'5.0.6');
GO

COMMIT;
GO

