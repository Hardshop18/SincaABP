using Volo.Abp.Application.Dtos;

namespace Sinca
{
    public class GetClienteInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
