using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApplication
{
    public class File
    {
        public string Name;
        public int Pages;
        private string FullPath;
        public string DisplayText {
            get { return string.Format("{0} ({1} pages)", Name, Pages); }
            set { DisplayText = value; }
        }

        public File(string _FullPath)
        {
            FullPath = _FullPath;
            Name = Path.GetFileName(FullPath);
            Pages = new Random().Next();
            Thread.Sleep(500);
        }
    }
}
