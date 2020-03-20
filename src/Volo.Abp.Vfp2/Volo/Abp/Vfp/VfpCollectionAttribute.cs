using System;

namespace Volo.Abp.Vfp2
{
    public class VfpCollectionAttribute : Attribute
    {
        public string CollectionName { get; set; }

        public VfpCollectionAttribute()
        {
            
        }

        public VfpCollectionAttribute(string collectionName)
        {
            CollectionName = collectionName;
        }
    }
}