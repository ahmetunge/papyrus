using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

       // [LogAspect(typeof(DatabaseLogger))]
        public async Task<IDataResult<List<CategoryForAdDto>>> GetCategoriesIncludePropertiesAsync()
        {
            var categoriesFromDb = await _categoryRepository.GetCategoriesIncludePropertiesAsync();

            List<Category> categories = categoriesFromDb.ToList();

            if (categories.Count < 1)
                return new ErrorDataResult<List<CategoryForAdDto>>(null, Messages.CategoryNotFound,HttpStatusCode.NotFound);

            var categoriesToReturn = _mapper.Map<List<CategoryForAdDto>>(categories);

            return new SuccessDataResult<List<CategoryForAdDto>>(categoriesToReturn);

        }

    }
}