using System;
using System.Threading.Tasks;

namespace VideoBrek.PCL.Common
{
    public class SharedPreference
    {
        public async Task SaveApplicationProperty<T>(string key, T value)
        {
            try
            {
                Xamarin.Forms.Application.Current.Properties[key] = value;
                await Xamarin.Forms.Application.Current.SavePropertiesAsync();
            }
            catch (Exception ex)
            {

            }

        }


        public string LoadApplicationProperty<T>(string key)
        {
            try
            {
                var data = Xamarin.Forms.Application.Current.Properties;
                return Xamarin.Forms.Application.Current.Properties[key].ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}