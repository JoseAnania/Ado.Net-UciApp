using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class DirectorEquipo
    {
        public int IdDirector { get; set; }
        public string CodEquipo { get; set; }
        public DateTime AnioAlta { get; set; }
        public DateTime AnioBaja { get; set; }

        public DirectorEquipo(int idDirector, string codEquipo, DateTime anioAlta, DateTime anioBaja)
        {
            IdDirector = idDirector;
            CodEquipo = codEquipo;
            AnioAlta = anioAlta;
            AnioBaja = anioBaja;
        }
    }
}
