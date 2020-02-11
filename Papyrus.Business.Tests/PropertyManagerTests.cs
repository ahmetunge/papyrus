using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using Moq;
using Papyrus.Business.Concrete;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Xunit;

namespace Papyrus.Business.Tests
{
    public class PropertyManagerTests
    {
        private readonly Mock<IPropertyRepository> _mockPropertyRepo;
        private readonly Mock<IMapper> _mockMapper;
        public PropertyManagerTests()
        {
            _mockPropertyRepo = new Mock<IPropertyRepository>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public async Task GetPropertiesByCategoryId_ShouldReturnError_IfPropertiesNotFound()
        {
            //Given

            IEnumerable<Property> properties = new List<Property>();

            GetTestProperties(properties);
            // _mockPropertyRepo.Setup(mp => mp.FindListAsync(It.IsAny<Expression<Func<Property, bool>>>()))
            // .ReturnsAsync(properties);

            PropertyManager propertyManager = new PropertyManager(_mockPropertyRepo.Object, _mockMapper.Object);

            //When
            var result = await propertyManager.GetPropertiesByCategoryId(Guid.NewGuid());

            //Then
            Assert.False(result.Success);
            Assert.Equal(result.Message, Messages.PropertiesNotFound);

        }

        [Fact]
        public async Task GetPropertiesByCategoryId_ShouldReturnSuccesResult_IfPropertiesFound()
        {
            // Given
            IEnumerable<Property> properties = new List<Property>{
                new Property{Id= Guid.NewGuid(), Name="Test Property 1"},
                new Property{Id= Guid.NewGuid(), Name="Test Property 2"}
            };

            GetTestProperties(properties);


            PropertyManager propertyManager = new PropertyManager(_mockPropertyRepo.Object, _mockMapper.Object);

            //When
            var result = await propertyManager.GetPropertiesByCategoryId(Guid.NewGuid());

            //Then
            Assert.True(result.Success);
            Assert.Equal(properties.Count(), 2);

        }

        public void GetTestProperties(IEnumerable<Property> properties)
        {
            var testProperties = _mockPropertyRepo.Setup(mp => mp.FindListAsync(It.IsAny<Expression<Func<Property, bool>>>()))
                          .ReturnsAsync(properties);

        }

    }
}