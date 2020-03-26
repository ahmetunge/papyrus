using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using Papyrus.Business.Concrete;
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


            // _mockAdRepository.Setup(x => x.FindListAsync(It.IsAny<Expression<Func<Ad, bool>>>()))
            //     .ReturnsAsync(ads);

             _mockMapper.Setup(mp => mp.Map<List<MemberAdForListDto>>(It.IsAny<IEnumerable<Ad>>()))
              .Returns(ads);

            AdManager adManager = new AdManager(_mockAdRepository.Object, _mockMapper.Object, _mockUnitOfWork.Object);

            var result = await adManager.GetMemberAdsAsync(Guid.NewGuid());

            Assert.True(result.Data.Count == 2);
            Assert.True(result.Success);
            Assert.True(result.StatusCode == HttpStatusCode.OK);
        }
    }
}