using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBrek.Extensions;
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace VideoBrek.Models
{
    public class MediaHandlerModel
    {
        static YoutubeClient youtubeClient = new YoutubeClient();
        public class GetMediasModel
        {
            public int DisplayOrder { get; set; }
            public string CategoryName { get; set; }
            public List<AllMediaModel> Media { get; set; }
        }

        public static List<GetMediasModel> MyDataSourceAll { get; set; }

        public class AllMediaModel
        {
            public int Id { get; set; }
            public string? Title { get; set; }
            public string? Description { get; set; }
            public string? CloudUrl { get; set; }
            public string? ThumbURL { get; set; }
            public string? AliasCloudUrl { get; set; }

            public string AliasThumbURL
            {
                get;set;
                //maxresdefault//sddefault
                //get { return !string.IsNullOrEmpty(ThumbURL) ? "https://img.youtube.com/vi/" + ThumbURL + "/maxresdefault.jpg" : "https://www.prioritysoftware.com/wp-content/uploads/2015/02/xno-image.png.pagespeed.ic.TALCyIr8tu.webp"; }
            }

            //public string AliasCloudUrl
            //{
            //    get { return !CloudUrl.Contains("https://www.youtube.com/") ? "https://www.youtube.com/" + CloudUrl : CloudUrl; }
            //}
            public bool IsAddedToMyList { get; set; }

            public bool isDeleted { get; set; }
            public int? DeleterUserId { get; set; }
            public DateTime? DeletionTime { get; set; }
            public DateTime? lastModificationTime { get; set; }
            public int? lastModifierUserId { get; set; }
            public DateTime? creationTime { get; set; }
            public int? creatorUserId { get; set; }
        }

        public class SearchModel
        {
            public string SearchString { get; set; }
        }

        public class AddMyListModel
        {
            public string UserID { get; set; }
            public string MediaID { get; set; }
        }

        public class UserSettingsModel
        {
            public string userID { get; set; }
        }

        public class SearchMediaModel
        {
            public int MediaID { get; set; }
            public string Title { get; set; }
            public string MediaDesc { get; set; }
            public string ClickURL { get; set; }
            public string Thumbnail { get; set; }
            public int EpisodeID { get; set; }
            public int SeasonID { get; set; }

            public string AliasThumbURL
            {
                
                //get { return "http://graceanointing.org" + ThumbURL; }
                get { return !string.IsNullOrEmpty(ClickURL) ? "https://img.youtube.com/vi/" + YouTubeVideoIdExtension.YouTubeVideoIdFromUrl(ClickURL) + "/maxresdefault.jpg" : "https://www.prioritysoftware.com/wp-content/uploads/2015/02/xno-image.png.pagespeed.ic.TALCyIr8tu.webp"; }
            }

            public string AliasCloudUrl
            {
                get { return ClickURL; }

            }
        }

        

        public static async Task<Video> GetVideoAsync(string Url)
        {
            Video resp = null;
            var youtube = new YoutubeClient();
            try
            {
                resp = await youtube.Videos.GetAsync(Url);
                return resp;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                string exp = ex.Message;
                return resp;
            }
        }

        public static async Task<StreamInfoModel> GetVideoMediaStreamInfosAsync(string Url)
        {
            var youtubeClient = new YoutubeClient();
            StreamInfoModel streamInfoModel = null;
            try
            {
                var streamManifest = await youtubeClient.Videos.Streams.GetManifestAsync(Url);
                if (streamManifest != null)
                {
                    var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();
                    if (streamInfo != null)
                    {
                        streamInfoModel = new StreamInfoModel();
                        streamInfoModel.Bitrate = streamInfo.Bitrate;
                        streamInfoModel.Container = streamInfo.Container;
                        streamInfoModel.Size = streamInfo.Size;
                        //streamInfoModel.Framerate = streamInfo..Framerate;
                        streamInfoModel.Url = streamInfo.Url;
                        //streamInfoModel.Tag = streamInfo.Tag;
                    }
                }
                return streamInfoModel;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return null;
            }
        }


        public class StreamInfoModel
        {
            public Bitrate Bitrate { get; set; }
            public Container Container { get; set; }
            public FileSize Size { get; set; }
            //public Framerate Framerate { get; set; }
            public string Url { get; set; }
            public int Tag { get; set; }
        }
    }
}