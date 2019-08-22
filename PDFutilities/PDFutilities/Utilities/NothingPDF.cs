using System;

namespace PDFutilities.Utilities
{
    class NothingPDF : IUtility
    {
        public void displayEndMessage()
        {
            Console.WriteLine("Program terminated.");
        }

        public void run()
        {
        }
    }
}
