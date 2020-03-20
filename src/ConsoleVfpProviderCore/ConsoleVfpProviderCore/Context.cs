using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Text;
using VfpEntityFrameworkProvider;

namespace ConsoleVFPCore
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class Context : DbContext
    {
        public IDbSet<TabelaTeste> TabelaTeste { get; set; }

        public Context()
            : base(new VfpConnection(@"D:\GitHub\dados\SincaTeste.dbc"), true)
        {
        }

        public Context(VfpConnection connection)
            : base(connection, true)
        {
            this.Database
        }

        static Context()
        {
            Database.SetInitializer(new DataInitializer());
        }
    }
}
