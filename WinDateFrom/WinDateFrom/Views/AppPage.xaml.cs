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
        private static ResourceManager resmgr = new ResourceManager("WinDateFrom.Resources.AppResources", typeof(AppPage).Assembly);
        public AppPage()
        {
            this.InitializeComponent();
            tbdata.Text = resmgr.GetString("InserisciData");
            tbnome.Text = resmgr.GetString("InserisciNome");
            data.Date = DateTime.Parse(Preferences.Get("Data", DateTime.Now.ToString()));
            nome.Text = Preferences.Get("Nome", "numerone");
        }

        private void calcola_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            TimeSpan differenza = d - data.Date.Date;
            risultato.Text = resmgr.GetString("HaiIncontrato") + " " + nome.Text + " " + resmgr.GetString("circa") + " " + differenza.Days + " " + resmgr.GetString("GiorniFa") + ".";
            Preferences.Set("Data", data.Date.ToString());
            Preferences.Set("Nome", nome.Text);
        }
    }
}