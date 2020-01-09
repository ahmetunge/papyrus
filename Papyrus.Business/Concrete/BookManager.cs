using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.BusinessAspects.Autofac;
using Papyrus.Business.Constants;
using Papyrus.Business.Validations.FluentValidation;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
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

        [ValidationAspect(typeof(BookForCreationDtoValidator), Priority = 1)]
        [CacheRemoveAspect("IBookService.Get")]
        public async Task<IResult> AddAsync(BookForCreationDto bookForCreation)
        {
            var book = _mapper.Map<Book>(bookForCreation);

            _bookRepository.Add(book);

            await _unitOfWork.CompleteAsync();

            return new SuccessResult(Messages.SuccessAddedBook);
        }

        // [ValidationAspect(typeof(BookValidator), 1)]
        public async Task<IResult> EditAsync(BookForEditDto bookForEditDto, Guid id)
        {
            var bookFromDb = await _bookRepository.FindAsync(b => b.Id == id);

            if (bookFromDb == null)
            {
                return new ErrorResult(Messages.BookNotFound);
            }

            _mapper.Map<BookForEditDto, Book>(bookForEditDto, bookFromDb);

            await _unitOfWork.CompleteAsync();

            return new SuccessResult(Messages.BookEditSuccessfully);
        }

        [LogAspect(typeof(FileLogger))]
        public async Task<IDataResult<BookForDetailDto>> GetByIdIncludeGenreAsync(Guid id)
        {
            Book book = await _bookRepository
            .GetByIdIncludeGenreAsync(id);

            var bookForDetail = _mapper.Map<BookForDetailDto>(book);

            return new SuccessDataResult<BookForDetailDto>(bookForDetail);
        }

        // [SecuredOperation("Book.List")]
        [CacheAspect(1)]
        public async Task<IDataResult<List<Book>>> GetListAsync()
        {
            var books = await _bookRepository.GetAllAsync();
            return new SuccessDataResult<List<Book>>(books.ToList());
        }
    }
}