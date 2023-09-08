namespace SMCEBI_Navigator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.HomePage), typeof(Views.HomePage));
        Routing.RegisterRoute(nameof(Views.PlanDisplay), typeof(Views.PlanDisplay));
        Routing.RegisterRoute(nameof(Views.ConfigurationManager), typeof(Views.ConfigurationManager));

    }
}
