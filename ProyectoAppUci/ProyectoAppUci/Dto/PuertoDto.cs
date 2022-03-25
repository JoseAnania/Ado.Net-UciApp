using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class PuertoDto
    {
        public int IdPuerto { get; set; }
        public string NombrePuerto { get; set; }
        public int Altura { get; set; }
        public string nombreCategoriaPuerto { get; set; }

        public PuertoDto(int idPuerto, string nombrePuerto, int altura, string nombreCategoriaPuerto)
        {
            IdPuerto = idPuerto;
            NombrePuerto = nombrePuerto;
            Altura = altura;
            this.nombreCategoriaPuerto = nombreCategoriaPuerto;
        }
    }
}
