using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinLearnins
{
    public partial class NavigationPage : TabbedPage
    {
        public NavigationPage()
        {
            InitializeComponent();
            MessagingCenter.Send(this, Constants.APPREADY);

            MessagingCenter.Subscribe<Footer>(this, Constants.SAVECLICK, (sender) =>
            {
                SaveConfig();
            });
        }

        private void SaveConfig()
        {
            //var mp = Application.Current.MainPage.FindByName<MainPage>("MainPage");
            var mp = this.Children.First(x => x.GetType() == typeof(MainPage)) as MainPage;
            var config = new Config()
            {
                Name = mp.GetConfigName(),
                BladeColor = mp.GetBladeColor(),
                ClashColors = (this.Children.First(x => x.GetType() == typeof(ClashColorWrapper)) as ClashColorWrapper).getClashColors()
            };

            DataPersistance.Save(config);
        }
    }
}