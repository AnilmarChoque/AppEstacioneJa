using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppEstacioneJa.Models;
using AppEstacioneJa.Models.Enuns;
using AppEstacioneJa.Services.Usuarios;
using System.ComponentModel;
using AppEstacioneJa.Views.Usuarios;
using AppEstacioneJa.Views.Vagas;

namespace AppEstacioneJa.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public ICommand RegistrarCommand { get; set; }
        public ICommand AutenticarCommand { get; set; }
        public ICommand DirecionarCadastroCommand { get; set; }
        public ICommand DirecionarMainPageCommand { get; set; }
        public ICommand DirecionarLoginCommand { get; set; }
        public ICommand DirecionarEntradaCommand { get; set; }
        public ICommand DirecionarListagemVagasCommand { get; set; }

        public UsuarioViewModel()
        {
            uService = new UsuarioService();
            InicializarCommands();
            _ = ObterPreferencias();
            _ = ObterTipoUsuario();
            Nome = Preferences.Get("UsuarioNome", string.Empty);
        }

        public void InicializarCommands()
        {
            RegistrarCommand = new Command(async () => await RegistrarUsuario());
            AutenticarCommand = new Command(async () => await AutenticarUsuario());
            DirecionarCadastroCommand = new Command(async () => await DirecionarParaCadastro());
            DirecionarListagemVagasCommand = new Command(async () => await DirecionarParaListagemVagas());
            DirecionarMainPageCommand = new Command(async () => await DirecionarParaMainPage());
            DirecionarLoginCommand = new Command(async () => await DirecionarParaLogin());
            DirecionarEntradaCommand = new Command(async () => await DirecionarParaEntrada());
        }

        #region AtribuitosPropriedade
        //As propriedade serão chamadas na View futuramente
        private string email = string.Empty;
        public string Email
        {
            get { return email; }
            set 
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set
            {
                nome = value;
                OnPropertyChanged();
            }
        }

        private string senha = string.Empty;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

        private string cpf;
        public string Cpf
        {
            get { return cpf; }
            set
            {
                cpf = value;
                OnPropertyChanged(nameof(Cpf));
            }
        }

        private ObservableCollection<TipoPreferencia> listaTiposPreferenciais;
        public ObservableCollection<TipoPreferencia> ListaTiposPreferenciais
        {
            get { return listaTiposPreferenciais; }
            set
            {
                if (value != null)
                {
                    listaTiposPreferenciais = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<TipoUsuario> listaTiposUsuario;
        public ObservableCollection<TipoUsuario> ListaTiposUsuarios
        {
            get { return listaTiposUsuario; }
            set
            {
                if (value != null)
                {
                    listaTiposUsuario = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        public async Task ObterPreferencias()
        {
            try
            {
                ListaTiposPreferenciais = new ObservableCollection<TipoPreferencia>();
                ListaTiposPreferenciais.Add(new TipoPreferencia() { Id = 1, Descricao = "Nenhuma" });
                ListaTiposPreferenciais.Add(new TipoPreferencia() { Id = 2, Descricao = "Pcd" });
                ListaTiposPreferenciais.Add(new TipoPreferencia() { Id = 3, Descricao = "Idoso" });
                ListaTiposPreferenciais.Add(new TipoPreferencia() { Id = 4, Descricao = "Gestante" });
                OnPropertyChanged(nameof(ListaTiposPreferenciais));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        private TipoPreferencia tipoPreferenciaSelecionado;
        public TipoPreferencia TipoPreferenciaSelecionado
        {
            get { return tipoPreferenciaSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoPreferenciaSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        private TipoUsuario tipoUsuarioSelecionado;
        public TipoUsuario TipoUsuarioSelecionado
        {
            get { return tipoUsuarioSelecionado; }
            set
            {
                if (value != null)
                {
                    tipoUsuarioSelecionado = value;
                    OnPropertyChanged();
                }
            }
        }

        public async Task ObterTipoUsuario()
        {
            try
            {
                ListaTiposUsuarios = new ObservableCollection<TipoUsuario>();
                ListaTiposUsuarios.Add(new TipoUsuario() { Id = 1, Descricao = "Cliente" });
                ListaTiposUsuarios.Add(new TipoUsuario() { Id = 2, Descricao = "Gerente" });
                OnPropertyChanged(nameof(ListaTiposUsuarios));
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        #region Métodos
        public async Task RegistrarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Email;
                u.Nome = Nome;
                u.Senha = Senha;
                u.Cpf = Cpf;
                u.Preferencia = (PreferenciaEnum)tipoPreferenciaSelecionado.Id;
                u.TipoUsuario = (TipoUsuarioEnum)tipoUsuarioSelecionado.Id;

                Usuario uRegistrado = await uService.PostResgistrarUsuarioAsync(u);

                if(uRegistrado.Id != 0)
                {
                    string mensagem = $"Usuário Id {uRegistrado.Id} registrado com sucesso.";
                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");

                    await Application.Current.MainPage.
                        Navigation.PopAsync();
                }
            }
            catch (Exception ex) 
            {
                await Application.Current.MainPage
                    .DisplayAlert("informação", ex.Message + "Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Email = Email;
                u.Senha = Senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);

                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    int usuarioTipoValue = (int)uAutenticado.TipoUsuario;
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Nome}.";
                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioEmail", uAutenticado.Email);
                    Preferences.Set("UsuarioNome", uAutenticado.Nome);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);
                    Preferences.Set("UsuarioTipo", usuarioTipoValue);

                    await Application.Current.MainPage
                    .DisplayAlert("Informação", mensagem, "Ok");


                    await Application.Current.MainPage.
                    Navigation.PushAsync(new GerenteView());

                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :C", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaCadastro()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new CadastroView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaListagemVagas()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new ListagemVagasView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaLogin()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new LoginView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaMainPage()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaEntrada()
        {
            try
            {
                await Application.Current.MainPage.
                    Navigation.PushAsync(new EntradaView());
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }


        #endregion
    }
}
