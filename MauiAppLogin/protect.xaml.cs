namespace MauiAppLogin;

public partial class protect : ContentPage
{
	public protect()
	{
		InitializeComponent();

		string? usuario_logado = null;

		Task.Run(async () =>
		{
			usuario_logado = await SecureStorage.Default.GetAsync("usuario_logado");
			lbl_boasvindas.Text = $"bem vindo (a) {usuario_logado}";
		});
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		bool confirmasao = await DisplayAlert("Tem certeza?", "Sair do app?", "Sim", "Não");
		if (confirmasao)
		{
			SecureStorage.Default.Remove("Usuario_logado");
			App.Current.MainPage = new login();
		}
    }
}