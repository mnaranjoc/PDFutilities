using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPFUtil.Common.Base
{
    public class FileUtilities
    {
        private ObservableCollection<File> FileList;
        private string Path;
        private string OutputFileName;

        public FileUtilities(ObservableCollection<File> _FileList, string _Path, string _OutputFileName)
        {
            FileList = _FileList;
            Path = _Path;
            OutputFileName = _OutputFileName;
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
                OutputFileName = System.IO.Path.Combine(Path, $"{OutputFileName}.pdf");

                Document document = new Document();

                using (FileStream newFileStream = new FileStream(OutputFileName, FileMode.Create))
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