using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.DBEntity.Model
{
    public class EntityPaqueteHabitacion
    {
        public int iddet { get; set; }
        public int idpaquete { get; set; }
        public int idhabitacion { get; set; } //1
        public int cantidad { get; set; }
        public int idtipo { get; set; } //2
        public string tiponombre { get; set; } //Habitacion matrimonial Queen
        public decimal precio { get; set; } //500.00
        public string personas { get; set; }// 3
    }
}
