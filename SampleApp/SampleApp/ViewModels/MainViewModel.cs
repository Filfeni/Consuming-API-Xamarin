using Refit;
using SampleApp.Models;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SampleApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Brand> BrandList { get; set; }
        public ICommand FetchBrandListCommand { get; set; }
        public MainViewModel()
        {
            BrandList = new ObservableCollection<Brand>();
            FetchBrandListCommand = new Command(FetchBrandList);
        }
        public async void FetchBrandList()
        {

            if (CheckConnectivity() == NetworkAccess.Internet)
            {
                var service = RestService.For<IApiServiceRefit>("https://xamrentapi.azurewebsites.net");
                ObservableCollection<Brand> newList = await service.GetBrandAsync();
                if (newList != null)
                {
                    BrandList = newList;
                } 
            }
            else
            {
                await App.Current.MainPage.DisplayAlert(null, "There is no internet connection", "OK");
            }
        }

        public NetworkAccess CheckConnectivity()
        {
            var access = Connectivity.NetworkAccess;
            return access;
        }
    }
}
