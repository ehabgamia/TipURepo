using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBrek.Models;
using VideoBrek.PCL.Helper;
using static VideoBrek.Models.MediaHandlerModel;

namespace VideoBrek.PCL.Service
{
    public class MediaHandlerService
    {
        HttpClientHelper _helper;
        public MediaHandlerService()
        {
            _helper = new HttpClientHelper();
        }

        public async Task<ResultModel> getData(string Url)
        {
            ResultModel resp = null;
            try
            {
                resp = await _helper.Get<ResultModel>(Url);
                return resp;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return resp;
            }
        }

        public async Task<ResultModel> getMedia(int model, string Url)
        {
            ResultModel resp = null;
            try
            {
                resp = await _helper.Get<ResultModel>(Url);
                return resp;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return resp;
            }
        }

        public async Task<ResultModel> searchMedia(SearchModel model, string Url)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel = await _helper.Post<SearchModel>(model, Url);

                return resultModel;
            }
            catch (Exception ex)
            {
                // Crashes.TrackError(ex);
                return resultModel;
            }
        }

        public async Task<ResultModel> updateUserSettings(UserProfileSettingsModel model, string Url)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel = await _helper.Put<UserProfileSettingsModel>(model, Url);

                return resultModel;
            }
            catch (Exception ex)
            {
                // Crashes.TrackError(ex);
                return resultModel;
            }
        }

        public async Task<ResultModel> getAddMyList(AddMyListModel model, string Url)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel = await _helper.Post<AddMyListModel>(model, Url);

                return resultModel;
            }
            catch (Exception ex)
            {
                // Crashes.TrackError(ex);
                return resultModel;
            }
        }

    }
}
