using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Core.Utilities.Results;
using Papyrus.Business.Abstract;
using Papyrus.Business.Constants;
using Papyrus.DataAccess.Abstract;
using Papyrus.Entities.Dtos;

namespace Papyrus.Business.Concrete
{
    public class PropertyManager : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        public PropertyManager(
            IPropertyRepository propertyRepository,
            IMapper mapper
        )
        {
            _mapper = mapper;
            _propertyRepository = propertyRepository;

        }
        public async Task<IDataResult<List<KeyValueDto>>> GetPropertiesByCategoryId(Guid categoryId)
        {
            var propertiesFromDb = await _propertyRepository
            .FindListAsync(p => p.CategoryId == categoryId);


            if (propertiesFromDb.Count() <= 0)
                return new ErrorDataResult<List<KeyValueDto>>(Messages.PropertiesNotFound,HttpStatusCode.NotFound);

            var propertiesToReturn = _mapper.Map<List<KeyValueDto>>(propertiesFromDb.ToList());

            return new SuccessDataResult<List<KeyValueDto>>(propertiesToReturn);

        }
    }
}