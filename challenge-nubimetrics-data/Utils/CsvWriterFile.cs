using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Utils
{
    public class CsvWriterFile<T> : WriterTextFile
    {
        private string _fileName;
        StrategyCsvWriter _strategyCsvWriter;
        public CsvWriterFile(string fileName, StrategyCsvWriter strategyCsvWriter)
        {
            _fileName = fileName;
            _strategyCsvWriter = strategyCsvWriter;

        }
        public async Task Write<T>(T content)
        {
            File.WriteAllText(".//Adjuntos/" + _fileName, _strategyCsvWriter.Write(content));
        }

    }
}
