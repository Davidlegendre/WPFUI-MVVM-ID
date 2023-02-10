using Microsoft.Web.WebView2.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;

namespace UiDesktopApp2.Views.Pages
{
    /// <summary>
    /// Interaction logic for DashboardPage.xaml
    /// </summary>
    public partial class DashboardPage : INavigableView<ViewModels.DashboardViewModel>
    {
        public ViewModels.DashboardViewModel ViewModel
        {
            get;
        }


        public DashboardPage(ViewModels.DashboardViewModel viewModel)
        {
            this.ViewModel = viewModel;
            InitializeComponent();
            
        }

        private void Browser_NavigationStarting(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationStartingEventArgs e)
        {
            ViewModel.IsEnableSearchTXT = false;
            ViewModel.LoaddingVisible = System.Windows.Visibility.Visible;          
        }

        private void Browser_NavigationCompleted(object? sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            ViewModel.IsEnableSearchTXT = true;
            ViewModel.LoaddingVisible = System.Windows.Visibility.Collapsed;
            
            Task.Run(() => {
                Thread.Sleep(500);
                //var browser = (Microsoft.Web.WebView2.Wpf.WebView2)sender;
                
                App.Current.Dispatcher.Invoke(async () =>
                {
                    //var icon = browser.CoreWebView2.FaviconUri;
                    var title = browser.CoreWebView2.DocumentTitle;
                    //ViewModel.UrlImage = !string.IsNullOrEmpty(icon) ? new Uri(icon) : ViewModel.UrlImage;
                    ViewModel.Title = title;
                    await geticon(sender);
                });
            });

        }

        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
           
            if (Keyboard.Modifiers == ModifierKeys.Control && e.Key == System.Windows.Input.Key.Enter)
            {
                var txt = (AutoSuggestBox)sender;
                ViewModel.SearchCommand.Execute("https://www." + txt.Text + ".com");
            }
            else if (e.Key == System.Windows.Input.Key.Enter)
            {
                var txt = (AutoSuggestBox)sender;
                ViewModel.SearchCommand.Execute(txt.Text);

            }
        }

        private void AutoSuggestBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var txt = (AutoSuggestBox)sender;
            txt.SelectAll();
        }

        async Task geticon(object sender)
        {

            var browser = (Microsoft.Web.WebView2.Wpf.WebView2)sender;
            var icon = await browser?.CoreWebView2.GetFaviconAsync(Microsoft.Web.WebView2.Core.CoreWebView2FaviconImageFormat.Png);

            ViewModel.UrlImage2 = GetBitmap(icon);
        }

        BitmapImage GetBitmap(Stream stream)
        {
            var bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.StreamSource = stream;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.EndInit();
            return bitmap;
        }

        private void browser_SourceUpdated(object sender, System.Windows.Data.DataTransferEventArgs e)
        {
            ViewModel.SourceFind = browser.Source;
        }

    }
}