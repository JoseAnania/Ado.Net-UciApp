CREATE TABLE Ciclista
(
idCiclista INT IDENTITY(1,1),
nombreCiclista VARCHAR(50) NOT NULL,
apellidoCiclista VARCHAR(50) NOT NULL,
fechaNacimiento SMALLDATETIME NULL,
codPais VARCHAR(3),
CONSTRAINT PK_Ciclista PRIMARY KEY (idCiclista),
CONSTRAINT FK_Ciclista_Pais FOREIGN KEY (codPais) REFERENCES Pais (codPais)
)

CREATE PROCEDURE SP_InsertarCiclista
@nombreCiclista VARCHAR(50),
@apellidoCiclista VARCHAR(50),
@fechaNacimiento SMALLDATETIME,
@codPais VARCHAR(3)
AS	
	BEGIN
		IF (SELECT COUNT(*) FROM Ciclista WHERE nombreCiclista=@nombreCiclista)>0
		AND(SELECT COUNT(*) FROM Ciclista WHERE apellidoCiclista=@apellidoCiclista)>0
		PRINT 'YA EXISTE ESE CICLISTA'
		ELSE
		INSERT INTO Ciclista(nombreCiclista, apellidoCiclista, fechaNacimiento, codPais) 
		VALUES(@nombreCiclista, UPPER(@apellidoCiclista), @fechaNacimiento, UPPER(@codPais))
	END
	
EXEC SP_InsertarCiclista '', '', '', ''