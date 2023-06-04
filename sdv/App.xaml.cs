using sdv.Views;

namespace sdv;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new StartPage();

		Routing.RegisterRoute("settings", typeof(SettingsPage));
		Routing.RegisterRoute("dashboard", typeof(DashboardPage));
	}
}
