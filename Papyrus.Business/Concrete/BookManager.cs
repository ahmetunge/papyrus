using System.Collections.Generic;
using System.Linq;
using Papyrus.Business.Abstract;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities;

namespace Papyrus.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

        }
        public List<Book> GetBooks()
        {
            return _bookRepository.GetAll().ToList();
        }
    }
}