using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Volo.Abp;

namespace Sinca.ViewModels
{
    public class CadastroClienteViewModel : BaseViewModel<ClienteDto>
    {
        private readonly IClienteAppService _clienteAppService;
        public ICommand NovoOnClick { get; }
        public ICommand GravarOnClick { get; }
        public ICommand ExcluirOnClick { get; }

        public CadastroClienteViewModel(IAbpApplicationWithInternalServiceProvider application, ClienteDto clienteDto) : base()
        {
            _clienteAppService = application.ServiceProvider.GetRequiredService<IClienteAppService>();
            
            NovoOnClick = new RelayCommand(param => NovoDto());
            GravarOnClick = new RelayCommand(param => Gravar());
            ExcluirOnClick = new RelayCommand(param => Excluir());
            Dto = clienteDto;
        }

        private void Gravar()
        {
            var createUpdateClienteDto = Mapper.Map<ClienteDto, CreateUpdateClienteDto>(Dto);
            var cliente = _clienteAppService.GetAsync(Dto.Id);

            if (cliente.Status == TaskStatus.Faulted)
            {
                _clienteAppService.CreateAsync(createUpdateClienteDto);
                MessageBox.Show("Cliente cadastrado com sucesso.", "Aviso");
            }
            else
            {
                _clienteAppService.UpdateAsync(Dto.Id, createUpdateClienteDto);
                MessageBox.Show("Cliente editado com sucesso.", "Aviso");
            }
        }

        private void Excluir()
        {
            _clienteAppService.DeleteAsync(Dto.Id);
            NovoDto();
        }
    }
}
