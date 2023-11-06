using AppEstacioneJa.ViewModels.Vagas;

namespace AppEstacioneJa.Views.Vagas;

public partial class ListagemVagasView : ContentPage
{
    VagaViewModel viewModel;
    public ListagemVagasView()
    {
        InitializeComponent();
        viewModel = new VagaViewModel();
        BindingContext = viewModel;
    }
}