using SMCEBI_Navigator.Models;
using System.StringExtensions;

namespace SMCEBI_Navigator.CustomControls;

public partial class ElementPreview : ContentView
{
    public static readonly BindableProperty PreviewElementProperty = BindableProperty.Create(
        propertyName: nameof(PreviewElement), 
        returnType: typeof(BuildingElement), 
        declaringType: typeof(ElementPreview));

    public BuildingElement PreviewElement
    {
        get => (BuildingElement)GetValue(PreviewElementProperty);
        set => SetValue(PreviewElementProperty, value);
    }

    public static readonly BindableProperty ControlVisibilityProperty = BindableProperty.Create(
        propertyName: nameof(ControlVisibility),
        returnType: typeof(bool),
        declaringType: typeof(ElementPreview));

    public bool ControlVisibility
    {
        get => (bool)GetValue(ControlVisibilityProperty);
        set => SetValue(ControlVisibilityProperty, value);
    }

    public PointCollection Points { get; set; }
    public Color Fill
    {
        get
        {
            try { return PreviewElement.Style.FillColor.ToHex().ToColor(); }
            catch { return Color.FromArgb("#000000"); }
        }
    }

    public Color BorderColor
    {
        get
        {
            try { return PreviewElement.Style.LineColor.ToHex().ToColor(); }
            catch(Exception) { return Color.FromArgb("#000000"); }
        }
    }

    public ElementPreview()
    {
        InitializeComponent();
        Refresh();
    }

    internal void Refresh()
    {
        Points = new PointCollection();

        if (PreviewElement == null) return;
        foreach (var c in PreviewElement.Corners)
        {
            Points.Add(c.ToPoint());
        }
    }
}