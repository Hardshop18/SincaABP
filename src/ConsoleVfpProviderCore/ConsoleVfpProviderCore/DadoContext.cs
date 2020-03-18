using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using VfpEntityFrameworkProvider;

namespace ConexaoVFPCore
{
    [DbConfigurationType(typeof(VfpDbConfiguration))]
    public class DadoContext : DbContext
    {
        public IDbSet<Sinca> Sinca { get; set; }
        public DadoContext(VfpConnection connection)
            : base(connection, true)
        {

        }

        static DadoContext()
        {
            Database.SetInitializer(new DataInitializer());
        }
    }
}
