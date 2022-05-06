using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.DBEntity.Model
{
    public class EntityPaquete : EntityBase
    {
        public int idpaquete { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string image { get; set; }
        public List<EntityPaqueteHabitacion> habitaciones { get; set; }
    }
}
