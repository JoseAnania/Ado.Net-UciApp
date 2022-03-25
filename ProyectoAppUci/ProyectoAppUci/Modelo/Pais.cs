using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Pais
    {
        public string CodPais { get; set; }
        public string NombrePais { get; set; }

        public Pais(string codPais, string nombrePais)
        {
            CodPais = codPais;
            NombrePais = nombrePais;
        }
    }
}
