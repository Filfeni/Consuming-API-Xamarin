using SampleApp.Models;
using SampleApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
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
            FetchBrandList();
        }
        public async void FetchBrandList()
        {
            BrandApiService service = new BrandApiService();
            ObservableCollection<Brand> newList = await service.GetBrandAsync();
            if (newList != null)
            {
                BrandList = newList;
            }
        }
    }
}
