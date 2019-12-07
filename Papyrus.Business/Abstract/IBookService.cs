using System;
using System.Collections.Generic;
using Core.Utilities.Results;
using Papyrus.Entities;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface IBookService
    {
        IDataResult<List<Book>> GetBooks();

        IResult Add(BookForCreationDto book);

        IDataResult<Book> GetBookById(Guid id);
    }
}