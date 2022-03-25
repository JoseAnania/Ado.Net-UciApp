CREATE TABLE Carrera
(
idCarrera INT IDENTITY(1,1),
nombreCarrera VARCHAR(50) NOT NULL,
edicion VARCHAR(6) NULL,
idCategoriaCarrera INT,
fechaInicio SMALLDATETIME NULL,
fechaFinal SMALLDATETIME NULL,
codPais VARCHAR(3),
CONSTRAINT PK_Carrera PRIMARY KEY (idCarrera),
CONSTRAINT FK_Carrera_CategoriaCarrera FOREIGN KEY (idCategoriaCarrera) REFERENCES CategoriaCarrera (idCategoriaCarrera),
CONSTRAINT FK_Carrera_Pais FOREIGN KEY (codPais) REFERENCES Pais (codPais)
)

CREATE PROCEDURE SP_InsertarCarrera
@nombreCarrera VARCHAR(50),
@edicion VARCHAR(6),
@idCategoriaCarrera INT,
@fechaInicio SMALLDATETIME,
@fechaFinal SMALLDATETIME,
@codPais VARCHAR(3)
AS	
	BEGIN
		IF (SELECT COUNT(*) FROM Carrera WHERE nombreCarrera=@nombreCarrera)>0
		AND(SELECT COUNT(*) FROM Carrera WHERE edicion=@edicion)>0
		PRINT 'YA EXISTE ESA CARRERA'
		ELSE
		INSERT INTO Carrera(nombreCarrera, edicion, idCategoriaCarrera, fechaInicio, fechaFinal, codPais) 
		VALUES(@nombreCarrera, @edicion, @idCategoriaCarrera, @fechaInicio, @fechaFinal, UPPER(@codPais))
	END
	
EXEC SP_InsertarCarrera '', '', , '', '', ''