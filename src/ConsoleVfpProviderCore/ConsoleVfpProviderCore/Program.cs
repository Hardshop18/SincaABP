using System;
using VfpEntityFrameworkProvider;

namespace ConexaoVFPCore
{
    class Program
    {
        static void Main(string[] args)
        {
            VfpProviderFactory.Register();
            string connectionString = @"D:\GitHub\dados\SincaTeste.dbc"; //DELETED=true;data source=
            DadoContext dc = new DadoContext(new VfpConnection(connectionString));
            var teste = dc.Sinca.Find(1);
            Console.WriteLine("Id {0} - Nome {1}", teste.id, teste.nome);
            Console.ReadKey();
        }
    }
}
