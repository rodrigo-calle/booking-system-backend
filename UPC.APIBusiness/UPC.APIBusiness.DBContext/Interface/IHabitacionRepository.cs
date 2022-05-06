using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IHabitacionRepository
    {
        EntityBaseResponse GetHabitaciones();
        EntityBaseResponse GetHabitacionesAgrup();
    }
}