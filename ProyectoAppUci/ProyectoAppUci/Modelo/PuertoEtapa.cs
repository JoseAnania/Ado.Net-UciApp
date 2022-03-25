using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class PuertoEtapa
    {
        public int IdEtapa { get; set; }
        public int IdPuerto { get; set; }
        public int IdCiclista { get; set; }
        public string Puesto { get; set; }

        public PuertoEtapa(int idEtapa, int idPuerto, int idCiclista, string puesto)
        {
            IdEtapa = idEtapa;
            IdPuerto = idPuerto;
            IdCiclista = idCiclista;
            Puesto = puesto;
        }
    }
}
