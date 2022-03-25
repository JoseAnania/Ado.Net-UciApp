using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class EquipoDto
    {
        public string CodEquipo { get; set; }
        public string NombreEquipo { get; set; }
        public string CodPais { get; set; }
        public DateTime AnioAlta { get; set; }
        public DateTime AnioBaja { get; set; }
        public string CodEquipoAnterior { get; set; }

        public EquipoDto(string codEquipo, string nombreEquipo, string codPais, DateTime anioAlta, DateTime anioBaja, string codEquipoAnterior)
        {
            CodEquipo = codEquipo;
            NombreEquipo = nombreEquipo;
            CodPais = codPais;
            AnioAlta = anioAlta;
            AnioBaja = anioBaja;
            CodEquipoAnterior = codEquipoAnterior;
        }
    }
}
