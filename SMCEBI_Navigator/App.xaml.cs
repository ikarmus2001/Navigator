using Microsoft.Maui.Controls.Handlers.Items;

namespace SMCEBI_Navigator;

public partial class App : Application
{
	public App()
	{
        //CollectionViewHandler.Mapper.AppendToMapping("HeaderAndFooterFix", (_, collectionView) =>
        //{
        //    collectionView.AddLogicalChild(collectionView.Header as Element);
        //    collectionView.AddLogicalChild(collectionView.Footer as Element);
        //});
        InitializeComponent();

		MainPage = new AppShell();

        
    }
}
