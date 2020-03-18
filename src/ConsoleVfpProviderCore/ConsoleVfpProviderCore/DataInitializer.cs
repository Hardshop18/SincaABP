using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace ConexaoVFPCore
{
    public class DataInitializer : DropCreateDatabaseAlways<DadoContext>
    {
        protected override void Seed(DadoContext context)
        {
            AddSincas(context);

            context.SaveChanges();
        }

        private static void AddSincas(DadoContext context)
        {
            Enumerable.Range(0, 5)
                      .Select(x => new Sinca
                      {
                          id = x,
                          nome = "Teste " + x
                      })
                      .ToList()
                      .ForEach(x => context.Sinca.Add(x));
        }
    }
}
