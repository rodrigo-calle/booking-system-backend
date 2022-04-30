using DBEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBContext
{
    public interface IUserRepository
    {
        EntityBaseResponse Login(EntityLogin login);
        EntityBaseResponse Insert(EntityUser user);
    }
}
