using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class CategoriaCarrera
    {
        public int IdCategoriaCarrera { get; set; }
        public string NombreCategoriaCarrera { get; set; }

        public CategoriaCarrera(int idCategoriaCarrera, string nombreCategoriaCarrera)
        {
            IdCategoriaCarrera = idCategoriaCarrera;
            NombreCategoriaCarrera = nombreCategoriaCarrera;
        }
    }
}
