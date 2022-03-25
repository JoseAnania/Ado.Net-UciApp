using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class PremioCarreraDto
    {
        public string NombreCarrera { get; set; }
        public string ApeNomCiclista { get; set; }
        public string NombrePremio { get; set; }

        public PremioCarreraDto(string nombreCarrera, string apeNomCiclista, string nombrePremio)
        {
            NombreCarrera = nombreCarrera;
            ApeNomCiclista = apeNomCiclista;
            NombrePremio = nombrePremio;
        }
    }
}
