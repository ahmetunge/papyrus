using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.Business.Validations.FluentValidation;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookManager(IBookRepository bookRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [ValidationAspect(typeof(BookValidator), Priority = 1)]
        [CacheRemoveAspect("IBookService.Get")]
        public IResult Add(BookForCreationDto bookForCreation)
        {
            var book = _mapper.Map<Book>(bookForCreation);

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