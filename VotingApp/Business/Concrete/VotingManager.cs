using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class VotingManager : IVotingService
    {
        ICategoryDal _categoryDal;

        public VotingManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void VoteCategory(Category category)
        {
            var updatedCategory = _categoryDal.GetById(category.ID);
            updatedCategory.VoteCount++;

            _categoryDal.Update(updatedCategory);
        }

        public string GetVotesRate()
        {
            var categories = _categoryDal.GetAll()
                .OrderBy(x => x.ID).ToList();

            var votes=categories
                .Select(x=>x.VoteCount).ToList();

            string result = "";
            int sumOfVotes = votes.Sum();

            

            for(int i =0; i<categories.Count; i++)
            {
                var v = votes[i];
                string rate = $"{categories[i].CategoryName}  %{(double)(v * 100 / sumOfVotes)}";
                result = String.Concat(result, rate + "\n");
            }

            return result;
        }
    }
}
