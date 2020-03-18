using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Sinca.Mobile.ViewModels;
using Xamarin.Essentials;

namespace Sinca.Mobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ConsultaClienteView : ContentPage
    {
        ConsultaClienteViewModel viewModel;

        public ConsultaClienteView()
        {
            InitializeComponent();
            try
            {
                BindingContext = viewModel = new ConsultaClienteViewModel(Navigation);
            }
            catch (Exception e)
            {
                try
                {
                    string erro = "[ConsultaClienteView]" + Environment.NewLine + e.Message;
                    if (e.InnerException != null)
                        erro += Environment.NewLine + e.InnerException.Message;
                    if (e.InnerException.InnerException != null)
                        erro += Environment.NewLine + e.InnerException.InnerException.Message;
                    if (e.InnerException.InnerException.InnerException != null)
                        erro += Environment.NewLine + e.InnerException.InnerException.InnerException.Message;
                    if (e.InnerException.InnerException.InnerException.InnerException != null)
                        erro += Environment.NewLine + e.InnerException.InnerException.InnerException.InnerException.Message;
                    var mensagem = new EmailMessage { Subject = "Log do Aplicativo", Body = erro, To = new List<string> { "hardshopmobile@gmail.com" } };
                    Email.ComposeAsync(mensagem);
                }
                catch (Exception exception)
                {
                }
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            viewModel.SelectCliente = args.SelectedItem as ClienteDto;
            if (viewModel.SelectCliente == null)
                return;

            viewModel.EditarClienteOnClick.Execute(null);

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.PesquisarOnClick.Execute(null);
        }
    }
}