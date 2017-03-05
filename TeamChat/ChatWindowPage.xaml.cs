using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace TeamChat
{
	public partial class ChatWindowPage : ContentPage
	{
		private static HttpClient httpClient;
		private static string ApiKey;
		public ChatWindowPage(string apiKey)
		{
			InitializeComponent();
			httpClient = new HttpClient();
			ApiKey = apiKey;
			messageEditor.Completed +=  (object sender, EventArgs e) =>
			{
				messageLabel.Text = TranslateToEnglish(messageEditor.Text, ApiKey);
			};
		}

		private string TranslateToEnglish(string inputText, string apiKey)
		{ 
			httpClient.BaseAddress = new Uri("https://translation.googleapis.com/language/translate/v2");
			var result = httpClient.GetAsync("?key=" + apiKey + "&target=" + "en" + "&q=" + inputText).Result;
			var jsonString =  result.Content.ReadAsStringAsync().Result;

			var text = JObject.Parse(jsonString).SelectToken("data").SelectToken("translations")[0].SelectToken("translatedText").Value<string>();
			return text;

		}
	}
}
