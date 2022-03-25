using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class EtapaDto
    {
        public int IdEtapa { get; set; }
        public int IdCarrera { get; set; }
        public int NumeroEtapa { get; set; }
        public string Desde { get; set; }
        public string Hasta { get; set; }
        public string NombreTipoEtapa { get; set; }
        public DateTime Fecha { get; set; }
        public int Km { get; set; }

        public EtapaDto(int idEtapa, int idCarrera, int numeroEtapa, string desde, string hasta, string nombreTipoEtapa, DateTime fecha, int km)
        {
            IdEtapa = idEtapa;
            IdCarrera = idCarrera;
            NumeroEtapa = numeroEtapa;
            Desde = desde;
            Hasta = hasta;
            NombreTipoEtapa = nombreTipoEtapa;
            Fecha = fecha;
            Km = km;
        }
    }
}
