using Volo.Abp.TestApp2.Domain;

namespace Volo.Abp.TestApp2.Application.Dto
{
    public class PhoneDto
    {
        public string Number { get; set; }

        public PhoneType Type { get; set; }
    }
}