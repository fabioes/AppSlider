
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
        private readonly Domain.Entities.Users.User loggedUser;

        public UserGetService(IBusinessRepository businessRepository, [FromServices]Domain.Entities.Users.User loggedUser)
        {
            this.businessRepository = businessRepository;
            this.loggedUser = loggedUser;
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

        public async Task<List<BusinessResult>> GetForLoggedUser()
        {
            var business = await businessRepository.GetForLoggedUser(loggedUser);

            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }
        public async Task<List<BusinessResult>> GetFromUser(Domain.Entities.Users.User user)
        {
            var business = await businessRepository.GetForLoggedUser(user);

            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }
    }
}
