------------------------------------------------------------------------
-- [Users] - Registered users in our project.
------------------------------------------------------------------------
CREATE TABLE [Users]
(
	[Id] [int] NOT NULL IDENTITY (1, 1),

	-- Basic Demographic Data
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[EMail] [nvarchar](256) NULL,

	-- Audit related.
	[Created] [DateTime] DEFAULT (getutcdate()),
	[Updated] [DateTime] DEFAULT (getutcdate())
)
GO

------------------------------------------------------------------------
-- [PK_Users] - key on Id
------------------------------------------------------------------------
ALTER TABLE [Users] ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED
(
	[Id]
)
GO