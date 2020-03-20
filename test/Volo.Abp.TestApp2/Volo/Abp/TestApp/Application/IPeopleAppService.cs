using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.TestApp2.Application.Dto;

namespace Volo.Abp.TestApp2.Application
{
    public interface IPeopleAppService : ICrudAppService<PersonDto, string>
    {
        Task<ListResultDto<PhoneDto>> GetPhones(string id, GetPersonPhonesFilter filter);

        Task<PhoneDto> AddPhone(string id, PhoneDto phoneDto);

        Task RemovePhone(string id, string number);

        Task GetWithAuthorized();

        Task<GetWithComplexTypeInput> GetWithComplexType(GetWithComplexTypeInput input);
    }
}