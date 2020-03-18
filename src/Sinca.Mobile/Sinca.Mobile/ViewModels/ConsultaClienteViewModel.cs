using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Sinca.Mobile.Views;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Essentials;

namespace Sinca.Mobile.ViewModels
{
    public class ConsultaClienteViewModel : BaseViewModel<ClienteDto>
    {
        [CanBeNull] public ClienteDto SelectCliente { get; set; }
        public ObservableCollection<ClienteDto> Clientes { get; set; }
        public Command PesquisarOnClick { get; set; }
        public Command NovoClienteOnClick { get; }
        public Command EditarClienteOnClick { get; }
        private IClienteAppService ClienteAppService { get; }
        private INavigation Navigation { get; }

        public ConsultaClienteViewModel(INavigation navigation) : base()
        {
            try
            {
                Navigation = navigation;
                ClienteAppService = DataStore.Application.ServiceProvider.GetRequiredService<IClienteAppService>();
                Clientes = new ObservableCollection<ClienteDto>() {new ClienteDto() {Nome = "", Observacao = ""}};
            }
            catch (Exception e)
            {
                string erro = "[ConsultaClienteViewModel]" + Environment.NewLine + e.Message;
                if (e.InnerException != null)
                    erro += Environment.NewLine + e.InnerException.Message;
                if (e.InnerException.InnerException != null)
                    erro += Environment.NewLine + e.InnerException.InnerException.Message;
                if (e.InnerException.InnerException.InnerException != null)
                    erro += Environment.NewLine + e.InnerException.InnerException.InnerException.Message;
                if (e.InnerException.InnerException.InnerException.InnerException != null)
                    erro += Environment.NewLine + e.InnerException.InnerException.InnerException.InnerException.Message;
                var mensagem = new EmailMessage
                    {Subject = "Log do Aplicativo", Body = erro, To = new List<string> {"hardshopmobile@gmail.com"}};
                Email.ComposeAsync(mensagem);
            }

            PesquisarOnClick = new Command(async () => await Listar());
            NovoClienteOnClick = new Command(async () => await NovoCliente());
            EditarClienteOnClick = new Command(async () => await EditarCliente());
        }

        async Task Listar()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Clientes.Clear();

                var consultaCliente = ClienteAppService.GetListAsync(new GetClienteInput());
                var clientes = consultaCliente.Result.Items.ToList();
                foreach (var cliente in clientes)
                {
                    Clientes.Add(cliente);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task NovoCliente()
        {
            await ChamarTelaCadastro(ClienteDto.Novo("Item name"));
        }

        private async Task EditarCliente()
        {
            if (SelectCliente != null)
                await ChamarTelaCadastro(SelectCliente);
        }

        private async Task ChamarTelaCadastro(ClienteDto clienteDto)
        {
            await Navigation.PushModalAsync(new NavigationPage(new CadastroClienteView(clienteDto)));
        }
    }
}