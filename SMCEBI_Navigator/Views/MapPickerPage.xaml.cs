namespace SMCEBI_Navigator.Views;

public partial class MapPickerPage : ContentPage
{
    public MapPickerPage()
    {
        InitializeComponent();
        BindingContext = MapStorage.configs;
    }


    private void ChooseSavedMap()
    {
        //throw new NotImplementedException();
        //MapConfig.GetInstance().
        
        //var borders = new Dictionary<string, float[,]>
        //{
        //    { "BuildingC", new float[,] { { 5, 5 }, { 100, 5 }, { 100, 100 }, { 50, 100 }, { 5, 50 } } }
        //};
        //var borderStyle = new MapObjectStyle("borderStyle", "black")
        //{
        //    fillColor = "none",
        //    weight = 3,
        //    fillOpacity = 1
        //};
        //mapBuilder.SetBuildingShape(borders, borderStyle);


        //mapBuilder.AddLevel(levelName);
        

        //var roomStyle = new MapObjectStyle("singleRoomStyle", "red");
        //mapBuilder.AddRoom("SingleRoom", new float[,] { { 5, 5 }, { 10, 5 }, { 10, 10 }, { 5, 10 } }, roomStyle);
        
        //var x = (VerticalStackLayout)this.Content;

        //var child = x.Children.FirstOrDefault(child => child.GetType() == typeof(Editor)) as Editor;
        //child.Text = "cokolwiek";
    }

    private void SaveClicked()
    {
        // ExportJson();
    }

    // TODO: Add export button to actually use this method
    private async void ExportJson(string mapName)
    {
        Stream serializedMap = await MapStorage.ExportJsonMapByName(mapName);
        
        AppFileSaver.SaveFile(serializedMap, $"{mapName}.json");
    }

    //private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{

    //}
}