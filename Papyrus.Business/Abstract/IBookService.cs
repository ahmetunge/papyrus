using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface IBookService
    {
        Task<IDataResult<List<Book>>> GetListAsync();

        Task<IResult> AddAsync(BookForCreationDto book);

        Task<IDataResult<BookForDetailDto>> GetByIdIncludeGenreAsync(Guid id);

        Task<IResult> EditAsync(BookForEditDto book, Guid id);
    }
}