using iTextSharp.text.pdf;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PDFutilities.Utilities
{
    class CountPages : IUtility
    {
        ConcurrentDictionary<string, int> dictionary = new ConcurrentDictionary<string, int>();

        public string FileName { get; set; }

        public void run()
        {
            string[] fileNames = Directory.GetFiles(FileName, "*.pdf");

            this.doCount(fileNames);
            this.printDicionary();
        }

        public void doCount(string[] files)
        {
            if (files.Length > 0)
            {
                Console.WriteLine("\nCounting...\n");
                Parallel.ForEach(files, (currentFile) =>
                {
                    PdfReader reader = new PdfReader(currentFile);
                    dictionary.TryAdd(currentFile, reader.NumberOfPages);
                });
            }
        }

        public void printDicionary()
        {
            if (dictionary.Count > 0)
            {
                Console.WriteLine("Pages\tFile Name");

                foreach (var pair in dictionary.OrderBy(x => x.Value))
                {
                    Console.WriteLine(string.Format("{0}\t{1}", pair.Value, Path.GetFileNameWithoutExtension(pair.Key)));
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
