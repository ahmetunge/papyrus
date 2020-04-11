using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Papyrus.Business.Concrete;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class AdManagerTests
    {

        Mock<IUnitOfWork> _mockUnitOfWork;
        Mock<IAdRepository> _mockAdRepository;
        Mock<IMapper> _mockMapper;
        public AdManagerTests()
        {
            _mockAdRepository = new Mock<IAdRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();

        }

        [Fact]
        public async Task GetMemberAds_IfCorrect_ShouldReturnList()
        {
            List<MemberAdForListDto> ads = new List<MemberAdForListDto>{
                new MemberAdForListDto{
                    Title="Title 1",
                    Description= "Description 1"
                },
                new MemberAdForListDto{
                    Title = "Title 2",
                    Description = "Description 2"
                }
            };

            _mockMapper.Setup(mp => mp.Map<List<MemberAdForListDto>>(It.IsAny<IEnumerable<Ad>>()))
             .Returns(ads);

            AdManager adManager = new AdManager(_mockAdRepository.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            var result = await adManager.GetAdsAsync();

            Assert.True(result.Data.Count == 2);
            Assert.True(result.Success);
            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }

        [Fact]
        public async Task GetAdDetails_IfAdNotFound_ShouldReturnError()
        {

            Ad ad = null;

            _mockAdRepository.Setup(mr => mr.GetAdDetails(It.IsAny<Guid>()))
            .ReturnsAsync(ad);

            AdManager adManager = new AdManager(_mockAdRepository.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            var result = await adManager.GetAdDetails(new Guid());

            Assert.True(result.Success == false);
            Assert.True(result.StatusCode == HttpStatusCode.NotFound);
            Assert.True(result.Message == Messages.AdNotFound);
        }

        [Fact]
        public async Task GetAdDetails_IfAdNotFound_ShouldReturnSuccess()
        {
            Ad ad = new Ad
            {
                Id = new Guid(),
                Title = "Ad title",
                Category = new Category
                {
                    Id = new Guid(),
                    Name = "Category Name"
                }
            };

            _mockAdRepository.Setup(ar => ar.GetAdDetails(It.IsAny<Guid>()))
            .ReturnsAsync(ad);

            AdManager adManager = new AdManager(_mockAdRepository.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            var result = await adManager.GetAdDetails(new Guid());

            Assert.True(result.Success);
            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }
    }
}