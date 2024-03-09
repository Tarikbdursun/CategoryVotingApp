using Core.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult AddCategory(Category category);
        IResult DeleteCategory(Category category);
        IResult UpdateCategory(Category category);
        IDataResult<Category> GetCategoryById(int id);
        IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter=null);
    }
}
