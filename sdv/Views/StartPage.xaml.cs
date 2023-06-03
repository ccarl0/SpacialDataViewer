using System;

namespace sdv.Views;

public partial class StartPage : ContentPage
{
    private Random random;
    public StartPage()
	{
		InitializeComponent();
        random = new Random();
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
                { 0.1, 0.25, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.19, 0.4, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.35, 0.5, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.5, 0.63, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.6, 0.75, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

                { 0.9,1, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.8,1, new Animation(v => sdvIntro.TranslationY = v, -1000, 0, Easing.SinOut) }
            };
            //Commit the animation
            parentAnimation.Commit(this, "TransitionAnimation", 10, 1000, null, null, null);
        }

        else
        {
            var parentAnimation = new Animation
            {
                { 0.1, 0.25, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.19, 0.4, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.35, 0.5, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.5, 0.63, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.6, 0.75, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

                { 0.9,1, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.8,1, new Animation(v => sdvIntro.TranslationY = v, 1000, 0, Easing.SinOut) }
            };

            //Commit the animation
            parentAnimation.Commit(this, "TransitionAnimation", 10, 3000, null, null, null);
        }


    }

    async void LiftOffButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (this.AnimationIsRunning("OpenDashboardAnimation"))
            return;

        var parentAnimation = new Animation
        {
            //logos animation
            { 0.1, 0.3, new Animation(v => jaxaLogo.TranslationX = v, jaxaLogo.TranslationX, 1000, Easing.CubicIn) },
            { 0.2, 0.4, new Animation(v => boeingLogo.TranslationX = v, boeingLogo.TranslationX, -1000, Easing.CubicIn) },
            { 0.25, 0.45, new Animation(v => nasaLogo.TranslationX = v, nasaLogo.TranslationX, 1000, Easing.CubicIn) },
            { 0.4, 0.45, new Animation(v => spacexLogo.TranslationX = v, spacexLogo.TranslationX, -1000, Easing.CubicIn) },
            { 0.44, 0.62, new Animation(v => esaLogo.TranslationY = v, esaLogo.TranslationY, -1000, Easing.CubicIn) },
            

            //Intro Box Animation
            { 0.7,0.78, new Animation(v => sdvIntro.Opacity = v, 1, 0, Easing.CubicIn) },
            { 0.55,0.625, new Animation(v => introButton.TranslationY= v, introButton.TranslationY, 100, Easing.CubicIn) },
            { 0.6,0.8, new Animation(v => introTitleLabel.TranslationX= v, introTitleLabel.TranslationX, 1000, Easing.CubicIn) },
            { 0.63,0.7, new Animation(v => introTextLabel.TranslationX= v, introTextLabel.TranslationX, -1000, Easing.CubicIn) },

            //shuttle animation
            { 0.7, 0.9, new Animation(v => spaceshuttleIcon.Rotation = v, 0, 15, Easing.SinInOut) },
            { 0.7, 0.9, new Animation(v => spaceshuttleIcon.TranslationY = v, spaceshuttleIcon.TranslationY, -50, Easing.SinInOut) },
            { 0.9, 1, new Animation(v => spaceshuttleIcon.Rotation = v, 15, -15, Easing.SinInOut) },
            { 0.9, 1, new Animation(v => spaceshuttleIcon.TranslationY = v, -50, 0, Easing.SinInOut) },
            { 0.9, 1, new Animation(v => spaceshuttleIcon.Scale = v, spaceshuttleIcon.Scale, 0, Easing.BounceIn) }
        };


        var animationTaskCompletionSource = new TaskCompletionSource<bool>();

        parentAnimation.Commit(this, "OpenDashboardAnimation", 10, 4500, finished: (d, b) =>
        {
            animationTaskCompletionSource.SetResult(true);
        });

        await animationTaskCompletionSource.Task;

        Application.Current.MainPage = new NavigationPage(new DashboardPage());
    }
}