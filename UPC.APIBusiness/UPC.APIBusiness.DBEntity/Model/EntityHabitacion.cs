using System;
using System.Collections.Generic;
using System.Text;

namespace DBEntity
{
    public class EntityHabitacion : EntityBase
    {
        public int idhabitacion { get; set; } //1
        public int idtipo { get; set; } //2
        public string tiponombre { get; set; } //Habitacion matrimonial Queen
        public decimal precio { get; set; } //500.00
        public string personas { get; set; }// 3
        public string image { get; set; }  //assets/img/habitaciones/habitacion2.jpg
    }
}