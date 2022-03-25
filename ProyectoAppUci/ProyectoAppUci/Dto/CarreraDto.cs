using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class CarreraDto
    {
        public int IdCarrera { get; set; }
        public string NombreCarrera { get; set; }
        public string Edicion { get; set; }
        public string nombreCategoriaCarrera { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string CodPais { get; set; }

        public CarreraDto(int idCarrera, string nombreCarrera, string edicion, string nombreCategoriaCarrera, DateTime fechaInicio, DateTime fechaFinal, string codPais)
        {
            IdCarrera = idCarrera;
            NombreCarrera = nombreCarrera;
            Edicion = edicion;
            this.nombreCategoriaCarrera = nombreCategoriaCarrera;
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
            CodPais = codPais;
        }
    }
}
