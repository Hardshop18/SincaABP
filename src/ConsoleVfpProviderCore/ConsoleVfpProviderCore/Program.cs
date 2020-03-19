using System;
using VfpEntityFrameworkProvider;

namespace ConsoleVFPCore
{
    class Program
    {
        static void Main(string[] args)
        {
            VfpProviderFactory.Register();
            string connectionString = @"D:\GitHub\dados\SincaTeste.dbc"; //DELETED=true;data source=
            Context dc = new Context(new VfpConnection(connectionString));
            var teste = dc.TabelaTeste.Find(1);
            Console.WriteLine("Id {0} - Nome {1}", teste.id, teste.nome);
            Console.ReadKey();
        }
    }
}
