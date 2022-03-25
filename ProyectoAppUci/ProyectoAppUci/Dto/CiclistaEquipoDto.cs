using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class CiclistaEquipoDto
    {
        public string NomApeCiclista { get; set; }
        public string NombreEquipo { get; set; }
        public DateTime AnioAlta { get; set; }
        public DateTime AnioBaja { get; set; }

        public CiclistaEquipoDto(string nomApeCiclista, string nombreEquipo, DateTime anioAlta, DateTime anioBaja)
        {
            NomApeCiclista = nomApeCiclista;
            NombreEquipo = nombreEquipo;
            AnioAlta = anioAlta;
            AnioBaja = anioBaja;
        }
    }
}
