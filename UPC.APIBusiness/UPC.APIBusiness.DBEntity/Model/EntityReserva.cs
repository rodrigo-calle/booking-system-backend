using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity 
{
    public class EntityReserva
    {
        public int idreserva { get; set; }
        public List<EntityReservaAux> data { get; set; }
    }
}
