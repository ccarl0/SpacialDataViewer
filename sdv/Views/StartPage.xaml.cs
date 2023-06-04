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
#if DEBUG
    protected override async void OnAppearing()
    {

        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation
            {
                { 0.1, 0.25, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.23, 0.31, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.3, 0.4, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.39, 0.46, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.45, 0.53, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

                { 0.49,0.7, new Animation(v => sdvIntro.TranslationY = v, 1000, 0, Easing.SinOut) },
                { 0.5,0.7, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },

                { 0.8,1, new Animation(v => introButton.TranslationY = v, -100, 0, Easing.SinOut) },
                { 0.84,1, new Animation(v => introButton.Opacity = v, 0, 1, Easing.SinInOut) }
            };

        //Commit the animation
        parentAnimation.Commit(this, "TransitionAnimation", 10, 10, null, null, null);
    }
    void LiftOffButton_Clicked(System.Object sender, System.EventArgs e)
    {
        Application.Current.MainPage = new AppShell();
    }
#else

protected override async void OnAppearing()
    {

        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation
            {
                { 0.1, 0.25, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.23, 0.31, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.3, 0.4, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.39, 0.46, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
                { 0.45, 0.53, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

                { 0.49,0.7, new Animation(v => sdvIntro.TranslationY = v, 1000, 0, Easing.SinOut) },
                { 0.5,0.7, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },

                { 0.8,1, new Animation(v => introButton.TranslationY = v, -100, 0, Easing.SinOut) },
                { 0.84,1, new Animation(v => introButton.Opacity = v, 0, 1, Easing.SinInOut) }
            };

        //Commit the animation
        parentAnimation.Commit(this, "TransitionAnimation", 50, 3000, null, null, null);
    }

    async void LiftOffButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (this.AnimationIsRunning("OpenDashboardAnimation"))
            return;

        var parentAnimation = new Animation
        {
            //logos animation
            { 0.1, 0.23, new Animation(v => jaxaLogo.TranslationX = v, jaxaLogo.TranslationX, 1000, Easing.CubicIn) },
            { 0.18, 0.25, new Animation(v => boeingLogo.TranslationX = v, boeingLogo.TranslationX, -1000, Easing.CubicIn) },
            { 0.23, 0.4, new Animation(v => nasaLogo.TranslationX = v, nasaLogo.TranslationX, 1000, Easing.CubicIn) },
            { 0.28, 0.43, new Animation(v => spacexLogo.TranslationX = v, spacexLogo.TranslationX, -1000, Easing.CubicIn) },
            { 0.32, 0.5, new Animation(v => esaLogo.TranslationY = v, esaLogo.TranslationY, -1000, Easing.CubicIn) },
            

            //Intro Box Animation
            { 0.5,0.7, new Animation(v => sdvIntro.Opacity = v, 1, 0, Easing.CubicIn) },
            { 0.46,0.525, new Animation(v => introButton.TranslationY= v, introButton.TranslationY, 100, Easing.CubicIn) },
            { 0.57,0.6, new Animation(v => introTitleLabel.TranslationX= v, introTitleLabel.TranslationX, 1000, Easing.CubicIn) },
            { 0.59,0.68, new Animation(v => introTextLabel.TranslationX= v, introTextLabel.TranslationX, -1000, Easing.CubicIn) },

            //shuttle animation
            { 0.7, 0.9, new Animation(v => spaceshuttleIcon.Rotation = v, 0, 15, Easing.SinInOut) },
            { 0.6, 0.9, new Animation(v => spaceshuttleIcon.TranslationY = v, spaceshuttleIcon.TranslationY, -50, Easing.SinInOut) },
            { 0.9, 1, new Animation(v => spaceshuttleIcon.Rotation = v, 15, -15, Easing.SinInOut) },
            { 0.9, 1, new Animation(v => spaceshuttleIcon.TranslationY = v, -50, 0, Easing.SinInOut) },
            { 0.9, 1, new Animation(v => spaceshuttleIcon.Scale = v, spaceshuttleIcon.Scale, 0, Easing.BounceIn) }
        };


        var animationTaskCompletionSource = new TaskCompletionSource<bool>();

        parentAnimation.Commit(this, "OpenDashboardAnimation", 10, 3000, finished: (d, b) =>
        {
            animationTaskCompletionSource.SetResult(true);
        });

        await animationTaskCompletionSource.Task;

        Application.Current.MainPage = new AppShell();
    }
#endif
}