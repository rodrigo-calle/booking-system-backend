using System;
using System.Collections.Generic;
using System.Text;
using DBEntity;

namespace DBContext
{
    public interface IApartmentRepository
    {
        EntityBaseResponse GetApartments();
        EntityBaseResponse GetApartments(int id);
    }
}