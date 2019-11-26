using iTextSharp.text.pdf;
using System;
using System.IO;

namespace PDFutilities.Utilities
{
    class CountPages : IUtility
    {
        public string FileName { get; set; }

        public void run()
        {
            string[] fileNames = Directory.GetFiles(FileName, "*.pdf");

            this.doCount(fileNames);
        }

        public void doCount(string[] fileNameArray)
        {

            if (fileNameArray.Length > 0)
            {
                Console.WriteLine("No. of Pages\tFile Name");

                foreach (string singleFileName in fileNameArray)
                {
                    PdfReader reader = new PdfReader(singleFileName);

                    Console.WriteLine(string.Format("{0}\t{1}", reader.NumberOfPages, singleFileName));
                }
            }
            else
            {
                Console.WriteLine("There are no files to count.");
            }
        }

        public void displayEndMessage()
        {
            Console.WriteLine("File counting process ended correctly.\n");
        }
    }
}
