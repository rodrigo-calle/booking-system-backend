using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityApartment : EntityBase
    {
        public int iddepartamento { get; set; }
        public int idproyecto { get; set; }
        public string nombreproyecto { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string piso { get; set; }
        public string ubicacion { get; set; }
        public List<EntityImage> images { get; set; }
    }
}