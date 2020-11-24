using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace WpfApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Folder { get; set; }
        public string AppTitle { get; set; }
        public ObservableCollection<File> FileList { get; set; }
        public ICommand LoadFilesCommand { get; set; }
        public ICommand SelectFolderCommand { get; set; }
        public MainViewModel()
        {
            AppTitle = Constants.AppTitle;
            LoadFilesCommand = new RelayCommand(LoadFilesMethod);
            SelectFolderCommand = new RelayCommand(SelectFolderMethod);
        }

        private void SelectFolderMethod()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Folder = dialog.SelectedPath;
                    this.RaisePropertyChanged(() => this.Folder);
                }
            }
        }

        private void LoadFilesMethod()
        {
            if (Directory.Exists(Folder))
            {
                FileList = new ObservableCollection<File>();
                var files = Directory.GetFiles(Folder, "*.pdf");

                foreach (var file in files)
                {
                    FileList.Add(new File(file));
                }
            }

            this.RaisePropertyChanged(() => this.FileList);
        }
    }
}