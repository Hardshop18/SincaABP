using Volo.Abp.TestApp2.Domain;

namespace Volo.Abp.TestApp2.Application.Dto
{
    public class GetPersonPhonesFilter
    {
        public PhoneType? Type { get; set; }
    }
}