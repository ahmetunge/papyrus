
using AutoMapper;
using FluentValidation;
using Moq;
using Papyrus.Business.Concrete;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class BookManagerTests
    {
        // [Fact]
        // public void AddBook_IfBookNull_ShoulReturnFalse()
        // {
        //     Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();
        //     Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
        //     Mock<IMapper> mockMapper = new Mock<IMapper>();


        //     BookManager bookManager = new BookManager(mockBookRepository.Object, mockUnitOfWork.Object, mockMapper.Object);

        //     var result = bookManager.Add(null);

        //     Assert.False(result.Success);
        // }

        // [Fact]
        // public void AddBook_IfInValidBookObject_ShouldRReturnValidateException()
        // {
        //     Mock<IBookRepository> mockBookRepository = new Mock<IBookRepository>();
        //     Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
        //     Mock<IMapper> mockMapper = new Mock<IMapper>();


        //    BookManager bookManager = new BookManager(mockBookRepository.Object, mockUnitOfWork.Object, mockMapper.Object);
        //     var result = bookManager.Add(null);
        //     Assert.Throws<ValidationException>(() => new ValidationException(""));
        // }
    }
}