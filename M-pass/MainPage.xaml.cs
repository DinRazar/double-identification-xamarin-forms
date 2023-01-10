using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mpass;
using Xamarin.Forms;


namespace M_pass
{

    public partial class MainPage : ContentPage
    {
        

        public MainPage() => InitializeComponent();


        private void Button_Clicked(object sender,EventArgs e)
        {
            if((txtUsername.Text == "DimaN" && txtPassword.Text == "03112003"))  
            {
                Navigation.PushAsync(new SecondAuthPage());
            }
            else
            {
                DisplayAlert("Ops...","Uesername or Password is incorrected!","Bruh");
            }
        }
    }
}

