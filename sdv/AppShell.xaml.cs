namespace sdv;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
#if ANDROID
		flyOut.FlyoutBehavior = FlyoutBehavior.Flyout;
#else
		flyOut.FlyoutBehavior = FlyoutBehavior.Locked;
#endif
    }
}
