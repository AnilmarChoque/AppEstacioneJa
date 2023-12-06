using AppEstacioneJa.ViewModels.Usuarios;
using AppEstacioneJa.Views.Usuarios;
using AppEstacioneJa.Views.Vagas;

namespace AppEstacioneJa
{
    public partial class MainPage : ContentPage
    {
        UsuarioViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            viewModel = new UsuarioViewModel();
            BindingContext = viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new DuvidasMotoristaView());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RotaVagasView());
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert("Informação", "Deseja Sair mesmo?", "Sim", "Cancelar");

            if (result)
            {
                await Navigation.PopToRootAsync();
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            DisplayAlert("Informação", "Essa opção será adicionada em breve!!", "Ok");
        }
    }
}