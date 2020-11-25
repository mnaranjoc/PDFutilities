using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
        public ICommand OrderByNameCommand { get; set; }
        public ICommand OrderByNoOfPagesCommand { get; set; }
        public MainViewModel()
        {
            AppTitle = Constants.AppTitle;
            LoadFilesCommand = new RelayCommand(LoadFilesMethod);
            OrderByNameCommand = new RelayCommand(OrderByNameMethod);
            OrderByNoOfPagesCommand = new RelayCommand(OrderByNoOfPages);
        }

        private void LoadFilesMethod()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Folder = dialog.SelectedPath;
                    this.RaisePropertyChanged(() => this.Folder);

                    if (Directory.Exists(Folder))
                    {
                        FileList = new ObservableCollection<File>();
                        var files = Directory.GetFiles(Folder, "*.pdf");

                        foreach (var file in files)
                        {
                            FileList.Add(new File(file));
                        }

                        this.RaisePropertyChanged(() => this.FileList);
                    }
                }
            }
        }

        private void OrderByNameMethod()
        {
            var newOrderedList = from f in FileList
                                 orderby f.Name
                                 select f;

            FileList = new ObservableCollection<File>(newOrderedList.ToList());
            this.RaisePropertyChanged(() => this.FileList);
        }

        private void OrderByNoOfPages()
        {
            var newOrderedList = from f in FileList
                                 orderby f.Pages
                                 select f;

            FileList = new ObservableCollection<File>(newOrderedList.ToList());
            this.RaisePropertyChanged(() => this.FileList);
        }
    }
}