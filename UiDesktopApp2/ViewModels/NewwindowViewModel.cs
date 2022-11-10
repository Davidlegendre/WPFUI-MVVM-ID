using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UiDesktopApp2.Services;
using Wpf.Ui.Common;
using Wpf.Ui.Controls.Interfaces;
using Wpf.Ui.Controls;
using Microsoft.Extensions.Hosting.Internal;

namespace UiDesktopApp2.ViewModels
{
    public partial class NewwindowViewModel : ObservableObject
    {
        private bool _isInitialized = false;
        private readonly IServicePrueba? _serviceprueba;
        public NewwindowViewModel()
        {
            _serviceprueba = App.GetService<IServicePrueba>();
            if (!_isInitialized)
                InitializeViewModel();
        }

        [ObservableProperty]
        private string _applicationTitle = String.Empty;

        [RelayCommand]
        public void Saludar() => ApplicationTitle = _serviceprueba!.Num();

        private void InitializeViewModel()
        {
            //aqui inicializas
            ApplicationTitle = _serviceprueba!.Num();
            _isInitialized = true;

        }
    }
}
