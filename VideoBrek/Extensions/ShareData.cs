using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace VideoBrek.Extensions
{
    public class ShareData
    {
        public static async Task ShareText(string text)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Text = text,
                Title = ""
            });
        }

        public static async Task ShareUri(string uri)
        {
            await Share.RequestAsync(new ShareTextRequest
            {
                Uri = uri,
                Title = "Share Web Link"
            });
        }
    }
}
