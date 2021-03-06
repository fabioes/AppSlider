using AppSlider.Application.Business.Results;
using AppSlider.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Get
{
    public interface IBusinessGetService
    {
        Task<BusinessResult> Get(Guid id);

        Task<List<BusinessResult>> GetByType(String type);

        Task<List<BusinessResult>> GetByFranchiseAndType(String franchiseId, String type);
        Task<List<BusinessResult>> GetByFranchiseAndType(String franchiseId, String type,int page);

        Task<List<BusinessResult>> GetAll();

        Task<List<BusinessResult>> GetForLoggedUser();

        Task<List<BusinessResult>> GetFromUser(LoggedUser user);
        Task<int> CountItems(String franchiseId, String type);

    }
}
