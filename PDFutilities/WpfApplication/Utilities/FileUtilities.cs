using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication.Utilities
{
    class FileUtilities
    {
        private ObservableCollection<File> FileList;
        private string Path;

        public FileUtilities(ObservableCollection<File> _FileList, string _Path)
        {
            FileList = _FileList;
            Path = _Path;
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

        public void MergeFiles()
        {
            if (FileList == null || FileList.Count == 0)
            {
                MessageBox.Show("No PDF files found on folder.");
            }
            else
            {
                string outFile = string.Format("{0}\\({1:n0})FilesMerged.pdf", Path, FileList.Count);

                Document document = new Document();

                using (FileStream newFileStream = new FileStream(outFile, FileMode.Create))
                {
                    PdfCopy writer = new PdfCopy(document, newFileStream);
                    if (writer == null)
                    {
                        return;
                    }

                    document.Open();

                    foreach (var file in FileList)
                    {
                        PdfReader reader = new PdfReader(file.FullPath);
                        reader.ConsolidateNamedDestinations();

                        for (int i = 1; i <= reader.NumberOfPages; i++)
                        {
                            PdfImportedPage page = writer.GetImportedPage(reader, i);
                            writer.AddPage(page);
                        }

                        PRAcroForm form = reader.AcroForm;
                        if (form != null)
                        {
                            writer.CopyAcroForm(reader);
                        }

                        reader.Close();
                    }

                    writer.Close();
                    document.Close();
                }
            }
        }
    }
}
