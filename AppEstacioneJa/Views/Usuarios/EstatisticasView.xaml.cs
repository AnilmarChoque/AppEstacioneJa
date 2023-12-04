using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Collections.Generic;
using System.Linq;
using AppEstacioneJa.ViewModels.UsuarioVagas;

namespace AppEstacioneJa.Views.Usuarios;

public partial class EstatisticasView : ContentPage
{
    UsuarioVagasViewModel viewModel;
    public EstatisticasView()
	{
		InitializeComponent();
        viewModel = new UsuarioVagasViewModel();
        BindingContext = viewModel;
    }
    private void ImageButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new GerenteView());
    }

}