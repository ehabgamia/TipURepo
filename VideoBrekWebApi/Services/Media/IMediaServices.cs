using System;
using System.Collections.Generic;
using System.Text;
using VideoApp.Core.Domain.Media;
namespace VideoAppWebApi.Services.Media
{
        public partial interface IMediaServices
        {
            /// <summary>
            /// Insert a Media
            /// </summary>
            /// <param name="Media">Media</param>
            void InsertMedia(VideoApp.Core.Domain.Media.Media media);

            /// <summary>
            /// Updates the Media
            /// </summary>
            /// <param name="Media">Media</param>
            void UpdateMedia(VideoApp.Core.Domain.Media.Media media);
            // Delete Media
            void DeleteMedia(VideoApp.Core.Domain.Media.Media media);


        /// <summary>
        /// Gets a Media
        /// </summary>
        /// <param name="MediaId">Media identifier</param>
        /// <returns>A Media</returns>
        VideoApp.Core.Domain.Media.Media GetMediaById(int MediaId);

            /// <summary>
            /// Gets all Media
            /// </summary>

            /// <returns>A Media</returns>
            IList<VideoApp.Core.Domain.Media.Media> GetAllMedia();
        }
    
}
