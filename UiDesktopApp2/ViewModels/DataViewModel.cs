using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using UiDesktopApp2.Models;
using Wpf.Ui.Appearance;
using Wpf.Ui.Common;
using Wpf.Ui.Common.Interfaces;
using Wpf.Ui.Controls;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Interfaces;

namespace UiDesktopApp2.ViewModels
{
    public partial class DataViewModel : ObservableObject, INavigationAware
    {
        private bool _isInitialized = false;

        [ObservableProperty]
        private ObservableCollection<DataColor>? _colors = new();

     

        [ObservableProperty]
        private bool _Move = false;


        public void OnNavigatedTo()
        {
            if (!_isInitialized)
                InitializeViewModel();
        }



        public void OnNavigatedFrom()
        {
        }

        private void InitializeViewModel()
        {

            _isInitialized = true;
            
        }

        [RelayCommand]
        private void Mas()
        {
            // Colors = new ObservableCollection<DataColor>(_colorsList!.Skip(100).Take(Colors!.Count + 100));
            Move = true;
            Task.Run(() =>
            {
                Thread.Sleep(3000);
                for (int i = 0; i < 100; i++)
                {
                    App.Current.Dispatcher.Invoke(() =>
                    {
                        Colors?.Add(new DataColor()
                        {
                            Icon = SymbolRegular.AccessibilityCheckmark20
                        });
                    });
                }
               Move = false;
            });
           
        }
    }
}
