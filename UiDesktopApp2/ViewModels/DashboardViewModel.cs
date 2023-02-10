using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;

namespace UiDesktopApp2.ViewModels
{
    public partial class DashboardViewModel : ObservableObject, INavigationAware
    {

        string urlApiGoogle = "https://www.google.com/search?q=";

        [ObservableProperty]
        private Uri? _sourceFind = new Uri("https://www.google.com/");

        [ObservableProperty]
        private bool _IsEnableSearchTXT = false;

        [ObservableProperty]
        private Visibility _LoaddingVisible = Visibility.Visible;       

        public static Uri _DefaultUriImg => new Uri("/Assets/applicationIcon-256.png", UriKind.RelativeOrAbsolute);

        [ObservableProperty]
        Uri _UrlImage = _DefaultUriImg;
        [ObservableProperty]
        BitmapImage? _UrlImage2 = new BitmapImage();

        [ObservableProperty]
        string? _Title = "";

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
                url = url.Replace(" ", "+");
                if(!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    SourceFind = new Uri(urlApiGoogle + url);
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
                ((WebView2)browser).CoreWebView2.Reload();
            }
        }

        [RelayCommand]
        private void OpenFlyout(object? Flyout)
        {
            if (Flyout != null && Flyout is Dialog)
            {
                var fl = (Dialog)Flyout;
                fl.Show();
            }
        }
    }
}
