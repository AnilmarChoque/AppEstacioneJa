using AppEstacioneJa.ViewModels.Usuarios;

namespace AppEstacioneJa.Views.Usuarios;

public partial class GerenteView : ContentPage
{
        UsuarioViewModel viewModel;
        public GerenteView()
        {
            InitializeComponent();
            viewModel = new UsuarioViewModel();
            BindingContext = viewModel;
        }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DuvidasGerenteView());
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Navigation.PushAsync(new EstatisticasView());
    }

    private void Button_Clicked_2(object sender, EventArgs e)
    {
        DisplayAlert("Informação", "Essa opção será adicionada em breve!!", "Ok");
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Informação", "Deseja Sair mesmo?", "Sim", "Cancelar");

        if (result)
        {
            await Navigation.PopToRootAsync();
        }
    }
}