using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using Plugin.Toast;
using Plugin.Toast.Abstractions;
using Xamarin.Forms;

namespace VideoBrek.Extensions
{
    public class YouTubeVideoIdExtension
    {
        public static string GetYouTubeUrl(string videoId)
        {
            try
            {
                var videoInfoUrl = $"https://www.youtube.com/get_video_info?video_id={videoId}";

                using (var client = new HttpClient())
                {
                    var videoPageContent = client.GetStringAsync(videoInfoUrl).Result;
                    var videoParameters = HttpUtility.ParseQueryString(videoPageContent);
                    var encodedStreamsDelimited = WebUtility.HtmlDecode(videoParameters["player_response"]);
                    var encodedStreams = encodedStreamsDelimited.Split(',');
                    var streams = encodedStreams.Select(HttpUtility.ParseQueryString);

                    var stream = streams
                        .OrderBy(s =>
                        {
                            var type = s["type"];
                            if (type.Contains("video/mp4")) return 10;
                            if (type.Contains("video/3gpp")) return 20;
                            if (type.Contains("video/x-flv")) return 30;
                            if (type.Contains("video/webm")) return 40;
                            return int.MaxValue;
                        })
                        .ThenBy(s =>
                        {
                            var quality = s["quality"];

                            switch (Device.Idiom)
                            {
                                case TargetIdiom.Phone:
                                    return Array.IndexOf(new[] { "medium", "high", "small" }, quality);
                                default:
                                    return Array.IndexOf(new[] { "high", "medium", "small" }, quality);
                            }
                        })
                        .FirstOrDefault();

                    return stream["url"];
                }
            }

            catch (Exception ed)
            {
                CrossToastPopUp.Current.ShowToastMessage("Video not embedding", ToastLength.Long);
                return "";
            }
        }

        public static string YouTubeVideoIdFromUrl(string url)
        {
            var uri = new Uri(url);
            var query = HttpUtility.ParseQueryString(uri.Query);
            if (query.AllKeys.Contains("v"))
            {
                return query["v"];
            }
            return uri.Segments.Last();
        }
    }
}