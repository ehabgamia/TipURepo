using System;
using System.Threading.Tasks;
using VideoBrek.Models;
using VideoBrek.PCL.Helper;
using Newtonsoft.Json;

namespace VideoBrek.PCL.Service
{
    public class RegisterService
    {
        HttpClientHelper _helper;
        public RegisterService()
        {
            _helper = new HttpClientHelper();
        }

        public async Task<ResultModel> RegisterUser(UserProfileModel model, string Url)
        {
            ResultModel resultModel = new ResultModel();
            try
            {
                resultModel = await _helper.Post<UserProfileModel>(model, Url);

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