using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Sinca
{
    public class ClienteAppService : CrudAppService<Cliente, ClienteDto, Guid, PagedAndSortedResultRequestDto,
            CreateUpdateClienteDto, CreateUpdateClienteDto>,
        IClienteAppService
    {
        public ClienteAppService(IRepository<Cliente, Guid> repository)
            : base(repository)
        {
        }
    }
}
