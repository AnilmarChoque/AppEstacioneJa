namespace AppEstacioneJa
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Usuarios.EntradaView());
        }
    }
}