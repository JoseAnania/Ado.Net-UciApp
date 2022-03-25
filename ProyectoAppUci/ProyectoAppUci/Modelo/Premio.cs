using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Premio
    {
        public int IdPremio { get; set; }
        public string NombrePremio { get; set; }

        public Premio(int idPremio, string nombrePremio)
        {
            IdPremio = idPremio;
            NombrePremio = nombrePremio;
        }
    }
}
