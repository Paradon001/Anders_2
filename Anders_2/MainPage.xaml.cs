
namespace Anders_2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
           
        }
        protected override void OnAppearing()
        {
            
            base.OnAppearing();
            // Detect device idiom at application startup
            if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
            {
                // Inject the full desktop view layout
                this.Content = new Views.ComputerView();
            }
            else
            {
                // Inject the mobile layout for Phones and Tablets
                this.Content = new Views.MobileView();
            }
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
          
        }
    }
}
