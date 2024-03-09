using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
public interface IVotingService
    {
        void VoteCategory(Category category);
        string GetVotesRate();
    }
}
