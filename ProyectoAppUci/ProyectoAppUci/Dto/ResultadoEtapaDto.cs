using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class ResultadoEtapaDto
    {
        public int NumeroEtapa { get; set; }
        public string NombreCarrera { get; set; }
        public string NomApeCiclista { get; set; }
        public string PuestoMaillot { get; set; }
        public DateTime Tiempo { get; set; }
        public int Puntos { get; set; }

        public ResultadoEtapaDto(int numeroEtapa, string nombreCarrera, string nomApeCiclista, string puestoMaillot, DateTime tiempo, int puntos)
        {
            NumeroEtapa = numeroEtapa;
            NombreCarrera = nombreCarrera;
            NomApeCiclista = nomApeCiclista;
            PuestoMaillot = puestoMaillot;
            Tiempo = tiempo;
            Puntos = puntos;
        }
    }
}
