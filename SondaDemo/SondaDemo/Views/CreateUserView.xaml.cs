using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SondaDemo.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUserView : ContentPage
    {
        public CreateUserView()
        {
            InitializeComponent();
            BindingContext = new ViewModels.CreateUserViewModel();
        }
    }
}