using System;
using System.Collections.Generic;
using Core.Entities.Concrete;
using Papyrus.Business.Abstract;
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

        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public User GetUserByMail(string mail)
        {
            return _userRepository.Find(u => u.Email == mail);
        }

        public List<Role> GetUserRoles(Guid userId)
        {
            return _userRepository.GetUserRoles(userId);
        }
    }
}