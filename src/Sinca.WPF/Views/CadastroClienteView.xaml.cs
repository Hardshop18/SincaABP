using Sinca.ViewModels;
using System.Windows;
using Volo.Abp;

namespace Sinca
{
    /// <summary>
    /// Interação lógica para CadastroClienteViewModel.xam
    /// </summary>
    public partial class CadastroClienteView : Window
    {
        private CadastroClienteViewModel _viewModels;

        public CadastroClienteView(IAbpApplicationWithInternalServiceProvider application, ClienteDto clienteDto)
        {
            InitializeComponent();

            DataContext = _viewModels = new CadastroClienteViewModel(application, clienteDto);
        }
    }
}