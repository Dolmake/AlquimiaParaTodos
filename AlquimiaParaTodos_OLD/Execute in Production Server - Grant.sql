IF NOT EXISTS (SELECT name FROM sys.server_principals WHERE name = 'IIS APPPOOL\ASP.NET v4.0')
BEGIN
    CREATE LOGIN [IIS APPPOOL\ASP.NET v4.0] 
      FROM WINDOWS WITH DEFAULT_DATABASE=[master], 
      DEFAULT_LANGUAGE=[us_english]
END
GO
CREATE USER [AlquimiaUser] 
  FOR LOGIN [IIS APPPOOL\ASP.NET v4.0]
GO
EXEC sp_addrolemember 'db_owner', 'AlquimiaUser'
GO