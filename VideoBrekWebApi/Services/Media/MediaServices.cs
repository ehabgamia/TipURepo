using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoApp.Core.Domain.Media;
using VideoApp.Data.Interfaces;

namespace VideoAppWebApi.Services.Media
{
    public class MediaServices : IMediaServices
    {
        #region  Fields

        private readonly IRepository<VideoApp.Core.Domain.Media.Media> _mediaRepository;
        #endregion

        #region  CTOR
        public MediaServices(IRepository<VideoApp.Core.Domain.Media.Media> mediaRepository)
        {
            this._mediaRepository = mediaRepository;
        }

        public void DeleteMedia(Core.Domain.Media.Media media)
        {
            //    if (category == null)
            //    throw new ArgumentNullException(nameof(category));

            // category.Deleted = true;
            UpdateMedia(media);
          
        }

        public IList<Core.Domain.Media.Media> GetAllMedia()
        {
            var query = from h in _mediaRepository.Table
                        select h;
            return query.ToList();
        }

        public Core.Domain.Media.Media GetMediaById(int MediaId)
        {

            var query = from h in _mediaRepository.Table
                        where h.Id == MediaId
                        select h;
            return query.FirstOrDefault();
        }

        public void InsertMedia(Core.Domain.Media.Media media)
        {
            if (media == null)
                throw new ArgumentNullException(nameof(media));

            _mediaRepository.Insert(media);
        }

        public void UpdateMedia(Core.Domain.Media.Media media)
        {
            if (media == null)
                throw new ArgumentNullException(nameof(media));

            _mediaRepository.Update(media);
        }

        #endregion

    }
}
