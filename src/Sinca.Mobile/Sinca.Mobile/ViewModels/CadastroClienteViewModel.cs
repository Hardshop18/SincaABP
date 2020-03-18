using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace Sinca.Mobile.ViewModels
{
    public class CadastroClienteViewModel : BaseViewModel<ClienteDto>
    {
        private readonly IClienteAppService _clienteAppService;
        private INavigation Navigation { get; }
        public Command GravarOnClick { get; set; }
        public Command ExcluirOnClick { get; set; }
        public Command CancelarOnClick { get; set; }
        public CadastroClienteViewModel(INavigation navigation, ClienteDto clienteDto) : base()
        {
            Navigation = navigation;
            _clienteAppService = DataStore.Application.ServiceProvider.GetRequiredService<IClienteAppService>();
            GravarOnClick  = new Command(async () => await Gravar());
            ExcluirOnClick = new Command(async () => await Excluir());
            CancelarOnClick = new Command(async () => await Cancelar());
            Dto = clienteDto;
        }

        private async Task Gravar()
        {
            var createUpdateClienteDto = Mapper.Map<Sinca.ClienteDto, Sinca.CreateUpdateClienteDto>(Dto);
            var cliente = _clienteAppService.GetAsync(Dto.Id);

            if (cliente.Status == TaskStatus.Faulted)
                await _clienteAppService.CreateAsync(createUpdateClienteDto);
            else
                await _clienteAppService.UpdateAsync(Dto.Id, createUpdateClienteDto);
            await Navigation.PopModalAsync();
        }

        private async Task Excluir()
        {
            await _clienteAppService.DeleteAsync(Dto.Id);
            await Navigation.PopModalAsync();
        }

        private async Task Cancelar()
        {
            await Navigation.PopModalAsync();
        }
    }
}
