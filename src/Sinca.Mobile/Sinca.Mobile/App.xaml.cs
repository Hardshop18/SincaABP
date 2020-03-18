using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Sinca.Mobile.Services;
using Sinca.Mobile.Views;
using Xamarin.Essentials;

namespace Sinca.Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            try
            {
                DependencyService.Register<AbpInitialize>();
            }
            catch (Exception e)
            {
                string erro = "[DependencyService.Register<AbpInitialize>()]" + Environment.NewLine + e.Message;
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

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
