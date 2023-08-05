namespace SMCEBI_Navigator;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(PlanDisplay), typeof(PlanDisplay));

    }
}
