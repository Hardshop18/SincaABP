using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities;

namespace Volo.Abp.TestApp2.Domain
{
    public class City : AggregateRoot<string>
    {
        public string Name { get; set; }

        public ICollection<District> Districts { get; set; }

        private City()
        {
            
        }

        public City(string id, string name)
            : base(id)
        {
            Name = name;
            Districts = new List<District>();
        }

        public int GetPopulation()
        {
            return Districts.Select(d => d.Population).Sum();
        }
    }
}
