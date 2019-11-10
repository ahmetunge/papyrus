using System.Collections.Generic;
using Core.Utilities.Results;
using Papyrus.Entities;

namespace Papyrus.Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetBooks();

        IResult Add(Book book);
    }
}