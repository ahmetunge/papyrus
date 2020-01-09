using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Papyrus.DataAccess.Abstract;

namespace Papyrus.DataAccess.Concrete.EntityFramework
{
    public class EfCoreUserRepository : EfCoreRepositoryBase<User>, IUserRepository
    {
        private readonly PapyrusContext _context;

        public EfCoreUserRepository(PapyrusContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Role>> GetRolesAsync(Guid userId)
        {
            List<Role> roles =await _context.UserRoles
            .Include(ur => ur.Role)
            .Where(ur => ur.UserId == userId)
            .Select(ur => ur.Role).ToListAsync();

            return roles;
        }
    }
}