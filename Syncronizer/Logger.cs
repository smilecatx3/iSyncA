using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace iSyncA
{
    public class Logger
    {
        private List<ExceptionData> _exceptionList;
        public bool isDirty { get; private set; } // _exceptionList.Count > 0

        public Logger()
        {
            this._exceptionList = new List<ExceptionData>();
            this.isDirty = false;
        }

        public void Log(ExceptionData data)
        {
            this.isDirty = true;
            this._exceptionList.Add(data);
            StreamWriter writer = File.AppendText("error.log");
            writer.Write(String.Format("{0} {1} \r\n{2}\r\n\r\n", data.Time, data.Message, data.Cause.ToString()));
            writer.Close();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            foreach (ExceptionData data in this._exceptionList)
                result.Append(data);
            return result.ToString();
        }
    }

    public class ExceptionData
    {
        public  Exception Cause { get; private set; }
        public string Message { get; private set; }
        public string Time { get; private set; }

        public ExceptionData(Exception cause, string message)
        {
            this.Message = message;
            this.Cause = cause;
            this.Time = DateTime.Now.ToString("[yyyy/MM/dd HH:mm:ss]");
        }

        public override string ToString()
        {
            return String.Format("{0} {1} \r\n => {2}: {3} \r\n\r\n", this.Time, this.Message, this.Cause.GetType(), this.Cause.Message);
        }
    }
}
