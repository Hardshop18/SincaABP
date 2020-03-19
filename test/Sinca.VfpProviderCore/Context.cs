using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using VfpEntityFrameworkProvider;

namespace Sinca.VfpProviderCore
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class Context : DbContext
    {
        public IDbSet<TabelaTeste> TabelaTeste { get; set; }
        public Context(VfpConnection connection)
            : base(connection, true)
        {
        }

        static Context()
        {
            Database.SetInitializer(new DataInitializer());
        }
    }
}
