using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class CategoriaPuerto
    {
        public int IdCategoriaPuerto { get; set; }
        public string NombreCategoriaPuerto { get; set; }

        public CategoriaPuerto(int idCategoriaPuerto, string nombreCategoriaPuerto)
        {
            IdCategoriaPuerto = idCategoriaPuerto;
            NombreCategoriaPuerto = nombreCategoriaPuerto;
        }
    }   
}
