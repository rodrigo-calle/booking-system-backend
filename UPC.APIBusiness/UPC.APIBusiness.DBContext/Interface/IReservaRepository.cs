using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IReservaRepository
    {
        EntityBaseResponse Insert(EntityReserva reserva);
    }
}
