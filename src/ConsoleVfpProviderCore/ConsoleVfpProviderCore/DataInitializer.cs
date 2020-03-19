using System.Data.Entity;
using System.Linq;

namespace ConsoleVFPCore
{
    public class DataInitializer : CreateDatabaseIfNotExists<Context>
    {
        protected override void Seed(Context context)
        {
            AddTabelaTestes(context);

            context.SaveChanges();
        }

        private static void AddTabelaTestes(Context context)
        {
            Enumerable.Range(0, 5)
                      .Select(x => new TabelaTeste
                      {
                          id = x,
                          nome = "Teste " + x
                      })
                      .ToList()
                      .ForEach(x => context.TabelaTeste.Add(x));
        }
    }
}
