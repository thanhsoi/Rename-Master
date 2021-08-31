using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RenameMaster
{
   public class FileUnit
    {
        public FileUnit(string FileName)
        {
            FileInfoz = new FileInfo(FileName);
            CurrentName = FileInfoz.Name;
        }
        public FileUnit(FileInfo FileInfo)
        {
            FileInfoz = FileInfo;
            CurrentName = FileInfoz.Name;
        }
        public string CurrentName { get; set; }
        public string NewName { get; set; }
        public string FileType { get; set; }
        FileInfo FileInfoz{ get; set; }
}
}
