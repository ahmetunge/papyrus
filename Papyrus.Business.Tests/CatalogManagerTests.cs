using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Papyrus.Business.Abstract;
using Papyrus.Business.Concrete;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Xunit;
using Core.Utilities.Results;
using Papyrus.Entities.Dtos;
using AutoMapper;

namespace Papyrus.Business.Tests
{
    public class CatalogManagerTests
    {
        Mock<ICatalogRepository> _mockCatalogRepository;
        Mock<IMapper> _mockMapper;
        public CatalogManagerTests()
        {
            _mockCatalogRepository = new Mock<ICatalogRepository>();
            _mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public async Task GetCatalogsIncludeGenresAsync_IfGenreNotFound_ShouldReturnError()
        {
            List<Catalog> catalogs = new List<Catalog>()
            {
                new Catalog{
                    Id= Guid.NewGuid(),
                    Name="Catalog-1",
                    Genres= new List<Genre>{new Genre{Id=Guid.NewGuid(),Name="Genre-1"}
                }},
                new Catalog{
                    Id= Guid.NewGuid(),
                    Name="Catalog-2",
                    Genres= new List<Genre>()
                }};


            _mockCatalogRepository.Setup(c => c.GetCatalogsIncludeGenreAsync())
            .ReturnsAsync(catalogs);

            CatalogManager catalogManager = new CatalogManager(_mockCatalogRepository.Object, null);

            IDataResult<List<CatalogToEditBookDto>> result = await catalogManager.GetCatalogsIncludeGenresAsync();

            Assert.True(!result.Success);
        }


        [Fact]
        public async Task GetCatalogsIncludeGenresAsync_MethodIsSatisfu_ShouldReturnSucces()
        {

            List<Catalog> catalogs = new List<Catalog>()
            {
                new Catalog{
                    Id= Guid.NewGuid(),
                    Name="Catalog-1",
                    Genres= new List<Genre>{new Genre{Id=Guid.NewGuid(),Name="Genre-1"}
                }},
                new Catalog{
                    Id= Guid.NewGuid(),
                    Name="Catalog-2",
                    Genres= new List<Genre>{new Genre{Id = Guid.NewGuid(),Name="Genre-2"}
                }}
            };

            List<CatalogToEditBookDto> catalogToEditBooks = new List<CatalogToEditBookDto>()
            {
                new CatalogToEditBookDto{
                    Id= Guid.NewGuid(),
                    Name="Catalog-1",
                    Genres= new List<KeyValueDto>{new KeyValueDto{Id=Guid.NewGuid(),Name="Genre-1"}
                }},
                new CatalogToEditBookDto{
                    Id= Guid.NewGuid(),
                    Name="Catalog-2",
                    Genres= new List<KeyValueDto>{new KeyValueDto{Id = Guid.NewGuid(),Name="Genre-2"}
                }}
            };


            _mockCatalogRepository.Setup(c => c.GetCatalogsIncludeGenreAsync())
            .ReturnsAsync(catalogs);

            _mockMapper.SetReturnsDefault(catalogToEditBooks);

            var catalogManager = new CatalogManager(_mockCatalogRepository.Object, _mockMapper.Object);

            var result = await catalogManager.GetCatalogsIncludeGenresAsync();

            Assert.True(result.Success);

        }
    }
}