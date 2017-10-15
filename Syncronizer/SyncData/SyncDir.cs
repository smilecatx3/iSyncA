using System.Collections.Generic;
using System.IO;

namespace iSyncA
{
    public class SyncDir
    {
        public DirectoryInfo Directory { get; private set; }
        public List<SyncFile> FileList { get; set; }

        public SyncDir(DirectoryInfo dir)
        {
            this.Directory = dir;
            this.FileList = new List<SyncFile>();
        }

        public override string ToString()
        {
            return this.Directory.Name;
        }
    }
}
