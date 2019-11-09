using System.Collections.Generic;
using Papyrus.Entities;

namespace Papyrus.Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetBooks();
    }
}