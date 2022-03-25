using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Carrera
    {
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public string Edicion { get; set; }
        public int IdCategoriaCarrera { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string CodPais { get; set; }

        public Carrera(int idCarrera, string nombreCarrera, string edicion, int idCategoriaCarrera, DateTime fechaInicio, DateTime fechaFinal, string codPais)
        {
            IdCarrera = idCarrera;
            NombreCarrera = nombreCarrera;
            Edicion = edicion;
            IdCategoriaCarrera = idCategoriaCarrera;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            CodPais = codPais;
        }
    }
}
