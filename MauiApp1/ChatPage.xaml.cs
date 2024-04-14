using MauiApp1.ViewModel;

namespace MauiApp1;

[QueryProperty(nameof(ChatId), "chatId")]
public partial class ChatPage : ContentPage
{
    private readonly ChatPageViewModel viewModel;

    private int _chatId;
    public int ChatId
    {
        get => _chatId;
        set
        {
            _chatId = value;
            viewModel.SetChatId(_chatId);
        }
    }

    public ChatPage(ChatPageViewModel viewModel)
    {
        InitializeComponent();
        
        this.viewModel = viewModel;
        this.BindingContext = viewModel;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        string route = "///MainPage";
        await Shell.Current.GoToAsync(route);
    }

    void OnCallClicked(object sender, EventArgs e)
    {

    }
    void OnFileClicked(object sender, EventArgs e)
    {

    }
    void OnImageClicked(object sender, EventArgs e)
    {

    }
    void OnMicrophoneClicked(object sender, EventArgs e)
    {

    }
    void OnMicrophoneReleased(object sender, EventArgs e)
    {

    }
    void OnSendClicked(object sender, EventArgs e)
    {

    }
}
