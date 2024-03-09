using Business.Abstract;
using Business.Constants;
using Core.Entity.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserDal _userDal;

        public AuthManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            if (!UserExist(userForLoginDto))
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            var user = _userDal.GetAll(x => x.UserName == userForLoginDto.Username).FirstOrDefault();

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(user, Messages.SuccessfulLogin);
        }

        public IDataResult<User> Register(string username, string password)
        {
            byte[] passwordSalt, passwordHash;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            User newUser = new User()
            {
                UserName = username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userDal.Add(newUser);
            return new SuccessDataResult<User>(newUser,Messages.UserRegistered);
        }

        public bool UserExist(UserForLoginDto userForLoginDto)
        {
            return _userDal.GetAll().Exists(x => x.UserName == userForLoginDto.Username);

        }
    }
}
