using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class PaisDto
    {
        public string CodPais { get; set; }
        public string NombrePais { get; set; }
        public string codPaisAnterior { get; set; }

        public PaisDto(string codPais, string nombrePais, string codPaisAnterior)
        {
            CodPais = codPais;
            NombrePais = nombrePais;
            this.codPaisAnterior = codPaisAnterior;
        }
    }
}
