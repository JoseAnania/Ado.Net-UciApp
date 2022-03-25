CREATE DATABASE UCI	

USE UCI
----------------------------------
CREATE TABLE Pais
(
codPais VARCHAR(3) NOT NULL,
nombrePais VARCHAR(50) NOT NULL
CONSTRAINT PK_Pais PRIMARY KEY (codPais)
)
----------------------------------
CREATE TABLE CategoriaEquipo
(
idCategoriaEquipo INT IDENTITY(1,1),
nombreCategoriaEquipo VARCHAR(50) NOT NULL,
CONSTRAINT PK_CategoriaEquipo PRIMARY KEY (idCategoriaEquipo)
)
----------------------------------
CREATE TABLE CategoriaPuerto
(
idCategoriaPuerto INT IDENTITY(1,1),
nombreCategoriaPuerto VARCHAR(50) NOT NULL,
CONSTRAINT PK_CategoriaPuerto PRIMARY KEY (idCategoriaPuerto)
)
----------------------------------
CREATE TABLE CategoriaCarrera
(
idCategoriaCarrera INT IDENTITY(1,1),
nombreCategoriaCarrera VARCHAR(50) NOT NULL,
CONSTRAINT PK_CategoriaCarrera PRIMARY KEY (idCategoriaCarrera)
)
----------------------------------
CREATE TABLE TipoEtapa
(
idTipoEtapa INT IDENTITY(1,1),
nombreTipoEtapa VARCHAR(50) NOT NULL
CONSTRAINT PK_TipoEtapa PRIMARY KEY (idTipoEtapa)
)
----------------------------------
CREATE TABLE Premio
(
idPremio INT IDENTITY(1,1),
nombrePremio VARCHAR(50) NOT NULL,
CONSTRAINT PK_Premio PRIMARY KEY (idPremio)
)
----------------------------------
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
----------------------------------
CREATE TABLE Director
(
idDirector INT IDENTITY(1,1),
nombreDirector VARCHAR(50) NOT NULL,
apellidoDirector VARCHAR(50) NOT NULL,
fechaNacimiento SMALLDATETIME NULL,
codPais VARCHAR(3),
CONSTRAINT PK_Director PRIMARY KEY (idDirector),
CONSTRAINT FK_Director_Pais FOREIGN KEY (codPais) REFERENCES Pais (codPais)
)
----------------------------------
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
----------------------------------
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
----------------------------------
CREATE TABLE Equipo
(
codEquipo VARCHAR(3) NOT NULL,
nombreEquipo VARCHAR(50) NOT NULL,
codPais VARCHAR(3),
anioAlta SMALLDATETIME NULL,
anioBaja SMALLDATETIME NULL,
CONSTRAINT PK_Equipo PRIMARY KEY (codEquipo),
CONSTRAINT FK_Equipo_Pais FOREIGN KEY (codPais) REFERENCES Pais (codPais)
)
----------------------------------
CREATE TABLE DirectorEquipo
(
idDirector INT,
codEquipo VARCHAR(3) NOT NULL,
anioAlta SMALLDATETIME NULL,
anioBaja SMALLDATETIME NULL,
CONSTRAINT PK_DirectorEquipo PRIMARY KEY (idDirector, codEquipo),
CONSTRAINT FK_DirectorEquipo_Director FOREIGN KEY (idDirector) REFERENCES Director (idDirector),
CONSTRAINT FK_DirectorEquipo_Equipo FOREIGN KEY (codEquipo) REFERENCES Equipo (codEquipo)
)
----------------------------------
CREATE TABLE CiclistaEquipo
(
idCiclista INT,
codEquipo VARCHAR(3) NOT NULL,
anioAlta SMALLDATETIME NULL,
anioBaja SMALLDATETIME NULL,
CONSTRAINT PK_CiclistaEquipo PRIMARY KEY (idCiclista, codEquipo),
CONSTRAINT FK_CiclistaEquipo_Ciclista FOREIGN KEY (idCiclista) REFERENCES Ciclista (idCiclista),
CONSTRAINT FK_CiclistaEquipo_Equipo FOREIGN KEY (codEquipo) REFERENCES Equipo (codEquipo)
)
----------------------------------
CREATE TABLE ResultadoEtapa	
(
idEtapa INT,
idCiclista INT,
puestoMaillot VARCHAR(10) NOT NULL,
tiempo TIME NULL,
puntos INT,
CONSTRAINT PK_ResultadoEtapa PRIMARY KEY (idEtapa, idCiclista),
CONSTRAINT FK_ResultadoEtapa_Etapa FOREIGN KEY (idEtapa) REFERENCES Etapa (idEtapa),
CONSTRAINT FK_ResultadoEtapa_Ciclista FOREIGN KEY (idCiclista) REFERENCES Ciclista (idCiclista)
)
----------------------------------
CREATE TABLE CategoriaEquipoEquipo
(
codEquipo VARCHAR(3), 
idCategoriaEquipo INT,
anio SMALLDATETIME NULL,
CONSTRAINT PK_CategoriaEquipoEquipo PRIMARY KEY (codEquipo, idCategoriaEquipo),
CONSTRAINT FK_CategoriaEquipoEquipo_Equipo FOREIGN KEY (codEquipo) REFERENCES Equipo (codEquipo),
CONSTRAINT FK_CategoriaEquipoEquipo_CategoriaEquipo FOREIGN KEY (idCategoriaEquipo) REFERENCES CategoriaEquipo (idCategoriaEquipo)
)
----------------------------------
CREATE TABLE PremioCarrera
(
idCarrera INT,
idCiclista INT,
idPremio INT,
CONSTRAINT PK_PremioCarrera PRIMARY KEY (idCarrera, idciclista, idPremio),
CONSTRAINT FK_PremioCarrera_Carrera FOREIGN KEY (idCarrera) REFERENCES Carrera (idCarrera),
CONSTRAINT FK_PremioCarrera_Ciclista FOREIGN KEY (idCiclista) REFERENCES Ciclista (idCiclista),
CONSTRAINT FK_PremioCarrera_Premio FOREIGN KEY (idPremio) REFERENCES Premio (idPremio)
)
----------------------------------
CREATE TABLE Puerto
(
idPuerto INT IDENTITY(1,1),
idEtapa INT,
nombrePuerto VARCHAR(50) NOT NULL,
altura DECIMAL,
idCategoriaPuerto INT,
puesto INT,
idCiclista INT,
CONSTRAINT PK_Puerto PRIMARY KEY (idPuerto),
CONSTRAINT FK_Puerto_Etapa FOREIGN KEY (idEtapa) REFERENCES Etapa (idEtapa),
CONSTRAINT FK_Puerto_CategoriaPuerto FOREIGN KEY (idCategoriaPuerto) REFERENCES CategoriaPuerto (idCategoriaPuerto),
CONSTRAINT FK_Puerto_Ciclista FOREIGN KEY (idCiclista) REFERENCES Ciclista (idCiclista)
)
----------------------------------
CREATE TABLE Sprint
(
idSprint INT,
idEtapa INT,
nombreSprint VARCHAR(50) NOT NULL,
puesto INT,
idCiclista INT,
CONSTRAINT PK_Sprint PRIMARY KEY (idSprint),
CONSTRAINT FK_Sprint_Etapa FOREIGN KEY (idEtapa) REFERENCES Etapa (idEtapa),
CONSTRAINT FK_Sprint_Ciclista FOREIGN KEY (idCiclista) REFERENCES Ciclista (idCiclista)
)
----------------------------------