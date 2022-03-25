using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class ResEtaDto
    {
        public int IdEtapa { get; set; }
        public int IdCiclista { get; set; }
        public string PuestoMaillot { get; set; }
        public DateTime Tiempo { get; set; }
        public int Puntos { get; set; }
        public int IdEtapaAnterior { get; set; }
        public int IdCiclistaAnterior { get; set; }

        public ResEtaDto(int idEtapa, int idCiclista, string puestoMaillot, DateTime tiempo, int puntos, int idEtapaAnterior, int idCiclistaAnterior)
        {
            IdEtapa = idEtapa;
            IdCiclista = idCiclista;
            PuestoMaillot = puestoMaillot;
            Tiempo = tiempo;
            Puntos = puntos;
            IdEtapaAnterior = idEtapaAnterior;
            IdCiclistaAnterior = idCiclistaAnterior;
        }
    }
}
