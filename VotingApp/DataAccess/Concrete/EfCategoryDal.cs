using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category,VotingAppDbContext>,ICategoryDal
    {
        public void VoteCategory(Category category)
        {
            category.VoteCount++;
            Update(category);
        }
    }
}
