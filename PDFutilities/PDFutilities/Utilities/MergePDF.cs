﻿using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System;

namespace PDFutilities.Utilities
{
    class MergePDF : IUtility
    {
        public void run()
        {
            Console.WriteLine("Enter the directory path with the PDFs to merge");
            string dir = Console.ReadLine();
            
            this.doMerge(
                Directory.GetFiles(dir, "*.pdf"),
                Directory.GetParent(dir).FullName + "\\" + new DirectoryInfo(dir).Name + ".pdf"
            );
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
            Console.WriteLine("Files merged correctly");
        }
    }
}