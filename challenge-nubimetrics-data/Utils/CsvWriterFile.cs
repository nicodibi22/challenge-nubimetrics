using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Utils
{
    public class CsvWriterFile : WriterTextFile
    {
        private string _fileName;
        public CsvWriterFile(string fileName)
        {
            _fileName = fileName;
        }
        public async Task Write<T>(T content)
        {
            var csv = new StringBuilder();            
            csv.AppendLine("");
            File.WriteAllText(_fileName, csv.ToString());
        }
    }
}
