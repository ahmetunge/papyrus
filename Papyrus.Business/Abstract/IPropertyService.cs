using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Abstract
{
    public interface IPropertyService
    {
         
        Task<IDataResult<List<KeyValueDto>>> GetPropertiesByCategoryId(Guid categoryId);
    }
}