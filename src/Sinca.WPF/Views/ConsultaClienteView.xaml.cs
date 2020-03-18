using Sinca.ViewModels;
using System.Windows;
using Volo.Abp;

namespace Sinca
{
    /// <summary>
    /// Interação lógica para CadastroClienteViewModel.xam
    /// </summary>
    public partial class ConsultaClienteView : Window
    {
        private readonly IAbpApplicationWithInternalServiceProvider _application;

        public ConsultaClienteView()
        {
            InitializeComponent();

            _application = AbpApplicationFactory.Create<SincaModule>(options =>
            {
                options.UseAutofac(); //Autofac integration
            });
            _application.Initialize();

            DataContext = new ConsultaClienteViewModel(_application);
        }
    }
}