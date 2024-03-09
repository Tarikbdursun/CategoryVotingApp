using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IResult AddCategory(Category category)
        {
            _categoryDal.Add(category);
            return new SuccessResult();
        }

        public IResult DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult();
        }

        public IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(filter));
        }

        public IDataResult<Category> GetCategoryById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.GetById(id));
        }

        public IResult UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult();
        }
    }
}
