using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication
{
    public class File
    {
        public string Name { get; set; }
        public string FullPath { get; set; }

        public File(string FullPath)
        {
            this.FullPath = FullPath;
            this.Name = Path.GetFileName(FullPath);
        }
    }
}
