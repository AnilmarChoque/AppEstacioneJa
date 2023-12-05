using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppEstacioneJa.Services.Vagas;
using AppEstacioneJa.Models;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;
using System.ComponentModel;
using AppEstacioneJa.Views.Usuarios;
using System.Windows.Input;
using Microsoft.Identity.Client;
using AppEstacioneJa.Services.UsuarioVagas;

namespace AppEstacioneJa.ViewModels.Vagas
{
    public class VagaViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private VagaService vService;
        public ICommand DirecionarMenuCommand { get; set; }
        public VagaViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            vService = new VagaService(token);

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                ObterDados2();
                return true; // Repita a cada 5 minutos
            });
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                ObterDados();
                return true; // Repita a cada 5 minutos
            });
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                ObterDados3();
                return true; // Repita a cada 5 minutos
            });
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                ObterDados4();
                return true; // Repita a cada 5 minutos
            });


            _ = ObterDados();
            _ = ObterDados2();
            _ = ObterDados3();
            _ = ObterDados4();
            InicializarCommands();
        }
        public void InicializarCommands()
        {
            DirecionarMenuCommand = new Command(async () => await DirecionarParaMenu());
        }

        private Color backgroundColor2;

        public Color BackgroundColor2
        {
            get => backgroundColor2;
            set
            {
                backgroundColor2 = value;
                OnPropertyChanged(nameof(BackgroundColor2));
            }
        }

        private Color backgroundColor3;

        public Color BackgroundColor3
        {
            get => backgroundColor3;
            set
            {
                backgroundColor3 = value;
                OnPropertyChanged(nameof(BackgroundColor3));
            }
        }

        private Color backgroundColor4;

        public Color BackgroundColor4
        {
            get => backgroundColor4;
            set
            {
                backgroundColor4 = value;
                OnPropertyChanged(nameof(BackgroundColor4));
            }
        }

        private Color backgroundColor;

        public Color BackgroundColor
        {
            get => backgroundColor;
            set
            {
                backgroundColor = value;
                OnPropertyChanged(nameof(BackgroundColor));
            }
        }

        private long vagaId;
        public long VagaId
        {
            get => vagaId;
            set
            {
                vagaId = value;
                OnPropertyChanged();
            }
        }
        private long usuarioId;
        public long UsuarioId
        {
            get => usuarioId;
            set
            {
                usuarioId = value;
                OnPropertyChanged();
            }
        }

        public int veri = 0;
        public int veri2 = 0;
        public int veri3 = 0;
        public int veri4 = 0;

        public async Task ObterDados()
        {
            try
            {
                Vaga dados = await vService.GetVagaAsync(1);

                if (!string.IsNullOrEmpty(dados.Secao))
                {
                    int disponibilidadeTipoValue = (int)dados.Disponibilidade;

                    if(disponibilidadeTipoValue == 1)
                    {
                        BackgroundColor = new Color(25, 221, 8); // Cor verde
                        veri = 0;
                    }
                    else
                    {
                        BackgroundColor = new Color(235, 0, 0); // Cor vermelha
                        if(veri == 0)
                        {
                            UsuarioVaga uv = new UsuarioVaga();
                            uv.UsuarioId = 1;
                            uv.VagaId = 1;
                            veri = 1;
                            await vService.PostUsuarioVagaAsync(uv);

                        }
                        
                    }

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ObterDados2()
        {
            try
            {
                Vaga dados = await vService.GetVagaAsync(2);

                if (!string.IsNullOrEmpty(dados.Secao))
                {
                    int disponibilidadeTipoValue = (int)dados.Disponibilidade;

                    if (disponibilidadeTipoValue == 1)
                    {
                        BackgroundColor2 = new Color(25, 221, 8); // Cor verde
                        veri2 = 0;
                    }
                    else
                    {
                        BackgroundColor2 = new Color(235, 0, 0); // Cor vermelha
                        if (veri2 == 0)
                        {
                            UsuarioVaga uv = new UsuarioVaga();
                            uv.UsuarioId = 1;
                            uv.VagaId = 1;
                            veri2 = 1;
                            await vService.PostUsuarioVagaAsync(uv);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ObterDados3()
        {
            try
            {
                Vaga dados = await vService.GetVagaAsync(3);

                if (!string.IsNullOrEmpty(dados.Secao))
                {
                    int disponibilidadeTipoValue = (int)dados.Disponibilidade;

                    if (disponibilidadeTipoValue == 1)
                    {
                        BackgroundColor3 = new Color(25, 221, 8); // Cor verde
                        veri3 = 0;
                    }
                    else
                    {
                        BackgroundColor3 = new Color(235, 0, 0); // Cor vermelha
                        if (veri3 == 0)
                        {
                            UsuarioVaga uv = new UsuarioVaga();
                            uv.UsuarioId = 1;
                            uv.VagaId = 1;
                            veri3 = 1;
                            await vService.PostUsuarioVagaAsync(uv);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task ObterDados4()
        {
            try
            {
                Vaga dados = await vService.GetVagaAsync(4);

                if (!string.IsNullOrEmpty(dados.Secao))
                {
                    int disponibilidadeTipoValue = (int)dados.Disponibilidade;

                    if (disponibilidadeTipoValue == 1)
                    {
                        BackgroundColor4 = new Color(25, 221, 8); // Cor verde
                        veri4 = 0;
                    }
                    else
                    {
                        BackgroundColor4 = new Color(235, 0, 0); // Cor vermelha
                        if (veri4 == 0)
                        {
                            UsuarioVaga uv = new UsuarioVaga();
                            uv.UsuarioId = 1;
                            uv.VagaId = 1;
                            veri4 = 1;
                            await vService.PostUsuarioVagaAsync(uv);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        public async Task DirecionarParaMenu()
        {
            try
            {
                int tipo = Preferences.Get("UsuarioTipo", 0);
                if(tipo == 1)
                {
                    await Application.Current.MainPage.
                    Navigation.PushAsync(new MainPage());
                }
                else if(tipo == 2)
                {
                    await Application.Current.MainPage.
                    Navigation.PushAsync(new GerenteView());
                }
                else
                {
                    await Application.Current.MainPage
                    .DisplayAlert("Alerta", "Não encontrei de tipo: " + tipo, "Ok");
                }
                
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

    }
}
