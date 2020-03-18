using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using VfpEntityFrameworkProvider;

namespace ConexaoVFPCore
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class Context : DbContext
    {
        public IDbSet<TabelaTeste> Sinca { get; set; }

        public Context()
            : base(new VfpConnection(@"D:\GitHub\dados\SincaTeste.dbc"), true)
        {
        }

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
