using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WinDateFrom.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppPage : ContentPage
    {
        public AppPage()
        {
            this.InitializeComponent();
            data.Date = DateTime.Parse(Preferences.Get("Data", DateTime.Now.ToString()));
            nome.Text = Preferences.Get("Nome", "");
        }

        private void calcola_Click(object sender, EventArgs e)
        {
            anniversario.Text = "";
            risultato.Text = "";
            DateTime d = DateTime.Now;
            TimeSpan differenza = d - data.Date.Date;
            if (differenza.TotalDays < 0)
            {
                risultato.Text = $"{Resources["InvalidValue"]}";
                return;
            }
            if (d.Day==data.Date.Day && differenza.TotalDays >1)
            {
                if (d.Month == data.Date.Month)
                    anniversario.Text = $"{Resources["anniversario"]}";
                else
                    anniversario.Text = $"{Resources["mesiversario"]}";
            }
            risultato.Text = $"{Resources["greetings1"]} {nome.Text} {Resources["greetings2"]} {differenza.Days} {Resources["greetings3"]}";
            Preferences.Set("Data", data.Date.ToString());
            Preferences.Set("Nome", nome.Text);
        }
    }
}