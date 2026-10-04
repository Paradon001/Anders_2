using Syncfusion.Maui.Core.Hosting;
using static Anders_2.Views.PDFView;
using static PdfSharpCore.Pdf.PdfDictionary;

namespace Anders_2.Views;

public partial class PDFView2 : ContentView
{
	public PDFView2(Stream fileStream)
	{
		InitializeComponent();
        pdfViewer.DocumentSource = fileStream;
    }
	private void LoadPdf()
	{
    }
}