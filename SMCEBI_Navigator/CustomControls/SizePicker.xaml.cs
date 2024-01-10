using MapBuilder_API_Base;
using System.Collections.ObjectModel;

namespace SMCEBI_Navigator.CustomControls;

public partial class SizePicker : ContentView
{
    public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
            propertyName: nameof(Items),
            returnType: typeof(IEnumerable<PointClass>),
            declaringType: typeof(SizePicker),
            defaultValue: new List<PointClass>(),
            defaultBindingMode: BindingMode.TwoWay);

    public IEnumerable<PointClass> Items
    {
        get => (IEnumerable<PointClass>)GetValue(ItemsProperty);
        set => SetValue(ItemsProperty, value);
    }

    public SizePicker()
    {
        InitializeComponent();
    }

    private void AddPoint_Clicked(object sender, EventArgs e)
    {
        _ = Items.Append(new PointClass());
        (Items as ObservableCollection<PointClass>).Add(new PointClass());
    }

    private void DeletePoint_Clicked(object sender, EventArgs e)
    {

        InvalidateLayout();
    }
}