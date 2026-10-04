using Anders_2;
using Anders_2.ViewModels;
using Anders_2.Views;
using static Anders_2.Views.ComputerView;
using static Anders_2.Views.PDFView;
using Microsoft.Maui.Controls;

namespace Anders_2.Views;

public partial class AcademicView : ContentView
{
    public static ComputerView _mainComputerView;
    public AcademicView()
    {
        InitializeComponent();
    }

    private void OnPDFViewClicked(object sender, EventArgs e)
    {
        ComputerView.Instance.SwitchToView(new PDFView());
    }
}


