using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class ResultadoEtapa
    {
        public int IdEtapa { get; set; }
        public int IdCiclista { get; set; }
        public string PuestoMaillot { get; set; }
        public DateTime Tiempo { get; set; }
        public int Puntos { get; set; }

        public ResultadoEtapa(int idEtapa, int idCiclista, string puestoMaillot, DateTime tiempo, int puntos)
        {
            IdEtapa = idEtapa;
            IdCiclista = idCiclista;
            PuestoMaillot = puestoMaillot;
            Tiempo = tiempo;
            Puntos = puntos;
        }
    }
}
