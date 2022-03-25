using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Director
    {
        public int IdDirector { get; set; }
        public string NombreDirector { get; set; }
        public string ApellidoDirector { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CodPais { get; set; }

        public Director(int idDirector, string nombreDirector, string apellidoDirector, DateTime fechaNacimiento, string codPais)
        {
            IdDirector = idDirector;
            NombreDirector = nombreDirector;
            ApellidoDirector = apellidoDirector;
            FechaNacimiento = fechaNacimiento;
            CodPais = codPais;
        }
    }
}
