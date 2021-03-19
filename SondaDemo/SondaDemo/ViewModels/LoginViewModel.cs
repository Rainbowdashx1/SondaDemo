using SondaDemo.Context;
using SondaDemo.Models;
using SondaDemo.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SondaDemo.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private MethodApi MA;
        private string _email;
        private string _password;
        public ICommand GoToConfirmLogin { private set; get; }
        public INavigation Navigation { get; set; }

        public LoginViewModel(INavigation navigation) 
        {
            Navigation = navigation;
            GoToConfirmLogin = new Command(async () => await GoConfirmLogin() );
            MA = new MethodApi();
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }

        async Task GoConfirmLogin()
        {
            Login LoginModel = new Login() { data = new Data_RequestLogin() { userlogin = new Userlogin() { email = Email, password = Password } } };
            ResponseApi result = MA.Login(LoginModel);

            if (result.msg != null)
            {
                switch (result.msg.code)
                {
                    case "200":
                        await App.Current.MainPage.DisplayAlert("Login", "Login Success", "Ok");
                        await Navigation.PushAsync(new CreateUserView());
                        Navigation.RemovePage(Navigation.NavigationStack[0]);
                        break;
                    case "401":
                        await App.Current.MainPage.DisplayAlert("Login", result.msg.msg, "Ok");
                        break;
                    case "500":
                        await App.Current.MainPage.DisplayAlert("Login", result.msg.msg, "Ok");
                        break;
                }
            }
            else 
            {
                //error por falta de internet o api no disponible 
                await App.Current.MainPage.DisplayAlert("Login", "check your internet connection", "Ok");
            }
        }
    }
}
