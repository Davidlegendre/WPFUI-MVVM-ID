using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UiDesktopApp2.ViewModels;
using Wpf.Ui.Common.Interfaces;

namespace UiDesktopApp2.Views.Pages
{
    /// <summary>
    /// Interaction logic for DataView.xaml
    /// </summary>
    public partial class DataPage : INavigableView<ViewModels.DataViewModel>
    {
        public ViewModels.DataViewModel? ViewModel
        {
            get;
        }


        public DataPage()
        {
            
            InitializeComponent();
            if (ViewModel != null)
            {
                ViewModel = this.DataContext as DataViewModel;
            }
        }

        private void scroll_ScrollChanged(object sender, System.Windows.Controls.ScrollChangedEventArgs e)
        {
            if (e.VerticalOffset == scroll.ScrollableHeight)
            {
                if (ViewModel?.Move == false)
                {
                    ViewModel.MasCommand.Execute(null);                  
                   
                }
            }
        }
    }
}
