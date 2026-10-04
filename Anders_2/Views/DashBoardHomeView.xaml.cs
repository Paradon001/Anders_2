using System.Security.Cryptography.X509Certificates;
using Anders_2.ViewModels;

namespace Anders_2;

public partial class DashBoardHomeView : ContentView
{
	private DashboardCarouselViewModel _newView = new DashboardCarouselViewModel();
	public DashBoardHomeView()
	{
		InitializeComponent();
		BindingContext = _newView;
    }
}