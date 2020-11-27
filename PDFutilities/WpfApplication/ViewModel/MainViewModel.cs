using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using WpfApplication.Utilities;

namespace WpfApplication.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public string Folder { get; set; }
        public string AppTitle { get; set; }
        public ObservableCollection<File> FileList { get; set; }
        public ICommand LoadFilesCommand { get; set; }
        public ICommand OrderByNameCommand { get; set; }
        public ICommand OrderByNoOfPagesCommand { get; set; }
        public ICommand MergeFilesCommand { get; set; }

        public MainViewModel()
        {
            AppTitle = Constants.AppTitle;

            LoadFilesCommand = new RelayCommand(LoadFilesMethod);
            OrderByNameCommand = new RelayCommand(OrderByNameMethod);
            OrderByNoOfPagesCommand = new RelayCommand(OrderByNoOfPages);
            MergeFilesCommand = new RelayCommand(MergeFilesMethod);
        }

        private void LoadFilesMethod()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Folder = dialog.SelectedPath;

                    this.RaisePropertyChanged(() => this.Folder);

                    GetFilesFromDirectory();
                }
            }
        }

        private void GetFilesFromDirectory()
        {
            if (Directory.Exists(Folder))
            {
                FileList = new ObservableCollection<File>();
                var files = Directory.GetFiles(Folder, "*.pdf");

                foreach (var file in files)
                    FileList.Add(new File(file));

                this.RaisePropertyChanged(() => this.FileList);
            }
        }

        private void OrderByNameMethod()
        {
            FileList = new ObservableCollection<File>(FileList.OrderBy(s => s.Name));
            this.RaisePropertyChanged(() => this.FileList);
        }

        private void OrderByNoOfPages()
        {
            FileList = new FileUtilities(FileList, Folder).CountPages();
            FileList = new ObservableCollection<File>(FileList.OrderBy(s => s.Pages));
            this.RaisePropertyChanged(() => this.FileList);
        }

        private void MergeFilesMethod()
        {
            new FileUtilities(FileList, Folder).MergeFiles();
            GetFilesFromDirectory();
        }
    }
}