using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Plugin.Maui.Audio;
using System.Collections.ObjectModel;

namespace FirstMAUI.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public Command DrawCompleted { get; set; }



    [ObservableProperty]
    string band;

    [ObservableProperty]
    ObservableCollection<string> bandItems;

    IConnectivity _connectivity;
    private readonly IAudioManager _audioManager;

    public MainViewModel(IConnectivity connectivity, IAudioManager audioManager)
    {
        //create a list of bands
        BandItems = new() { "Black Sabbath", "Judas Priest", "Whitesnake" };

        _connectivity = connectivity;
        _audioManager = audioManager;
    }

    [RelayCommand]
    async Task AddBand()
    {
        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("No Internet", "You are not connected to the internet", "OK");
            return;
        }


        BandItems.Add(Band);
        Band = string.Empty;
    }

    [RelayCommand]
    void DeleteBand(string colorName)
    {
        if (BandItems.Contains(colorName))
            BandItems.Remove(colorName);
    }

    [RelayCommand]
    private async Task OnPlayClicked()
    {
        IAudioPlayer player = _audioManager.CreatePlayer(await FileSystem.OpenAppPackageFileAsync("hardRock.mp3"));
        player.Play();
    }


}
