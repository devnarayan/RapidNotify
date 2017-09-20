using RapidNotifyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
//using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(RapidNotifyApp.Services.WelcomeService))]
namespace RapidNotifyApp.Services
{
    public class WelcomeService
    {
        public async Task<string> WelcomeConnect(RegisterModel model)
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://rapid-notify-server-cdaden.c9users.io/");
            //    client.DefaultRequestHeaders.Add("Authorization", "Basic cmFwaWQ6cmFwaWQ=");

            //    var json = JsonConvert.SerializeObject(model);

            //    var content = new StringContent(json, Encoding.UTF8, "application/json");

            //    var response = await client.PostAsync("Web/API/device", content);
            //    if (response.IsSuccessStatusCode)
            //    {
            //        return await response.Content.ReadAsStringAsync();
            //    }
                return "";
            //}
        }
    }
}
