using System;
using Microsoft.Extensions.DependencyInjection;
using Sinca;
using Volo.Abp;

namespace ConsoleTeste
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var application = AbpApplicationFactory.Create<AppModule>(options =>
            {
                options.UseAutofac(); //Autofac integration
            }))
            {
                application.Initialize();

                //Resolve a service and use it
                var _clienteAppService = application.ServiceProvider.GetService<IClienteAppService>();

                CreateUpdateClienteDto clienteDto = new CreateUpdateClienteDto();
                clienteDto.Nome = "teste";
                clienteDto.Observacao = "teste";
                _clienteAppService.CreateAsync(clienteDto);


                var result = _clienteAppService.GetListAsync(new GetClienteInput());

                Console.WriteLine("Press ENTER to stop application...");
                Console.ReadLine();
            }
        }
    }
}
