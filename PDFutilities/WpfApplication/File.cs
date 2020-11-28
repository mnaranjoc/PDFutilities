using System.IO;

namespace WpfApplication
{
    public class File
    {
        public string Name;
        public int? Pages;
        public string FullPath;
        public string DisplayText {
            get
            {
                if (Pages == null)
                    return string.Format("{0}", Name);
                else
                    return string.Format("{0} ({1:n0} pages)", Name, Pages);
            }
            set { DisplayText = value; }
        }

        public File(string _FullPath)
        {
            FullPath = _FullPath;
            Name = Path.GetFileName(FullPath);
        }
    }
}
