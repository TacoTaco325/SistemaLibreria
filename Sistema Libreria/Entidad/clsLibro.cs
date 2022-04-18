using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class clsLibro
    {
        public int idlibro { get; set; }
        public string NomLibro { get; set; }
        public int Categoria { get; set; }
        public int ISBM { get; set; }
        public int Stock { get; set; }
        public double Precio { get; set; }
        public int Autor { get; set; }
        public bool Estado { get; set; }
        public int operacion { get; set; }

    }
}
