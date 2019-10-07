using AppSlider.Application.Business.Results;
using AppSlider.Domain;
using AppSlider.Domain.Entities.Business;
using AppSlider.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace AppSlider.Application.Business.Services.Config
{
    public class BusinessConfigService : IBusinessConfigService
    {
        private readonly IBusinessRepository businessRepository;

        public BusinessConfigService(IBusinessRepository businessRepository)
        {
            this.businessRepository = businessRepository;
        }

        public async Task<BusinessResult> SwitchActive(Guid id)
        {
            BusinessConfigSwitchActiveValidations(id);

            var business = await businessRepository.Get(id);

            if (business == null)
                throw new BusinessException($"Erro na ativação / desativação do Negócio", new List<string> { "Negócio Inexistente!" }, "BusinessConfigService - Validations");

            var domainBusiness = new BusinessEntity(business.Id, business.IdFather, business.IdType, business.IdCategory, business.LegalName,business.CNPJ ,business.Description, business.IdLogo, business.ContactName, business.ContactEmail, business.ContactPhone, business.ContactAddress,business.ContactCity, business.ExpirationDate, !business.Active, business.Blocked,business.File);

            businessRepository.DetachBusiness(business);

            await businessRepository.Update(domainBusiness);

            var returnUser = (BusinessResult)domainBusiness;

            return returnUser;
        }

        private void BusinessConfigSwitchActiveValidations(Guid id)
        {
            var messageValidations = new List<String>();

            if (id == new Guid())
            {
                messageValidations.Add("Para ativar / desativar um Negócio o 'Id' é obrigatorio!");
            }

            if (messageValidations.Count > 0)
            {
                throw new BusinessException("Erro na atualização do Negócio", messageValidations, "BusinessConfigService - Validations");
            }
        }
    }
}
