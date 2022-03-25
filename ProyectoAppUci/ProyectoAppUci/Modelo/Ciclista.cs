using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Modelo
{
    class Ciclista
    {
        public int IdCiclista { get; set; }
        public string NombreCiclista { get; set; }
        public string ApellidoCiclista { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CodPais { get; set; }

        public Ciclista(int idCiclista, string nombreCiclista, string apellidoCiclista, DateTime fechaNacimiento, string codPais)
        {
            IdCiclista = idCiclista;
            NombreCiclista = nombreCiclista;
            ApellidoCiclista = apellidoCiclista;
            FechaNacimiento = fechaNacimiento;
            CodPais = codPais;
        }
    }
}
