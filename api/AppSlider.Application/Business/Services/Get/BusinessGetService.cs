
using AppSlider.Application.Business.Results;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Get
{
    public class UserGetService : IBusinessGetService
    {
        private readonly IBusinessRepository businessRepository;
        
        public UserGetService(IBusinessRepository businessRepository)
        {
            this.businessRepository = businessRepository;
        }

        public async Task<BusinessResult> Get(Guid id)
        {
            var user = await businessRepository.Get(id);

            var returnUser = (BusinessResult)user;

            return returnUser;
        }

        public async Task<List<BusinessResult>> GetAll()
        {
            var business = await businessRepository.GetAll();

            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();
            
            return returnBusiness;
        }
    }
}
