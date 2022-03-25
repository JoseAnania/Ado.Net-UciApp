using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class TipoEtapa
    {
        public int IdTipoEtapa { get; set; }
        public string NombreTipoEtapa { get; set; }

        public TipoEtapa(int idTipoEtapa, string nombreTipoEtapa)
        {
            IdTipoEtapa = idTipoEtapa;
            NombreTipoEtapa = nombreTipoEtapa;
        }
    }
}
