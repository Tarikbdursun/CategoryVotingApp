﻿using Core.DataAccess.EntityFramework;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfUserDal:EfEntityRepositoryBase<User,VotingAppDbContext>, IUserDal
    {
    }
}
