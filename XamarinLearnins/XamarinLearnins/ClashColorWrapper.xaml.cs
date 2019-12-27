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
    public partial class ClashColorWrapper : ContentPage
    {
        public ClashColorWrapper()
        {
            InitializeComponent();


            MessagingCenter.Subscribe<MainPage, Config>(this, Constants.CONFIGCHANGE, (sender, config) =>
            {
                ClashColors.Children.Clear();
                if (config?.ClashColors?.Any() ?? false)
                    foreach (var clashColor in config.ClashColors)
                    {
                        addClashColor(clashColor);
                    }
            });
        }
        private void btnAddClashColor_Clicked(object sender, EventArgs e)
        {
            var model = new ColorModel { Red = 75, Blue = 150, Green = 225 };

            addClashColor(model);
        }
        private void addClashColor(ColorModel color)
        {
            ColorPickerView view = new ColorPickerView() { BindingContext = color };
            ClashColors.Children.Add(view);

            if (!canAddClashColor())
                btnAddClashColor.IsVisible = false;
        }
        private bool canAddClashColor()
        {
            return getClashColors().Count() < 3;
        }

        public IEnumerable<ColorModel> getClashColors()
        {
            return ClashColors.Children?.Select(x => ((ColorPickerView)x).getColorModel());
        }

        private void ClashColors_ChildRemoved(object sender, ElementEventArgs e)
        {
            btnAddClashColor.IsVisible = canAddClashColor();
        }
    }
}