using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prueba_01.Models
{
    public class Persona
    {
        public int codigo { get; set; }

        public string nombre { get; set; }
        public string apellido { get; set; }

        public Persona()
        {
            this.codigo = 0;
            this.nombre = "";
            this.apellido = "";
        }
    }
}