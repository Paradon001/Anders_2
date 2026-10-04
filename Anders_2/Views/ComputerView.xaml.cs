using Anders_2.ViewModels;
using Microsoft.Maui.Dispatching;


namespace Anders_2.Views;


public partial class ComputerView : ContentView

{
    public static ComputerView Instance { get; private set; }

    public Grid mainComputerView { get; private set; }

    public ComputerView()
    {
        InitializeComponent();

        // Load the default view on startup
        SwitchToView(new DashBoardHomeView());


        Instance = this;
    }

    private void OnAcademicsClicked(object sender, EventArgs e)
    {
        SwitchToView(new AcademicView());
        
    }
    // Dynamic, animated view-swapper function
    public async void SwitchToView(ContentView newView)
    {
        // 1. If there's an active view, smoothly fade it out first
        if (MainContentContainer.Children.Count > 0)
        {
            var currentView = MainContentContainer.Children[0] as VisualElement;
            if (currentView != null)
            {
                // Quick slide left and fade away animation
                await Task.WhenAll(
                    currentView.FadeToAsync(0, 150),
                    currentView.TranslateToAsync(-20, 0, 150)
                );
            }
        }

        newView.Opacity = 0;
        newView.TranslationX = 20;

        await Task.WhenAll(
            newView.FadeToAsync(1, 250, Easing.CubicOut),
            newView.TranslateToAsync(0, 0, 250, Easing.CubicOut)
        );
        MainThread.BeginInvokeOnMainThread(() =>
        {
           MainContentContainer.Children.Clear();
            MainContentContainer.Children.Add(newView);
        });
    }
}

