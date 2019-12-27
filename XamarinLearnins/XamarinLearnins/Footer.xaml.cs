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
    public partial class Footer : ContentView
    {
        public Footer()
        {
            InitializeComponent();
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, Constants.SAVECLICK);
        }
    }
}