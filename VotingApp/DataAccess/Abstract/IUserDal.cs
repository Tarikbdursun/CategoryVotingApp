﻿using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal:IEntityRepository<User>
    {

    }
}
