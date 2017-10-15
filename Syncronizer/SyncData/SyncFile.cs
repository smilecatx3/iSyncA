using System;
using System.IO;

namespace iSyncA
{
    public class SyncFile
    {
        public FileInfo File { get; private set; }
        public string Name { get; private set; }
        public string SyncPath { get; private set; }
        public int SyncType { get; private set; }
        public static ulong Count { get; set; }

        public SyncFile(FileInfo file, SyncDataType type, string syncPath)
        {
            this.File = file;
            this.SyncType = (int)type;
            this.Name = String.Format("{0} {1}", (type==SyncDataType.NotExist) ? '✔' : (type==SyncDataType.FileSizeDiffer) ? '☀' : '✖', file.Name);
            if (syncPath != null)
                this.SyncPath = syncPath.Remove(syncPath.LastIndexOf(@"\")+1);
            SyncFile.Count++;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
