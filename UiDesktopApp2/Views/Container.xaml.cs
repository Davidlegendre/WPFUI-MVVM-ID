using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UiDesktopApp2.Services;
using UiDesktopApp2.ViewModels;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Markup;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace UiDesktopApp2.Views
{
    /// <summary>
    /// Interaction logic for Container.xaml
    /// </summary>
    public partial class Container : INavigationWindow
    {
        public ViewModels.ContainerViewModel? ViewModel
        {
            get;
        }
       
        public Container(IPageService pageService, INavigationService navigationService)
        {
            ViewModel = this.DataContext as ContainerViewModel;
            
            InitializeComponent();
            SetPageService(pageService);
            Watcher.Watch(this);
            navigationService.SetNavigationControl(RootNavigation);
        }
        

        #region INavigationWindow methods

        public Frame GetFrame()
            => RootFrame;

        public INavigation GetNavigation()
            => RootNavigation;

        public bool Navigate(Type pageType)
            => RootNavigation.Navigate(pageType);

        public void SetPageService(IPageService pageService)
            => RootNavigation.PageService = pageService;

        public void ShowWindow()
            => Show();

        public void CloseWindow()
            => Close();

        #endregion INavigationWindow methods

        /// <summary>
        /// Raises the closed event.
        /// </summary>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Make sure that closing this window will begin the process of closing the application.

            Application.Current.Shutdown();
        }
    }
}