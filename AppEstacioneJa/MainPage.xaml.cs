using AppEstacioneJa.ViewModels.Usuarios;
using AppEstacioneJa.Views.Usuarios;

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
    }
}