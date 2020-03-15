using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Core.Utilities.Business;
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
        private readonly IUnitOfWork _unitOfWork;

        public UserManager(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult> AddAsync(User user)
        {
            if (user == null)
                return new ErrorResult();

            _userRepository.Add(user);

            await _unitOfWork.CompleteAsync();
            
            return new SuccessResult(Messages.UserAddedSuccessfully, HttpStatusCode.Created);
        }

        public async Task<IDataResult<User>> GetByMailAsync(string mail)
        {
            User user = null;

            IResult result = BusinessRules.Run(CheckMail(mail), await CheckIfUserExistByMail(mail, user));

            if (result != null)
            {
                return (IDataResult<User>)result;
            }

            return new SuccessDataResult<User>(user);

        }

        public async Task<IDataResult<List<Role>>> GetRolesAsync(Guid userId)
        {

            var userRoles = await _userRepository.GetRolesAsync(userId);

            return new SuccessDataResult<List<Role>>(userRoles);
        }

        private IResult CheckMail(string mail)
        {
            if (!Validator.ValidateMail(mail))
            {
                return new ErrorDataResult<User>(Messages.InvalidMail, HttpStatusCode.UnprocessableEntity);
            }

            return new SuccessResult();

        }

        private async Task<IResult> CheckIfUserExistByMail(string mail, User user)
        {
            user = await _userRepository.FindAsync(u => u.Email == mail);
            if (user == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound, HttpStatusCode.NotFound);
            }
            return new SuccessResult();

        }
    }
}