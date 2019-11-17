using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Validators;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;

namespace Papyrus.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IResult AddUser(User user)
        {
            if (user == null)
                return new ErrorResult();

            _userRepository.Add(user);

            return new SuccessResult(Messages.UserAddedSuccessfully);
        }

        public IDataResult<User> GetUserByMail(string mail)
        {
            if (!Validator.ValidateMail(mail))
                return new ErrorDataResult<User>(Messages.InvalidMail);

            var user = _userRepository.Find(u => u.Email == mail);
            if (user == null)
                return new ErrorDataResult<User>(Messages.UserNotFound);

            return new SuccessDataResult<User>(user);

        }

        public IDataResult<List<Role>> GetUserRoles(Guid userId)
        {

            var userRoles = _userRepository.GetUserRoles(userId);

            return new SuccessDataResult<List<Role>>(userRoles);
        }
    }
}