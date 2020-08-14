/*************************** ADMIN ************************/

GO
USE SOUL_EFACT

--CREATE TABLE dbo.ADMIN (
--	ADMID INT PRIMARY KEY IDENTITY,
--	ADMUSUARIO NVARCHAR(50),
--	ADMCLAVE NVARCHAR(50),
--	ADMTIPO NVARCHAR(1),
--	ADMEMAIL NVARCHAR(50)
--)
--GO

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EFACT_ADMIN_SELECT]') AND type in (N'P', N'PC'))
   DROP PROCEDURE [dbo].[EFACT_ADMIN_SELECT] 
GO

-- =========================================================
-- Autor - Fecha Crea  : WhalyAF - 20/05/2020
-- Descripcion         : Procedimiento de Selección de la tabla ADMIN
-- Autor - Fecha Modif : 
-- Descripcion         : 
-- =========================================================
CREATE PROCEDURE [dbo].[EFACT_ADMIN_SELECT]
( @ADMUSUARIO          nvarchar(50) = NULL ) AS
BEGIN

   SELECT	ADMID		,ADMUSUARIO		,ADMCLAVE
			,ADMTIPO	,ADMEMAIL
     FROM dbo.ADMIN
	 WHERE ADMUSUARIO = ISNULL( @ADMUSUARIO, ADMUSUARIO )
END

GO

INSERT INTO dbo.ADMIN VALUES ('Administrador','Django2020','A','whaly_af@hotmail.com')
GO
