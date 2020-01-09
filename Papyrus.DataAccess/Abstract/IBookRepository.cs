using System;
using System.Threading.Tasks;
using Core.DataAccess;
using Papyrus.Entities.Concrete;

namespace Papyrus.DataAccess.Abstract
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<Book> GetByIdIncludeGenreAsync(Guid id);
    }
}