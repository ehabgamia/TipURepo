using System;
using System.Collections.Generic;
using System.Text;
using VideoBrek.Core.Domain.Media;
namespace VideoBrek.Services.Media
{
        public partial interface IMediaServices
        {
            /// <summary>
            /// Insert a Media
            /// </summary>
            /// <param name="Media">Media</param>
            void InsertMedia(VideoBrek.Core.Domain.Media.Media media);

            /// <summary>
            /// Updates the Media
            /// </summary>
            /// <param name="Media">Media</param>
            void UpdateMedia(VideoBrek.Core.Domain.Media.Media media);
            // Delete Media
            void DeleteMedia(VideoBrek.Core.Domain.Media.Media media);


        /// <summary>
        /// Gets a Media
        /// </summary>
        /// <param name="MediaId">Media identifier</param>
        /// <returns>A Media</returns>
        VideoBrek.Core.Domain.Media.Media GetMediaById(int MediaId);

            /// <summary>
            /// Gets all Media
            /// </summary>

            /// <returns>A Media</returns>
            IList<VideoBrek.Core.Domain.Media.Media> GetAllMedia();
        }
    
}
