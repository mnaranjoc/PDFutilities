using iTextSharp.text.pdf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication.Utilities
{
    class FileUtilities
    {
        private ObservableCollection<File> FileList;
        //ConcurrentDictionary<string, int> dictionary = new ConcurrentDictionary<string, int>();

        public FileUtilities(ObservableCollection<File> _FileList)
        {
            FileList = _FileList;
        }

        public ObservableCollection<File> CountPages()
        {
            Parallel.ForEach(FileList, (file) =>
            {
                if (file.Pages == null)
                {
                    PdfReader reader = new PdfReader(file.FullPath);
                    file.Pages = reader.NumberOfPages;
                }
            });

            return FileList;
        }
    }
}
