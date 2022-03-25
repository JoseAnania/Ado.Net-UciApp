using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class CategoriaEquipoEquipo
    {
        public string CodEquipo { get; set; }
        public int IdCategoriaEquipo { get; set; }
        public DateTime Anio { get; set; }

        public CategoriaEquipoEquipo(string codEquipo, int idCategoriaEquipo, DateTime anio)
        {
            CodEquipo = codEquipo;
            IdCategoriaEquipo = idCategoriaEquipo;
            Anio = anio;
        }
    }
}
