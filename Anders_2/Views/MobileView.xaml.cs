using static Microsoft.Maui.ApplicationModel.Permissions;
using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Anders_2.Views;

public partial class MobileView : ContentView
{
    double panX, panY;

    public MobileView()
    {
        InitializeComponent();

        SwitchToView(new MobileDashboardHomeView());

    }
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
    
     public void OnPanUpdated(object sender, PanUpdatedEventArgs e)
    {
        switch (e.StatusType)
        {
            case GestureStatus.Running:
                // Translate and pan.
                double boundsX = Content.Width;
                double boundsY = Content.Height;
                Content.TranslationX = Math.Clamp(panX + e.TotalX, -boundsX,
    boundsX);
                Content.TranslationY = Math.Clamp(panY + e.TotalY, -boundsY,
    boundsY);
                break;
            case GestureStatus.Completed:
                // Store the translation applied during the pan
                panX = Content.TranslationX;
                panY = Content.TranslationY;
                break;
        }
    }

    public class PanContainer : ContentView
    {
        public PanContainer()
        {
            var panGesture = new PanGestureRecognizer();
            panGesture.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(panGesture);
        }
        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (Parent is MobileView mobileView)
            {
                mobileView.OnPanUpdated(sender, e);
            }
        }
    }

}




