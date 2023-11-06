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
}