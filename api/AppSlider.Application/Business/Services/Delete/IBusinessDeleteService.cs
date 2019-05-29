using System;
using System.Threading.Tasks;

namespace AppSlider.Application.Business.Services.Delete
{
    public interface IBusinessDeleteService
    {
        Task<Boolean> Process(Guid? id);
    }
}
