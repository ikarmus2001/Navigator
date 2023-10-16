using SMCEBI_Navigator.Models;
using System.StringExtensions;

namespace SMCEBI_Navigator.CustomControls;

public partial class StylePicker : ContentView
{
    public static readonly BindableProperty ObjElementStyleProperty 
        = BindableProperty.Create(nameof(ObjElementStyle), typeof(ElementStyle), typeof(ElementStyle), 
            defaultBindingMode: BindingMode.TwoWay); //, defaultValueCreator: NewStyle);

    public ElementStyle ObjElementStyle
    {
        get => (ElementStyle)GetValue(ObjElementStyleProperty);
        set => SetValue(ObjElementStyleProperty, value);
    }

    //private static object NewStyle(BindableObject bindable)
    //{
    //    bindable.SetValue(ElementStyleProperty, new ElementStyle());
    //    return bindable.GetValue(ElementStyleProperty);
    //}

    public StylePicker()
    {
        InitializeComponent();
        ObjElementStyle = new ElementStyle();
        SetPickersItems();
    }

    public StylePicker(ElementStyle es)
    {
        InitializeComponent();
        ObjElementStyle = es;
        SetPickersItems();
    }

    private void SetPickersItems()
    {
        //ObjElementStyle.LineColor
        //LineColor_PreviewRect.Fill = new SolidColorBrush(Color.FromRgb());
        LineColor_Picker.ItemsSource = new List<string>() { "Red", "Green", "Blue", "Black", "White" };
    }

    private void LineColor_Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        string hexColor = ((sender as Picker).SelectedItem as string).ToHex();
        LineColor_PreviewRect.Fill = new SolidColorBrush(Color.FromArgb(hexColor));
        ObjElementStyle.LineColor = hexColor;
    }
}