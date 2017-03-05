using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TeamChat
{
	public partial class TeamChatPage : ContentPage
	{
		public TeamChatPage()
		{
			InitializeComponent();

			Device.OnPlatform(
				iOS: () =>
			{
				Padding = new Thickness(0, 20, 0, 0);
			});

			NavigationPage.SetHasNavigationBar(this, false);
			buttonLogin.Clicked += async (object sender, EventArgs e) =>
			{
				loginActivityIndicator.IsRunning = true;
				await Navigation.PushAsync(new ChatWindowPage(apiKeyEntry.Text));
				loginActivityIndicator.IsRunning = false;
			};

			buttonSignUp.Clicked += async (object sender, EventArgs e) =>
			{
				await Navigation.PushAsync(new SignupPage());
			};
		
		}
	}
}
