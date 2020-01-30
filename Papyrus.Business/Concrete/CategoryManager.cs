using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public async Task<IDataResult<List<CategoryForAd>>> GetListAsync()
        {
            var categoriesFromDb = await _categoryRepository.GetAllAsync();

            List<Category> categories = categoriesFromDb.ToList();

            if (categories.Count < 1)
                return new ErrorDataResult<List<CategoryForAd>>(null, Messages.CategoryNotFound);

               var categoriesToReturn= _mapper.Map<List<CategoryForAd>>(categories);
          
                return new SuccessDataResult<List<CategoryForAd>>(categoriesToReturn);
        }
    }
}