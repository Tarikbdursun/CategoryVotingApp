using Core.Entity.Concrete;
using Core.Utilities.Results;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService:IDisposable
    {
        IDataResult<User> Register(string username, string password);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        bool UserExist(UserForLoginDto userForLoginDto);
    }
}
