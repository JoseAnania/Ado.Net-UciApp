using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Etapa
    {
        public int IdEtapa { get; set; }
        public int IdCarrera { get; set; }
        public int NumeroEtapa { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public int IdTipoEtapa { get; set; }
        public DateTime Fecha { get; set; }
        public int Km { get; set; }

        public Etapa(int idEtapa, int idCarrera, int numeroEtapa, string desde, string hasta, int idTipoEtapa, DateTime fecha, int km)
        {
            IdEtapa = idEtapa;
            IdCarrera = idCarrera;
            NumeroEtapa = numeroEtapa;
            Desde = desde;
            Hasta = hasta;
            IdTipoEtapa = idTipoEtapa;
            Fecha = fecha;
            Km = km;
        }
    }
}
