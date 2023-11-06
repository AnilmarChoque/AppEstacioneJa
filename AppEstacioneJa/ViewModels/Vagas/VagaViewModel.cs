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

namespace AppEstacioneJa.ViewModels.Vagas
{
    public class VagaViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private VagaService vService;
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

                    }
                    else
                    {
                        BackgroundColor = new Color(235, 0, 0); // Cor vermelha
                    }

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

                    }
                    else
                    {
                        BackgroundColor2 = new Color(235, 0, 0); // Cor vermelha
                    }

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

                    }
                    else
                    {
                        BackgroundColor3 = new Color(235, 0, 0); // Cor vermelha
                    }

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

                    }
                    else
                    {
                        BackgroundColor4 = new Color(235, 0, 0); // Cor vermelha
                    }

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

    }
}
