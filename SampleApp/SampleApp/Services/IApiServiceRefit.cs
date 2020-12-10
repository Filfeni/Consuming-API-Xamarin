﻿using Refit;
using SampleApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Services
{
    public interface IApiServiceRefit
    {
        [Get("/api/const/brands")]
        Task<ObservableCollection<Brand>> GetBrandAsync();
    }
}
