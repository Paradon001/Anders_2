using BitMiracle.LibTiff.Classic;
using Microsoft.Extensions.Hosting;
using Syncfusion.Maui.Core.Hosting;
using static Anders_2.Views.ComputerView;

namespace Anders_2.Views;

public partial class PDFView : ContentView
{
    public static PDFView Instance { get; private set; }

    public PDFView()
	{
        InitializeComponent();
    }
    public async void OnAddFileClicked(object sender, EventArgs e)
    {
        AcademicImage.IsVisible = true;

        var fileResult = await FilePicker.Default.PickAsync(new PickOptions
        {
            PickerTitle = "Please select a PDF file",
            FileTypes = FilePickerFileType.Pdf
        });

        if (fileResult != null)
        {
            // Handle the selected PDF file here
            var filePath = fileResult.FullPath;

            // You can now use the filePath to display or process the PDF
             AcademicImage.IsVisible = true;
             PDFborder.IsVisible = true;
             selectedPDFname.Text = fileResult.FileName;

            Stream fileStream = await fileResult.OpenReadAsync();

            // 3. Create the new full-screen page, handing it the stream
            var destinationPage = new PDFView2(fileStream);
        }
        else
        {
            await App.Current.MainPage.DisplayAlertAsync("Cancelled", "No file was selected.", "OK");
        }
        var button =sender as Button;
    }
    private async void OnViewPDFClicked(object sender, EventArgs e)
    {
        OnAddFileClicked(sender, e);
        await ComputerView.Instance.SwitchToView(new PDFView2());
    }

}