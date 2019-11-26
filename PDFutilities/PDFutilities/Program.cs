using PDFutilities.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFutilities
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            IUtility utility;
            int opc = 0;

            do
            {
                opc = menu.display();

                switch (opc)
                {
                    case 1: utility = new MergePDF(); break;
                    case 2: utility = new CountPages(); break;
                    default: utility = new NothingPDF(); break;
                }

                utility.FileName = GetFileName();
                utility.run();
                utility.displayEndMessage();
            }
            while (opc > 0);

            menu.end();
        }

        public static string GetFileName()
        {
            Console.WriteLine("Enter the directory path with the PDF files");
            string dir = Console.ReadLine();

            return dir;
        }
    }
}
