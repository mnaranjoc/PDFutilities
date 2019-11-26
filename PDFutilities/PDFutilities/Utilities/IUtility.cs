using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFutilities.Utilities
{
    public interface IUtility
    {
        string FileName { get; set; }

        void run();

        void displayEndMessage();
    }
}
