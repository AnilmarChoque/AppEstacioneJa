using AppEstacioneJa.ViewModels.Vagas;

namespace AppEstacioneJa.Views.Vagas;

public partial class RotaVagasView : ContentPage
{
    VagaViewModel viewModel;
    public RotaVagasView()
    {
        InitializeComponent();
        viewModel = new VagaViewModel();
        BindingContext = viewModel;
    }
}