using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFUtil.Common.Base;

namespace PDFUtil.Module.Merge.ViewModels
{
    public class MergeViewModel : BindableBase
    {
        private string dir;
        private string[] SelectedFiles;
        private ObservableCollection<File> fileList;
        public string OutputFileName { get; set; }        
        public DelegateCommand SelectFilesCommand { get; set; }
        public DelegateCommand GenerateFileCommand { get; set; }

        public MergeViewModel()
        {
            SelectFilesCommand = new DelegateCommand(SelectFilesMethod);
            GenerateFileCommand = new DelegateCommand(GenerateFileMethod);
        }        

        private void SelectFilesMethod()
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files *.pdf | *.pdf";
            open.Multiselect = true;
            open.Title = "Select PDF Files";

            if (open.ShowDialog() == DialogResult.OK)
            {
                SelectedFiles = open.FileNames;
                GetFilesFromDirectory();
            }
        }

        private void GenerateFileMethod()
        {
            new FileUtilities(fileList, dir).MergeFiles();
        }

        private void GetFilesFromDirectory()
        {
            if (SelectedFiles.Count() > 0)
            {
                fileList = new ObservableCollection<File>();

                foreach (var file in SelectedFiles)
                    fileList.Add(new File(file));

                dir = System.IO.Path.GetDirectoryName(SelectedFiles[0]);
            }
        }
    }
}