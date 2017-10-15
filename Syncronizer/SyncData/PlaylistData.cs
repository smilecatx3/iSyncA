using System.Collections.Generic;
using System.IO;

namespace iSyncA
{
    public class PlaylistData
    {
        public string Name { get; private set; }
        public List<FileInfo> FileList { get; set; }

        public PlaylistData(string name)
        {
            this.Name = name;
            this.FileList = new List<FileInfo>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        public string[] GetFileListNames()
        {
            string[] result = new string[this.FileList.Count];
            for (int i=0; i<result.Length; i++)
                result[i] = this.FileList[i].Name;
            return result;
        }
    }
}
