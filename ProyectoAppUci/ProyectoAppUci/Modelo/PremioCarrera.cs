using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class PremioCarrera
    {
        public int IdCarrera { get; set; }
        public int IdCiclista { get; set; }
        public int IdPremio { get; set; }

        public PremioCarrera(int idCarrera, int idCiclista, int idPremio)
        {
            IdCarrera = idCarrera;
            IdCiclista = idCiclista;
            IdPremio = idPremio;
        }
    }
}
