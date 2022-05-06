using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace UPC.APIBusiness.DBContext.Interface
{
    public interface IPaqueteRepository
    {
        EntityBaseResponse GetPaquetes();
        EntityBaseResponse GetPaquete(int id);
    }
}
