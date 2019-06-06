using AppSlider.Application.TypeBusiness.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.TypeBusiness.Services.Get
{
    public class TypeBusinessGetService : ITypeBusinessGetService
    {
        private readonly IBusinessTypeRepository businessTypeRepository;
        
        public TypeBusinessGetService(IBusinessTypeRepository businessTypeRepository)
        {
            this.businessTypeRepository = businessTypeRepository;
        }

        public async Task<TypeBusinessResult> Get(Guid id)
        {
            var typeBusiness = await businessTypeRepository.Get(id);

            var returnTypeBusiness = (TypeBusinessResult)typeBusiness;

            return returnTypeBusiness;
        }

        public async Task<TypeBusinessResult> GetByName(String name)
        {
            var typeBusiness = await businessTypeRepository.GetByName(name);

            var returnTypeBusiness = (TypeBusinessResult)typeBusiness;

            return returnTypeBusiness;
        }

        public async Task<List<TypeBusinessResult>> GetAll()
        {
            var typesBusiness = await businessTypeRepository.GetAll();

            var returnTypesBusiness = typesBusiness.Select(s => (TypeBusinessResult)s).ToList();
            
            return returnTypesBusiness;
        }
    }
}
