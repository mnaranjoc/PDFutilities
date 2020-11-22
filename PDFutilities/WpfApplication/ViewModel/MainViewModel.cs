using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string AppTitle { get; set; }
        public ObservableCollection<File> FileList { get; set; }
        public ICommand LoadFilesCommand { get; set; }
        public MainViewModel()
        {
            AppTitle = Constants.AppTitle;
            LoadFilesCommand = new RelayCommand(LoadFilesMethod);
        }

        private void LoadFilesMethod()
        {
            FileList = new ObservableCollection<File>()
            {
                new File() { Name = "001.pdf" },
                new File() { Name = "002.pdf" }
            };
            this.RaisePropertyChanged(() => this.FileList);
        }
    }
}