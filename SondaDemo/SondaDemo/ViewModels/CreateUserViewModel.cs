using SondaDemo.Context;
using SondaDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SondaDemo.ViewModels
{
    public class CreateUserViewModel : BaseViewModel
    {
        private MethodApi MA;
        private string _numberdocument { get; set; }
        private string _name { get; set; }
        private string _lastname { get; set; }
        private string _password { get; set; }
        private string _repassword { get; set; }
        private string _email { get; set; }
        private string _reemail { get; set; }
        public ICommand GoCreateUser { private set; get; }

        public CreateUserViewModel() 
        {
            GoCreateUser = new Command(async () => await CreateUser());
            MA = new MethodApi();
        }

        public string NumberDocument
        {
            get { return _numberdocument; }
            set { _numberdocument = value; RaisePropertyChanged(); }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }
        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; RaisePropertyChanged(); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }
        public string RePassword
        {
            get { return _repassword; }
            set { _repassword = value; RaisePropertyChanged(); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }
        public string ReEmail
        {
            get { return _reemail; }
            set { _reemail = value; RaisePropertyChanged(); }
        }
        async Task CreateUser()
        {

            string ResultValidator = ValidatorForm();

            if (ResultValidator == "")
            {
                CreateUser Createusero = new CreateUser() { data = new Data_RequestCreateUser() { user = new UserCreate() { numberDoc = NumberDocument, name = Name, lastName = LastName, email = Email, password = Password } } };
                ResponseApi resultr = MA.CreateUser(Createusero);

                if (resultr.msg != null)
                {
                    await App.Current.MainPage.DisplayAlert("Create User", resultr.msg.msg, "Ok");
                    ClearForm();
                }
                else
                {
                    //error por falta de internet o api no disponible 
                    await App.Current.MainPage.DisplayAlert("Create User", "check your internet connection", "Ok");
                }
            }
            else 
            {
                await App.Current.MainPage.DisplayAlert("Create User Error", ResultValidator, "Ok");
            }
        }
        public string ValidatorForm() 
        {
            if (Password==null || Password.Length < 6) 
            {
                return "minimum six characters";
            }
            if (Password==null || Password.Any(char.IsDigit) != true || Password.Any(char.IsLetter) != true) 
            {
                return "the password must have numbers and letters";
            }

            if ((Password == null || RePassword==null) || Password!=RePassword)
            {
                return "the passwords are not the same";
            }

            if ((Email == null || ReEmail == null) || Email != ReEmail)
            {
                return "emails are not the same";
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(Email);
            Match match2 = regex.Match(ReEmail);

            if (!match.Success)
                return "email is not in the correct format ('abcd@hotmail.com')";

            if (!match2.Success)
                return "Reemail is not in the correct format ('abcd@hotmail.com')";

            return "";
        }

        private void ClearForm() 
        {
            NumberDocument = "";
            Name = "";
            LastName = "";
            Password = "";
            RePassword = "";
            Email = "";
            ReEmail = "";
        } 

    }
}
