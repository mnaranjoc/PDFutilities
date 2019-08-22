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
                    default: utility = new NothingPDF(); break;
                }

                utility.run();
                utility.displayEndMessage();
            }
            while (opc > 0);

            menu.end();
        }
    }
}
