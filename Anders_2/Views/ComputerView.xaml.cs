namespace Anders_2.Views;

public partial class ComputerView : ContentView
{
	public ComputerView()
    {
        InitializeComponent();

        // Load the default view on startup
        SwitchToView(new DashBoardHomeView());
    }


    // Dynamic, animated view-swapper function
    private async void SwitchToView(ContentView newView)
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

        // 2. Clear out old layout nodes completely
        MainContentContainer.Children.Clear();

        // 3. Prepare the new layout state (start invisible and offset slightly to the right)
        newView.Opacity = 0;
        newView.TranslationX = 20;

        // 4. Inject it into the container frame
        MainContentContainer.Children.Add(newView);

        // 5. Execute smooth slide-in animation
        await Task.WhenAll(
            newView.FadeToAsync(1, 250, Easing.CubicOut),
            newView.TranslateToAsync(0, 0, 250, Easing.CubicOut)
        );
    }
}

