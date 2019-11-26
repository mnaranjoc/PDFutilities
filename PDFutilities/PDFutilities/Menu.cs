using System;

namespace PDFutilities
{
    class Menu
    {
        public int display()
        {
            int ret = 0;

            Console.WriteLine("Choose an option to work with PDF files:");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Merge");
            Console.WriteLine("2 - Count");
            Console.WriteLine("");

            string input = Console.ReadLine();

            int.TryParse(input, out ret);

            return ret;
        }

        public void end()
        {
            Console.WriteLine("Press any key to exit.");
            Console.ReadLine();
        }
    }
}
