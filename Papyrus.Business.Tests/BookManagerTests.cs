
using Moq;
using Papyrus.Business.Concrete;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class BookManagerTests
    {
        [Fact]
        public void AddBook_IfBookNull_ShoulReturnFalse()
        {
            Mock<IBookRepository> mock = new Mock<IBookRepository>();

            BookManager bookManager = new BookManager(mock.Object);

            var result = bookManager.Add(null);

            Assert.Equal(false, result.Success);
        }
    }
}