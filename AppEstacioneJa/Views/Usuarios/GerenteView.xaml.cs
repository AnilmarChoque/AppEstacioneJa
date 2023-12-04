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
}