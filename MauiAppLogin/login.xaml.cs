namespace MauiAppLogin;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<dadosUsuario> lista_usuarios = new List<dadosUsuario>()
			{
				new dadosUsuario
				{
					Usuario = "jonas",
					senha ="123"
				},
				new dadosUsuario
				{
					Usuario = "carlos",
					senha = "1234"
				}
			};

			dadosUsuario dados_digitados = new dadosUsuario()
			{
				Usuario = txt_usuario.Text,
				senha = txt_senha.Text
			};

			//linq
			if (lista_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.senha == i.senha)))
			{
			await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

				App.Current.MainPage = new protect();
			}else
			{
				throw new Exception("usuario ou senha incorreto");
			}
		}catch (Exception ex)
		{
			await DisplayAlert("ops", ex.Message, "Fecahr");
		}
    }

}