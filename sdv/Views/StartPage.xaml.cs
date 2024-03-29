using System;

namespace sdv.Views;

public partial class StartPage : ContentPage
{
    public StartPage()
    {
        InitializeComponent();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (this.AnimationIsRunning("TransitionAnimation"))
            return;

        var parentAnimation = new Animation{
            { 0.35, 0.5, new Animation(v => esaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
            { 0.4, 0.6, new Animation(v => boeingLogo.Opacity = v, 0, 1, Easing.CubicIn) },
            { 0.5, 0.65, new Animation(v => jaxaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
            { 0.6, 0.75, new Animation(v => nasaLogo.Opacity = v, 0, 1, Easing.CubicIn) },
            { 0.7, 0.8, new Animation(v => spacexLogo.Opacity = v, 0, 1, Easing.CubicIn) },

            { 0.49,0.8, new Animation(v => sdvIntro.TranslationY = v, 1000, 0, Easing.SinOut) },
            { 0.5,0.75, new Animation(v => sdvIntro.Opacity = v, 0, 1, Easing.CubicIn) },

            { 0.7,1, new Animation(v => introButton.TranslationY = v, -100, 0, Easing.SinOut) },
            { 0.84,1, new Animation(v => introButton.Opacity = v, 0, 1, Easing.SinInOut) }
        };

        //Commit the animation
        parentAnimation.Commit(this, "TransitionAnimation", 5, 3200, null, null, null);
    }

    async void LiftOffButton_Clicked(System.Object sender, System.EventArgs e)
    {
        if (this.AnimationIsRunning("OpenDashboardAnimation"))
            return;

        var parentAnimation = new Animation
        {
            //Intro Box Animation
            { 0.2,0.3, new Animation(v => sdvIntro.Opacity = v, 1, 0, Easing.CubicIn) },
            { 0.1,0.3, new Animation(v => introButton.TranslationY= v, introButton.TranslationY, 100, Easing.CubicIn) },
            { 0.1,0.3, new Animation(v => introTitleLabel.TranslationX= v, introTitleLabel.TranslationX, 1000, Easing.CubicIn) },
            { 0.1,0.3, new Animation(v => introTextLabel.TranslationX= v, introTextLabel.TranslationX, -1000, Easing.CubicIn) },

            //logos animation
            { 0.1, 0.23, new Animation(v => jaxaLogo.TranslationX = v, jaxaLogo.TranslationX, 1000, Easing.CubicIn) },
            { 0.18, 0.25, new Animation(v => boeingLogo.TranslationX = v, boeingLogo.TranslationX, -1000, Easing.CubicIn) },
            { 0.23, 0.4, new Animation(v => nasaLogo.TranslationX = v, nasaLogo.TranslationX, 1000, Easing.CubicIn) },
            { 0.28, 0.43, new Animation(v => spacexLogo.TranslationX = v, spacexLogo.TranslationX, -1000, Easing.CubicIn) },
            { 0.32, 0.5, new Animation(v => esaLogo.TranslationY = v, esaLogo.TranslationY, -1000, Easing.CubicIn) },

        };

        var animationTaskCompletionSource = new TaskCompletionSource<bool>();


        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1100);
            rocketSKLottieView.IsAnimationEnabled = true;
        });



        parentAnimation.Commit(this, "OpenDashboardAnimation", 5, 4000, finished: (d, b) =>
        {
            animationTaskCompletionSource.SetResult(true);
        });

        await animationTaskCompletionSource.Task;


        Application.Current.MainPage = new AppShell();
    }
}