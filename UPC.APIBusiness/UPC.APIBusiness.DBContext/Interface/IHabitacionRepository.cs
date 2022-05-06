using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;
using UPC.APIBusiness.DBEntity.Model;

namespace DBContext
{
    public interface IHabitacionRepository
    {
        EntityBaseResponse GetHabitaciones();
        EntityBaseResponse GetHabitacionesAgrup();
    }
}