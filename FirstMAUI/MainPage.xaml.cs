using FirstMAUI.ViewModel;
using Plugin.Maui.Audio;

namespace FirstMAUI;

public partial class MainPage : ContentPage
{
    private readonly IAudioManager _audioManager;

    public MainPage(MainViewModel mvm, IAudioManager audioManager)
    {
        InitializeComponent();
        BindingContext = mvm;
        _audioManager = audioManager;
    }

    private async void myDrawing_DrawingLineCompleted(object sender, CommunityToolkit.Maui.Core.DrawingLineCompletedEventArgs e)
    {
        Stream stream = await myDrawing.GetImageStream(150, 150);
        newBandLogo.Source = ImageSource.FromStream(() => stream);
    }


}

  