﻿using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Volo.Abp.TestApp2.Domain
{
    public class District : CreationAuditedEntity
    {
        public string CityId { get; private set; }

        public string Name { get; private set; }

        public int Population { get; set; }

        private District()
        {
            
        }

        public District(string cityId, string name, int population = 0)
        {
            CityId = cityId;
            Name = name;
        }

        public override object[] GetKeys()
        {
            return new Object[] {CityId, Name};
        }
    }
}