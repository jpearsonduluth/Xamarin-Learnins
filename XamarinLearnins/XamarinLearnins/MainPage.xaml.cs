using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinLearnins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<NavigationPage>(this, Constants.APPREADY, (sender) =>
            {
                var configs = DataPersistance.Get();
                txtNewConfig.IsVisible = !configs.Any();
                populateConfigDropdown(configs);
                setUpConfig(configs.FirstOrDefault() ?? new Config());
            });            
        }
        public string GetConfigName()
        {
            if (txtNewConfig.IsVisible)
                return txtNewConfig.Text;
            else
                return configPicker.SelectedItem.ToString();
        }
        public ColorModel GetBladeColor()
        {
            return primaryColor.getColorModel();
        }
        private void populateConfigDropdown(IEnumerable<Config> configs)
        {
            configPicker.Items.Add("New");
            foreach (var config in configs)
            {
                configPicker.Items.Add(config.Name);
            }

            if (configs.Any())
                configPicker.SelectedIndex = 1;
        }

        private void setUpConfig(Config config)
        {
            primaryColor.BindingContext = config.BladeColor;
            fireConfigMsg(config);
        }
        private void fireConfigMsg(Config config)
        { 
            MessagingCenter.Send(this, Constants.CONFIGCHANGE, config);
        }
        private void configPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = ((Picker)sender);
            Config config;
            if (picker.SelectedIndex != 0)
            {
                txtNewConfig.IsVisible = false;
                config = DataPersistance.Get().FirstOrDefault(x => x.Name == picker.SelectedItem.ToString());                
            }
            else
            {
                txtNewConfig.IsVisible = true;
                config = new Config();
            }
            setUpConfig(config);
        }
    }
}