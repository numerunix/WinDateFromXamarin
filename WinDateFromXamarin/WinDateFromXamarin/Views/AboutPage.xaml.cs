using System;
using System.ComponentModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WinDateFromXamarin.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        public async void Informations_Click(object sender, EventArgs e)
        {
            await Browser.OpenAsync("https://github.com/numerunix/WinDateFromXamarin");
        }
    }

}