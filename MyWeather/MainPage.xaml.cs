using System;
using System.Net.Http;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace MyWeather
{
    public partial class MainPage : ContentPage
    {
        public MainPage() => InitializeComponent();
        private async void cityBtnPress_Clicked(object sender, EventArgs e)
        {
            string city = cityInput.Text.Trim();
            if (city.Length < 2 || string.IsNullOrEmpty(city))
            {
                await DisplayAlert("Ошибка", "Название города менее 2-х символов!", "хорошо");
                return;
            }
            HttpClient client = new HttpClient();
            string request = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={Key.API}&units=metric";
            string responce = await client.GetStringAsync(request);
            var json = JObject.Parse(responce);
            var temp = json["main"]["temp"].ToString();
            var real = json["main"]["feels_like"].ToString();
            resultText.Text = $"Температура: {temp}\nПо ощущениям: {real}";
        }
    }
}
