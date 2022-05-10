
using AppSlider.Application.Business.Results;
using AppSlider.Domain.Authentication;
using AppSlider.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Get
{
    public class BusinessGetService : IBusinessGetService
    {
        private readonly IBusinessRepository businessRepository;
        private readonly IEquipamentRepository equipamentRepository;
        private readonly LoggedUser loggedUser;
        private readonly IHttpContextAccessor httpContextAccessor;

        public BusinessGetService(IBusinessRepository businessRepository,
            IEquipamentRepository equipamentRepository,
            [FromServices] LoggedUser loggedUser)
        {
            this.businessRepository = businessRepository;
            this.equipamentRepository = equipamentRepository;
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

        public async Task<List<BusinessResult>> GetByType(String type)
        {
            if (String.IsNullOrWhiteSpace(type))
                throw new Exception("tipo é obrigatório");

            var business = await businessRepository.GetByType(type);

            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }

        public async Task<List<BusinessResult>> GetByFranchiseAndType(String franchiseId, String type)
        {
            if (String.IsNullOrWhiteSpace(franchiseId))
                throw new Exception("franquia é obrigatória");

            if (!Guid.TryParse(franchiseId, out Guid _franchiseId))
                throw new Exception("informe uma franquia válida");

            if (String.IsNullOrWhiteSpace(type))
                throw new Exception("tipo é obrigatório");

            var business = await businessRepository.GetByFranchiseAndType(_franchiseId, type);


            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }
        public async Task<List<BusinessResult>> GetByFranchiseAndType(String franchiseId, String type, int page)
        {
            if (String.IsNullOrWhiteSpace(franchiseId))
                throw new Exception("franquia é obrigatória");

            if (!Guid.TryParse(franchiseId, out Guid _franchiseId))
                throw new Exception("informe uma franquia válida");

            if (String.IsNullOrWhiteSpace(type))
                throw new Exception("tipo é obrigatório");

            var business = await businessRepository.GetByFranchiseAndType(_franchiseId, type, page);


            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }

        public async Task<List<BusinessResult>> GetForLoggedUser()
        {
            var business = await businessRepository.GetForLoggedUser(loggedUser);

            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }

        public async Task<List<BusinessResult>> GetFromUser(LoggedUser user)
        {
            var business = await businessRepository.GetForLoggedUser(user);

            var returnBusiness = business.Select(s => (BusinessResult)s).ToList();

            return returnBusiness;
        }

        public async Task<int> CountItems(string franchiseId, string type)
        {
            if (String.IsNullOrWhiteSpace(franchiseId))
                throw new Exception("franquia é obrigatória");

            if (!Guid.TryParse(franchiseId, out Guid _franchiseId))
                throw new Exception("informe uma franquia válida");

            if (String.IsNullOrWhiteSpace(type))
                throw new Exception("tipo é obrigatório");
            return await businessRepository.CountItems(_franchiseId, type);
        }
    }
}
