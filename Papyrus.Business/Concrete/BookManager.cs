using System.Collections.Generic;
using System.Linq;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
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

        public IResult Add(Book book)
        {
            if (book == null)
            {
                return new ErrorResult();
            }

            _bookRepository.Add(book);

            return new SuccessResult(Messages.SuccessAddedBook);
        }

        public IDataResult<List<Book>> GetBooks()
        {
            return new SuccessDataResult<List<Book>>(_bookRepository.GetAll().ToList());
        }
    }
}