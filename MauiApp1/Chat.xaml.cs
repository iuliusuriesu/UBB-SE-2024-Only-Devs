namespace MauiApp1;

public partial class Chat : ContentPage
{
	public string MessegeText { get; set; }

	void OnBackClicked(object sender, EventArgs e) {
		
	}
	void OnCallClicked(object sender, EventArgs e) {

	}
	void OnFileClicked(object sender, EventArgs e) {

    }
    void OnImageClicked(object sender, EventArgs e) {

    }
    void OnMicrophoneClicked(object sender, EventArgs e) {

    }
    void OnMicrophoneReleased(object sender, EventArgs e) {

    }
    void OnSendClicked(object sender, EventArgs e) {

    }

    public Chat()
	{
		InitializeComponent();
		this.BindingContext = this;
	}
}
