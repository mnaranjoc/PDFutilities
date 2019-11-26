using System;

namespace PDFutilities.Utilities
{
    class NothingPDF : IUtility
    {
        public string FileName { get; set; }

        public void run()
        {
        }

        public void displayEndMessage()
        {
            Console.WriteLine("Program terminated.\n");
        }
    }
}
