using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;

namespace PDFutilities.Utilities
{
    class MergePDF : IUtility
    {
        public string FileName { get; set; }

        public void run()
        {
            string[] fileNames = Directory.GetFiles(FileName, "*.pdf");
            string outFileName = Directory.GetParent(FileName).FullName + "\\" + new DirectoryInfo(FileName).Name + ".pdf";

            this.doMerge(fileNames, outFileName);
        }

        public void doMerge(string[] _fileNames, string _outFile)
        {
            Document document = new Document();

            using (FileStream newFileStream = new FileStream(_outFile, FileMode.Create))
            {
                PdfCopy writer = new PdfCopy(document, newFileStream);
                if (writer == null)
                {
                    return;
                }

                document.Open();

                foreach (string fileName in _fileNames)
                {
                    PdfReader reader = new PdfReader(fileName);
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

        public void displayEndMessage()
        {
            Console.WriteLine("Files merged correctly.\n");
        }
    }
}