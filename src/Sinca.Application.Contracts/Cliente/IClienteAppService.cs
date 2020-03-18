using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Sinca
{
    public interface IClienteAppService : ICrudAppService<ClienteDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateClienteDto, CreateUpdateClienteDto> 
    {
    }
}
