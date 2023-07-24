namespace DrawingMAUI
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void myDrawing_DrawingLineCompleted(object sender, CommunityToolkit.Maui.Core.DrawingLineCompletedEventArgs e)
        {
            Stream stream = await myDrawing.GetImageStream(150, 150);
            newBandLogo.Source = ImageSource.FromStream(() => stream);
        }
    }
}