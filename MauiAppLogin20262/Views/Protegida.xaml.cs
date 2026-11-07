using System.ComponentModel.Design;

namespace MauiAppLogin20262.Views;

public partial class Protegida : ContentPage
{
	public Protegida()
	{
		InitializeComponent();

        string? usuario_logado = null;

        Task.Run(async () =>
        {
            usuario_logado = await SecureStorage.GetAsync("usuario_logado");

            if (!string.IsNullOrEmpty(usuario_logado))
            {
                lbl_usuario.Text = $"Seja bem-vindo(a) {usuario_logado}!";
            }
        });
	}

    private async void OnDesconectarClicked(object sender, EventArgs e)
    {
        bool confirmacao = await DisplayAlertAsync(
            "Tem certeza?",
            "Deseja desconectar?",
            "Sim",
            "Não");

        if (confirmacao)
        {
            SecureStorage.Remove("usuario_logado");
            App.Current.MainPage = new NavigationPage(new Login());
        }
        else
        {
            App.Current.MainPage = new Protegida();

        }

            Navigation.PopAsync();
    }
}