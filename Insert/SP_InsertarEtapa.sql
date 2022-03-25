CREATE TABLE Etapa
(
idEtapa INT IDENTITY(1,1),
idCarrera INT,
numeroEtapa INT NULL,
desde VARCHAR(50) NULL,
hasta VARCHAR(50) NULL,
idTipoEtapa INT,
fecha SMALLDATETIME NULL,
km DECIMAL NULL,
CONSTRAINT PK_Etapa PRIMARY KEY (idEtapa),
CONSTRAINT FK_Etapa_Carrera FOREIGN KEY (idCarrera) REFERENCES Carrera (idCarrera),
CONSTRAINT FK_Etapa_TipoEtapa FOREIGN KEY (idTipoEtapa) REFERENCES TipoEtapa (idTipoEtapa)
)

CREATE PROCEDURE SP_InsertarEtapa
@idCarrera INT,
@numeroEtapa INT,
@desde VARCHAR(50),
@hasta VARCHAR(50),
@idTipoEtapa INT,
@fecha SMALLDATETIME,
@km DECIMAL
AS	
	BEGIN
		IF (SELECT COUNT(*) FROM Etapa WHERE idCarrera=@idCarrera)>0
		AND(SELECT COUNT(*) FROM Etapa WHERE numeroEtapa=@numeroEtapa)>0
		PRINT 'YA EXISTE ESA Etapa'
		ELSE
		INSERT INTO Etapa(idCarrera, numeroEtapa, desde, hasta, idTipoEtapa, fecha, km) 
		VALUES(@idCarrera, @numeroEtapa, @desde, @hasta, @idTipoEtapa, @fecha, @km)
	END
	
EXEC SP_InsertarEtapa  , , '', '', , '', 