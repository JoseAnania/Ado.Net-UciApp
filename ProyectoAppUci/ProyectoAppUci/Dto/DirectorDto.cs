using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoAppUci.Dto
{
    class DirectorDto
    {
        public int IdDirector { get; set; }
        public string NomApeDirector { get; set; }

        public DirectorDto(int idDirector, string nomApeDirector)
        {
            IdDirector = idDirector;
            NomApeDirector = nomApeDirector;
        }
    }
}
