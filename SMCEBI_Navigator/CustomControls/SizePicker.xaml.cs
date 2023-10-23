using MapBuilder_API_Base;
using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator.CustomControls;

public partial class SizePicker : ContentView
{
    // public static readonly BindableProperty ObjBuildingElementProperty
    //    = BindableProperty.Create(nameof(ObjBuildingElement), typeof(BuildingElement), typeof(BuildingElement),
    //        defaultBindingMode: BindingMode.TwoWay);

    public BuildingElement ItemsSource
    {
        get => _itemsSource;
        set
        {
            _itemsSource = value;
            OnPropertyChanged();
        }
    }
    private BuildingElement _itemsSource;


    public SizePicker()
    {
        InitializeComponent();
    }

    public void AddPoint()
    {

    }

    private void AddPoint_Clicked(object sender, EventArgs e)
    {
        (BindingContext as IEnumerable<PointClass>).Append(new PointClass());
        InvalidateLayout();
    }

    private void DeletePoint_Clicked(object sender, EventArgs e)
    {
        (sender as Button).BindingContext = null;
        InvalidateLayout();
    }
}