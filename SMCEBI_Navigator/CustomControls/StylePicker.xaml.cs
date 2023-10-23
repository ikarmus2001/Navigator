using SMCEBI_Navigator.Models;
using System.Globalization;
using System.StringExtensions;

namespace SMCEBI_Navigator.CustomControls;

public partial class StylePicker : ContentView
{
    public static readonly BindableProperty StyleItemProperty = BindableProperty.Create(
            propertyName: nameof(StyleItem), 
            returnType: typeof(ElementStyle), 
            declaringType: typeof(StylePicker),
            defaultValue: new ElementStyle(),
            defaultBindingMode: BindingMode.TwoWay);

    public ElementStyle StyleItem
    {
        get => (ElementStyle)GetValue(StyleItemProperty);
        set => SetValue(StyleItemProperty, value);
    }

    private readonly List<string> possibleColors = new() { "Red", "Green", "Blue", "Black", "White" };

    public StylePicker()
    {
        InitializeComponent();
        SetPickersItems();
    }

    private void SetPickersItems()
    {
        FillColor_PreviewRect.Fill = StyleItem.FillColor.ToHex().ToColorBrush();
        LineColor_PreviewLine.Fill = StyleItem.LineColor.ToHex().ToColorBrush();
        BackgroundColor_PreviewRect.Fill = StyleItem.BackgroundColor.ToHex().ToColorBrush();

        LineColor_Picker.ItemsSource = possibleColors;
        FillColor_Picker.ItemsSource = possibleColors;
        BackgroundColor_Picker.ItemsSource = possibleColors;

        FillOpacity_Slider.Value = double.Parse(StyleItem.FillOpacity ?? "1", CultureInfo.InvariantCulture.NumberFormat);
        LineOpacity_Slider.Value = double.Parse(StyleItem.LineOpacity ?? "1", CultureInfo.InvariantCulture.NumberFormat);
        BackgroundOpacity_Slider.Value = double.Parse(StyleItem.BackgroundOpacity ?? "1", CultureInfo.InvariantCulture.NumberFormat);
    }

    private void LineColor_Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string colorName = (sender as Picker).SelectedItem.ToString();
        string hexColor = colorName.ToHex();
        LineColor_PreviewLine.Stroke = new SolidColorBrush(Color.FromArgb(hexColor));
        StyleItem.LineColor = hexColor;
    }

    private void FillOpacity_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        StyleItem.FillOpacity = e.NewValue.ToString();
    }

    private void LineOpacity_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        StyleItem.LineOpacity = e.NewValue.ToString();
    }

    private void BackgroundOpacity_Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        StyleItem.BackgroundOpacity = e.NewValue.ToString();
    }
}