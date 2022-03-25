using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Puerto
    {
        public int IdPuerto { get; set; }
        public string NombrePuerto { get; set; }
        public int Altura { get; set; }
        public int IdCategoriaPuerto { get; set; }

        public Puerto(int idPuerto, string nombrePuerto, int altura, int idCategoriaPuerto)
        {
            IdPuerto = idPuerto;
            NombrePuerto = nombrePuerto;
            Altura = altura;
            IdCategoriaPuerto = idCategoriaPuerto;
        }
    }
}
