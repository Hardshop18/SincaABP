using System.ComponentModel;
using Sinca.Mobile.ViewModels;
using Xamarin.Forms;

namespace Sinca.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class CadastroClienteView : ContentPage
    {
        CadastroClienteViewModel viewModel;

        public CadastroClienteView(ClienteDto clienteDto)
        {
            InitializeComponent();

            BindingContext = viewModel = new CadastroClienteViewModel(Navigation, clienteDto);
        }
    }
}