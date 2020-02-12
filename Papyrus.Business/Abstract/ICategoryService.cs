using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Entities.Concrete;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface ICategoryService
    {
        Task<IDataResult<List<CategoryForAdDto>>> GetListAsync();
        Task<IDataResult<List<CategoryForAdDto>>> GetCategoriesIncludePropertiesAsync();
    }
}