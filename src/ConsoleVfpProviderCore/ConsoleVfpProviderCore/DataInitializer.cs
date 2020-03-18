using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ConexaoVFPCore
{
    public class DataInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            AddSincas(context);

            context.SaveChanges();
        }

        private static void AddSincas(Context context)
        {
            Enumerable.Range(0, 5)
                      .Select(x => new TabelaTeste
                      {
                          id = x,
                          nome = "Teste " + x
                      })
                      .ToList()
                      .ForEach(x => context.Sinca.Add(x));
        }
    }
}
