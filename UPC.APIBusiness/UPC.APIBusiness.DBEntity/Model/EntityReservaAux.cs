using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity 
{
    public class EntityReservaAux
    {
        public int idhabitacion { get; set; }  
        public int idusuario { get; set; }  
        public int ninos { get; set; } 
        public int adultos { get; set; } 
        public decimal precio { get; set; }  
        public string fecha { get; set; }
        public int dias { get; set; }
    }
}
