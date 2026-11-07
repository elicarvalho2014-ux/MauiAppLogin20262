using MauiAppLogin20262.Models;

namespace MauiAppLogin20262.Views;

public partial class Login : ContentPage
{

	List<Usuario> Lista_usuario = new()
	{
		new Usuario { Email = "teste@teste.com.br", Senha = "123" },
        new Usuario { Email = "aluno@ead.com.br", Senha = "456" },

    };

	public Login()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {

        try
        {
            string email_digitado = txt_email.Text;
            string senha_digitada = txt_senha.Text;

            bool encontrado = Lista_usuario.Any(i => i.Email == email_digitado && i.Senha == senha_digitada );

            if(encontrado)
            {
                SecureStorage.SetAsync("usuario_logado", email_digitado);

                Navigation.PushAsync(new Protegida());

            }
            else
            {
                DisplayAlertAsync("Ops", "Usuário não encontrado", "OK");
            }

            //Navigation.PushAsync(new Protegida());
        }

        catch (Exception ex)
        {
            DisplayAlertAsync("Ops", ex.Message, "OK");
        }
    }
}