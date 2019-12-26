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
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var items = DataPersistance.Get();

            foreach (var item in items)
            {
                ColorPickerView view = new ColorPickerView() { BindingContext = item };
                ClashColors.Children.Add(view);
            }

            btnAddClashColor.IsVisible = canAddClashColor();
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            DataPersistance.Save(getClashColors());
        }

        private void btnAddClashColor_Clicked(object sender, EventArgs e)
        {
            var model = new ColorModel { Red = 75, Blue = 150, Green = 225 };
            ColorPickerView view = new ColorPickerView() { BindingContext = model };
            ClashColors.Children.Add(view);
            
            if (!canAddClashColor())
                btnAddClashColor.IsVisible = false;
        }
        private bool canAddClashColor()
        {
            return getClashColors().Count() < 3;
        }

        private IEnumerable<ColorModel> getClashColors()
        {
            return ClashColors.Children?.Select(x => ((ColorPickerView)x).getColorModel());
        }

        private void ClashColors_ChildRemoved(object sender, ElementEventArgs e)
        {
            btnAddClashColor.IsVisible = canAddClashColor();
        }
    }
    
}
