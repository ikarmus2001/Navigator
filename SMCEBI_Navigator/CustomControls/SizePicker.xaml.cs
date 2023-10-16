using SMCEBI_Navigator.Models;

namespace SMCEBI_Navigator.CustomControls;

public partial class SizePicker : ContentView
{
    // public static readonly BindableProperty ObjBuildingElementProperty
    //    = BindableProperty.Create(nameof(ObjBuildingElement), typeof(BuildingElement), typeof(BuildingElement),
    //        defaultBindingMode: BindingMode.TwoWay);

    //public BuildingElement ObjBuildingElement
    //{
    //    get => (BuildingElement)GetValue(ObjBuildingElementProperty);
    //    set => SetValue(ObjBuildingElementProperty, value);
    //}

    public SizePicker()
	{
		InitializeComponent();
	}

    public void AddPoint()
    {

    }

    private void Entry_Completed(object sender, EventArgs e)
    {
        if (sender is Entry entry)
        {
            if (entry.Text == string.Empty)
            {
                // parse string to double
                entry.Text = null;
            }
            else
            {
                entry.Text = entry.Text.Replace(',', '.');
            }
        }
        
    }
}