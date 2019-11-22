using System.Collections.Generic;
using System.Linq;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.Business.Validations.FluentValidation;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities;

namespace Papyrus.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public BookManager(IBookRepository bookRepository, IUnitOfWork unitOfWork)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        [ValidationAspect(typeof(BookValidator), Priority = 1)]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Add(Book book)
        {
            if (book == null)
            {
                return new ErrorResult();
            }

            _bookRepository.Add(book);

            _unitOfWork.Complete();

            return new SuccessResult(Messages.SuccessAddedBook);
        }

        [CacheAspect(1)]
        public IDataResult<List<Book>> GetBooks()
        {
            return new SuccessDataResult<List<Book>>(_bookRepository.GetAll().ToList());
        }
    }
}