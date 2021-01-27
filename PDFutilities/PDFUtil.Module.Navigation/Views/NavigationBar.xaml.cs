using PDFUtil.Module.Navigation.ViewModels;
using System.Windows.Controls;

namespace PDFUtil.Module.Navigation.Views
{
    public partial class NavigationBar : UserControl
    {
        public NavigationBar(NavigationViewModel vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}