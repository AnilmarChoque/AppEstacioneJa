using AppEstacioneJa.ViewModels.Usuarios;

namespace AppEstacioneJa.Views.Usuarios;

public partial class EntradaView : ContentPage
{
    UsuarioViewModel viewModel;
    public EntradaView()
	{
		InitializeComponent();
        viewModel = new UsuarioViewModel();
        BindingContext = viewModel;
    }
}