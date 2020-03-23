using System;
using Volo.Abp.Application.Dtos;

namespace Volo.Abp.TestApp2.Application.Dto
{
    public class DistrictDto : EntityDto
    {
        public string CityId { get; set; }

        public string Name { get; set; }

        public int Population { get; set; }
    }
}
