USE [DB_A1380A_reserva]
GO
CREATE USER [DB_A1380A_reserva_admin] FOR LOGIN [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER USER [DB_A1380A_reserva_admin] WITH DEFAULT_SCHEMA=[dbo]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_datareader] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_owner] ADD MEMBER [DB_A1380A_reserva_admin]
GO
USE [DB_A1380A_reserva]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [DB_A1380A_reserva_admin]
GO
