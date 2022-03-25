using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class CatEqEqDto
    {
        public string CodEquipo { get; set; }
        public string NombreCategoriaEquipo { get; set; }
        public DateTime Anio { get; set; }

        public CatEqEqDto(string codEquipo, string nombreCategoriaEquipo, DateTime anio)
        {
            CodEquipo = codEquipo;
            NombreCategoriaEquipo = nombreCategoriaEquipo;
            Anio = anio;
        }
    }
}
