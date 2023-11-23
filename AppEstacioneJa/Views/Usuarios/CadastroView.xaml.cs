using AppEstacioneJa.ViewModels.Usuarios;
using System.Text.RegularExpressions;
namespace AppEstacioneJa.Views.Usuarios;

public partial class CadastroView : ContentPage
{
	UsuarioViewModel viewModel;
	public CadastroView()
	{
		InitializeComponent();

		viewModel = new UsuarioViewModel();
		BindingContext = viewModel;
	}

    private void ConfirmarButton_Clicked(object sender, EventArgs e)
    {
        if (ValidarNome())
        {
            if (ValidarCPF())
            {
                if (ValidarEmail())
                {
                    if (ValidarSenha())
                    {
                        if (VerificarPreferencia())
                        {
                            if(VerificarUsuario())
                            {
                                viewModel.RegistrarUsuario();
                            }
                            else
                            {
                                DisplayAlert("Erro", "Selecione um TIPO DE USUÁRIO", "Ok");
                            }
                        }
                        else
                        {
                            DisplayAlert("Erro", "Selecione uma PREFERENCIA", "Ok");
                        }
                    }
                    else
                    {
                        DisplayAlert("Erro", "Preencha o campo SENHA corretamente", "Ok");
                    }
                }
                else
                {
                    DisplayAlert("Erro", "Preencha o campo EMAIL corretamente", "Ok");
                }
            }
            else
            {
                DisplayAlert("Erro", "Preencha o campo CPF corretamente", "Ok");
            }
        }
        else
        {
            DisplayAlert("Erro", "Preencha o campo NOME corretamente", "Ok");
        }
    }

    private bool ValidarNome()
    {
        return !string.IsNullOrEmpty(viewModel.Nome);
    }

    private bool ValidarCPF()
    {
        if (string.IsNullOrWhiteSpace(viewModel.Cpf))
        {
            return false;
        }

        string cpfLimpo = new string(viewModel.Cpf.Where(char.IsDigit).ToArray());

        if (cpfLimpo.Length != 11 || cpfLimpo.Distinct().Count() == 1)
        {
            return false;
        }

        // Verifica se todos os dígitos são iguais
        if (cpfLimpo.All(c => c == cpfLimpo[0]))
        {
            return false;
        }

        // Calcula os dígitos verificadores
        int digitoVerificador1 = CalcularDigitoVerificador(cpfLimpo.Substring(0, 9));
        int digitoVerificador2 = CalcularDigitoVerificador(cpfLimpo.Substring(0, 10));

        return digitoVerificador1 == cpfLimpo[9] - '0' && digitoVerificador2 == cpfLimpo[10] - '0';
    }

    private int CalcularDigitoVerificador(string parteCpf)
    {
        int soma = 0;
        int multiplicador = parteCpf.Length + 1;

        foreach (char c in parteCpf)
        {
            soma += (c - '0') * multiplicador;
            multiplicador--;
        }

        int resto = soma % 11;

        return resto < 2 ? 0 : 11 - resto;
    }

    private bool ValidarEmail()
    {
        string email = viewModel.Email;
        string pattern = @"^[\w-]+(\.[\w-]+)*@([\w-]+\.)+[a-zA-Z]{2,7}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    private bool ValidarSenha()
    {
        return !string.IsNullOrEmpty(viewModel.Senha);
    }

    private bool VerificarPreferencia()
    {
        return viewModel.TipoPreferenciaSelecionado != null;
    }

    private bool VerificarUsuario()
    {
        return viewModel.TipoUsuarioSelecionado != null;
    }
}