using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class CiclistaEquipo
    {
        public int IdCiclista { get; set; }
        public string CodEquipo { get; set; }
        public DateTime AnioAlta { get; set; }
        public DateTime AnioBaja { get; set; }

        public CiclistaEquipo(int idCiclista, string codEquipo, DateTime anioAlta, DateTime anioBaja)
        {
            IdCiclista = idCiclista;
            CodEquipo = codEquipo;
            AnioAlta = anioAlta;
            AnioBaja = anioBaja;
        }
    }
}
