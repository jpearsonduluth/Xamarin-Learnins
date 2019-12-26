using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static XamarinLearnins.MainPage;

namespace XamarinLearnins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorPickerView : ContentView
    {
        public ColorPickerView()
        {
            InitializeComponent();
        }

        private Color calculateRGB()
        {
            var cm = getColorModel();
            return Color.FromRgb(cm.Red, cm.Green, cm.Blue);
        }
        public ColorModel getColorModel()
        {
            return new ColorModel {
                Red = (int)Slider_Red.Value,
                Green = (int)Slider_Green.Value,
                Blue = (int)Slider_Blue.Value
            };
        }


        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var color = calculateRGB();
            ColorBlendBox.Color = color;
            Label.Text = $"RGB Value - {color.ToHex()}";
        }

        private void btnDeleteColorPicker_Clicked(object sender, EventArgs e)
        {
            (colorPickerContentView.Parent as StackLayout).Children.Remove(colorPickerContentView);
        }
    }
}