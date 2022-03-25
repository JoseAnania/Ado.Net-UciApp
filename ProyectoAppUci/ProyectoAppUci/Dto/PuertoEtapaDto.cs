using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class PuertoEtapaDto
    {
        public int IdEtapa { get; set; }
        public string NombrePuerto { get; set; }
        public string nomApeCiclista { get; set; }
        public string Puesto { get; set; }

        public PuertoEtapaDto(int idEtapa, string nombrePuerto, string nomApeCiclista, string puesto)
        {
            IdEtapa = idEtapa;
            NombrePuerto = nombrePuerto;
            this.nomApeCiclista = nomApeCiclista;
            Puesto = puesto;
        }
    }
}
