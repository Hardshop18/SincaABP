using AutoMapper;

namespace Volo.Abp.TestApp2.Domain
{
    public class TestAutoMapProfile : Profile
    {
        public TestAutoMapProfile()
        {
            CreateMap<PersonEto, Person>().ReverseMap();
        }
    }
}
