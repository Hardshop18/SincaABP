using System;
using System.Collections.Generic;

namespace Volo.Abp.Vfp2
{
    public class VfpContextModel
    {
        public IReadOnlyDictionary<Type, IVfpEntityModel> Entities { get; }

        public VfpContextModel(IReadOnlyDictionary<Type, IVfpEntityModel> entities)
        {
            Entities = entities;
        }
    }
}