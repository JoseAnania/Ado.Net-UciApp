using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class CiclistaDto
    {
        public int IdCiclista { get; set; }
        public string NomApeCiclista { get; set; }
        public CiclistaDto(int idCiclista, string nomApeCiclista)
        {
            IdCiclista = idCiclista;
            NomApeCiclista = nomApeCiclista;
        }
    }
}
