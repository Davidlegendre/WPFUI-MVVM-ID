using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Text.RegularExpressions;
using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp2.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {

        string urlApiGoogle = "https://www.google.com/search?q=";

        [ObservableProperty]
        private Uri _sourceFind = new Uri("https://www.google.com/");

        public void OnNavigatedTo()
        {
        }

        public void OnNavigatedFrom()
        {
        }

        

        [RelayCommand]
        private void Search(string? url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                if(!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    SourceFind= new Uri(urlApiGoogle + url);
                }else
                    SourceFind = new Uri(url);
            }
        }

        [RelayCommand]
        private void Back(object? browser)
        { 
            if(browser != null && browser is WebView2)
            {
                ((WebView2)browser).GoBack();
            }
        }


        [RelayCommand]
        private void Forward(object? browser)
        {
            if (browser != null && browser is WebView2)
            {
                ((WebView2)browser).GoForward();
            }
        }

        [RelayCommand]
        private void Refresh(object? browser) { 
            if(browser != null && browser is WebView2)
            {
                ((WebView2)browser).Reload();
            }
        }
    }
}
