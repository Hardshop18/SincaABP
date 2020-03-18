using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Volo.Abp;

namespace Sinca.ViewModels
{
    public class ConsultaClienteViewModel : BaseViewModel<ClienteDto>
    {
        public ClienteDto SelectCliente { get; set; }
        private ObservableCollection<ClienteDto> _clientes;
        public ObservableCollection<ClienteDto> Clientes { get { return _clientes; } set { SetProperty(ref _clientes, value); } }
        
        private readonly IClienteAppService _clienteAppService;
        public ICommand PesquisarOnClick { get; }
        public ICommand NovoClienteOnClick { get; }
        public ICommand EditarClienteOnClick { get; }

        public ConsultaClienteViewModel(IAbpApplicationWithInternalServiceProvider application) : base(application)
        {
            _clienteAppService = application.ServiceProvider.GetRequiredService<IClienteAppService>();

            PesquisarOnClick = new RelayCommand(param => PesquisarClientePorNome());
            NovoClienteOnClick = new RelayCommand(param => NovoCliente());
            EditarClienteOnClick = new RelayCommand(param => EditarCliente());

            NovoDto();
            Listar();
        }

        private void Listar()
        {
            Clientes = new ObservableCollection<ClienteDto>();
            var result = _clienteAppService.GetListAsync(new GetClienteInput());
            foreach (var item in result.Result.Items)
            {
                Clientes.Add(item);
            }
        }

        private void PesquisarClientePorNome()
        {
            Clientes = new ObservableCollection<ClienteDto>();
            //TODO - Ver no exemplo do ABP como consultar sem ser pelo guid.
            var result = _clienteAppService.GetListAsync(new GetClienteInput());
            foreach(var item in result.Result.Items)
            {
                if ((item.Nome == Dto.Nome) || (string.IsNullOrEmpty(Dto.Nome)))
                {
                    Clientes.Add(item);
                }
            }
        }

        private void NovoCliente()
        {
            ChamarTelaCadastro(new ClienteDto());
        }

        private void EditarCliente()
        {
            if (SelectCliente != null)
                ChamarTelaCadastro(SelectCliente);
            else
                MessageBox.Show("Selecione um cliente para editar.");
        }

        private void ChamarTelaCadastro(ClienteDto clienteDto)
        {
            var view = new CadastroClienteView(Application, clienteDto);
            view.ShowDialog();
            Listar();
        }
    }
}
