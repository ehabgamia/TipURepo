using System;
using System.Threading.Tasks;

namespace VideoBrek.Base
{
    public abstract class ViewsModelBase : ExtendedBindableObject
    {
        //protected readonly IDialogService DialogService;
        //protected readonly INavigationService NavigationService;

        private bool _isBusy;

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public ViewsModelBase()
        {
            //DialogService = ViewModelLocator.Resolve<IDialogService>();
            //NavigationService = ViewModelLocator.Resolve<INavigationService>();
            //var settingsService = ViewModelLocator.Resolve<ISettingsService>();

            //GlobalSetting.Instance.BaseIdentityEndpoint = settingsService.IdentityEndpointBase;
            //GlobalSetting.Instance.BaseGatewayShoppingEndpoint = settingsService.GatewayShoppingEndpointBase;
            //GlobalSetting.Instance.BaseGatewayMarketingEndpoint = settingsService.GatewayMarketingEndpointBase;
        }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}
