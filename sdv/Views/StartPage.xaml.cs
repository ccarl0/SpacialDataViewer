namespace sdv.Views;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
	}

    

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        if (VersionTracking.IsFirstLaunchForBuild(VersionTracking.CurrentBuild))
        {
            var parentAnimation = new Animation
            {
                //Planets Animation
                { 0.1, 0.25, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.19, 0.4, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.35, 0.5, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.5, 0.63, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.6, 0.75, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

                //Intro Box Animation
                { 0.9,1, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.8,1, new Animation(v => sdvIntro.TranslationY = v, -1000, 0, Easing.SinOut) }
            };
            //Commit the animation
            parentAnimation.Commit(this, "TransitionAnimation", 10, 4000, null, null, null);
        }

        else
        {
            var parentAnimation = new Animation
            {
                //Planets Animation
                { 0.1, 0.25, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.19, 0.4, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.35, 0.5, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.5, 0.63, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.6, 0.75, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

                //Intro Box Animation
                { 0.9,1, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.8,1, new Animation(v => sdvIntro.TranslationY = v, 1000, 0, Easing.SinOut) }
            };

            //Commit the animation
            parentAnimation.Commit(this, "TransitionAnimation", 10, 4000, null, null, null);
        }


    }

    async void ExploreNow_Clicked(System.Object sender, System.EventArgs e)
        => Application.Current.MainPage = new NavigationPage(new DashboardPage());
}