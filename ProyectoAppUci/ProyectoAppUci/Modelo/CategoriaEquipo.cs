using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class CategoriaEquipo
    {
        public int IdCategoriaEquipo { get; set; }
        public string NombreCategoriaEquipo { get; set; }

        public CategoriaEquipo(int idCategoriaEquipo, string nombreCategoriaEquipo)
        {
            IdCategoriaEquipo = idCategoriaEquipo;
            NombreCategoriaEquipo = nombreCategoriaEquipo;
        }
    }
}
