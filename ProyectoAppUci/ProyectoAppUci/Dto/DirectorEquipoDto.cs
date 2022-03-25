using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class DirectorEquipoDto
    {
        public string NomApeDirector { get; set; }
        public string NombreEquipo { get; set; }
        public DateTime AnioAlta { get; set; }
        public DateTime AnioBaja { get; set; }

        public DirectorEquipoDto(string nomApeDirector, string nombreEquipo, DateTime anioAlta, DateTime anioBaja)
        {
            NomApeDirector = nomApeDirector;
            NombreEquipo = nombreEquipo;
            AnioAlta = anioAlta;
            AnioBaja = anioBaja;
        }
    }
}
