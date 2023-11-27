namespace AppEstacioneJa.Views.Usuarios;

public partial class DuvidasMotoristaView : ContentPage
{
	public DuvidasMotoristaView()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new MainPage());
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Alternar a visibilidade da resposta
        respostaLabel.IsVisible = !respostaLabel.IsVisible;
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        respostaLabel2.IsVisible = !respostaLabel2.IsVisible;
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        respostaLabel3.IsVisible = !respostaLabel3.IsVisible;
    }
}