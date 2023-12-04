using AppEstacioneJa.Services.UsuarioVagas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppEstacioneJa.ViewModels.UsuarioVagas
{
    public class UsuarioVagasViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private UsuarioVagasService uvService;

        public UsuarioVagasViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uvService = new UsuarioVagasService(token);
            _ = ObterTotalVagasAsync();
            _ = ObterTotalVagas2Async();
            _ = ObterTotalVagas3Async();
            _ = ObterTotalVagas4Async();
        }

        private string height1 = string.Empty;
        public string Height1
        {
            get { return height1; }
            set
            {
                height1 = value;
                OnPropertyChanged();
            }
        }

        private Thickness margin1;
        public Thickness Margin1
        {
            get { return margin1; }
            set
            {
                margin1 = value;
                OnPropertyChanged();
            }
        }

        private int totalUsuarios;
        public int TotalUsuarios
        {
            get { return totalUsuarios; }
            set
            {
                totalUsuarios = value;
                OnPropertyChanged();
            }
        }

        private string height2 = string.Empty;
        public string Height2
        {
            get { return height2; }
            set
            {
                height2 = value;
                OnPropertyChanged();
            }
        }

        private Thickness margin2;
        public Thickness Margin2
        {
            get { return margin2; }
            set
            {
                margin2 = value;
                OnPropertyChanged();
            }
        }

        private int totalUsuarios2;
        public int TotalUsuarios2
        {
            get { return totalUsuarios2; }
            set
            {
                totalUsuarios2 = value;
                OnPropertyChanged();
            }
        }

        private string height3 = string.Empty;
        public string Height3
        {
            get { return height3; }
            set
            {
                height3 = value;
                OnPropertyChanged();
            }
        }

        private Thickness margin3;
        public Thickness Margin3
        {
            get { return margin3; }
            set
            {
                margin3 = value;
                OnPropertyChanged();
            }
        }

        private int totalUsuarios3;
        public int TotalUsuarios3
        {
            get { return totalUsuarios3; }
            set
            {
                totalUsuarios3 = value;
                OnPropertyChanged();
            }
        }

        private string height4 = string.Empty;
        public string Height4
        {
            get { return height4; }
            set
            {
                height4 = value;
                OnPropertyChanged();
            }
        }

        private Thickness margin4;
        public Thickness Margin4
        {
            get { return margin4; }
            set
            {
                margin4 = value;
                OnPropertyChanged();
            }
        }

        private int totalUsuarios4;
        public int TotalUsuarios4
        {
            get { return totalUsuarios4; }
            set
            {
                totalUsuarios4 = value;
                OnPropertyChanged();
            }
        }

        public async Task ObterTotalVagasAsync()
        {
            try
            {
                TotalUsuarios = await uvService.ContarVagas1Async();
                if(TotalUsuarios == 0)
                {
                    Height1 = "0";
                    Margin1 = new Thickness(20, 250, 0, 0);
                }
                else if (TotalUsuarios == 1)
                {
                    Height1 = "20";
                    Margin1 = new Thickness(20, 230, 0, 0);
                }
                else if (TotalUsuarios == 2)
                {
                    Height1 = "60";
                    Margin1 = new Thickness(20, 190, 0, 0);
                }
                else if (TotalUsuarios == 3)
                {
                    Height1 = "100";
                    Margin1 = new Thickness(20, 150, 0, 0);
                }
                else if (TotalUsuarios == 4)
                {
                    Height1 = "140";
                    Margin1 = new Thickness(20, 110, 0, 0);
                }
                else if (TotalUsuarios == 5)
                {
                    Height1 = "180";
                    Margin1 = new Thickness(20, 70, 0, 0);
                }
                else if (TotalUsuarios >= 6)
                {
                    Height1 = "220";
                    Margin1 = new Thickness(20, 30, 0, 0);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Total Usuarios: " + TotalUsuarios, "Ok");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message + " Erro: " + TotalUsuarios, "Ok");
            }
        }

        public async Task ObterTotalVagas2Async()
        {
            try
            {
                TotalUsuarios2 = await uvService.ContarVagas2Async();
                if (TotalUsuarios2 == 0)
                {
                    Height2 = "0";
                    Margin2 = new Thickness(40, 250, 0, 0);
                }
                else if (TotalUsuarios2 == 1)
                {
                    Height2 = "20";
                    Margin2 = new Thickness(40, 230, 0, 0);
                }
                else if (TotalUsuarios2 == 2)
                {
                    Height2 = "60";
                    Margin2 = new Thickness(40, 190, 0, 0);
                }
                else if (TotalUsuarios2 == 3)
                {
                    Height2 = "100";
                    Margin2 = new Thickness(40, 150, 0, 0);
                }
                else if (TotalUsuarios2 == 4)
                {
                    Height2 = "140";
                    Margin2 = new Thickness(40, 110, 0, 0);
                }
                else if (TotalUsuarios2 == 5)
                {
                    Height2 = "180";
                    Margin2 = new Thickness(40, 70, 0, 0);
                }
                else if (TotalUsuarios2 >= 6)
                {
                    Height2 = "220";
                    Margin2 = new Thickness(40, 30, 0, 0);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Total Usuarios: " + TotalUsuarios2, "Ok");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message + " Erro: " + TotalUsuarios2, "Ok");
            }
        }

        public async Task ObterTotalVagas3Async()
        {
            try
            {
                TotalUsuarios3 = await uvService.ContarVagas3Async();
                if (TotalUsuarios3 == 0)
                {
                    Height3 = "0";
                    Margin3 = new Thickness(40, 250, 0, 0);
                }
                else if (TotalUsuarios3 == 1)
                {
                    Height3 = "20";
                    Margin3 = new Thickness(40, 230, 0, 0);
                }
                else if (TotalUsuarios3 == 2)
                {
                    Height3 = "60";
                    Margin3 = new Thickness(40, 190, 0, 0);
                }
                else if (TotalUsuarios3 == 3)
                {
                    Height3 = "100";
                    Margin3 = new Thickness(40, 150, 0, 0);
                }
                else if (TotalUsuarios3 == 4)
                {
                    Height3 = "140";
                    Margin3 = new Thickness(40, 110, 0, 0);
                }
                else if (TotalUsuarios3 == 5)
                {
                    Height3 = "180";
                    Margin3 = new Thickness(40, 70, 0, 0);
                }
                else if (TotalUsuarios3 >= 6)
                {
                    Height3 = "220";
                    Margin3 = new Thickness(40, 30, 0, 0);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Total Usuarios: " + TotalUsuarios3, "Ok");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message + " Erro: " + TotalUsuarios3, "Ok");
            }
        }

        public async Task ObterTotalVagas4Async()
        {
            try
            {
                TotalUsuarios4 = await uvService.ContarVagas4Async();
                if (TotalUsuarios4 == 0)
                {
                    Height4 = "0";
                    Margin4 = new Thickness(40, 250, 0, 0);
                }
                else if (TotalUsuarios4 == 1)
                {
                    Height4 = "20";
                    Margin4 = new Thickness(40, 230, 0, 0);
                }
                else if (TotalUsuarios4 == 2)
                {
                    Height4 = "60";
                    Margin4 = new Thickness(40, 190, 0, 0);
                }
                else if (TotalUsuarios4 == 3)
                {
                    Height4 = "100";
                    Margin4 = new Thickness(40, 150, 0, 0);
                }
                else if (TotalUsuarios4 == 4)
                {
                    Height4 = "140";
                    Margin4 = new Thickness(40, 110, 0, 0);
                }
                else if (TotalUsuarios4 == 5)
                {
                    Height4 = "180";
                    Margin4 = new Thickness(40, 70, 0, 0);
                }
                else if (TotalUsuarios4 >= 6)
                {
                    Height4 = "220";
                    Margin4 = new Thickness(40, 30, 0, 0);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Erro", "Total Usuarios: " + TotalUsuarios4, "Ok");
                }

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", ex.Message + " Erro: " + TotalUsuarios4, "Ok");
            }
        }
    }
}
