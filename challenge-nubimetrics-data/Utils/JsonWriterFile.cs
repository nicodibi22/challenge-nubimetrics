using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Utils
{
    public class JsonWriterFile<T> : WriterTextFile
    {
        private string _fileName;
        public JsonWriterFile(string fileName)
        {
            _fileName = fileName;
        }
        public async Task Write<T>(T content)
        {
            string json = JsonSerializer.Serialize(content);
            File.WriteAllText(".//Adjuntos/" + _fileName, json);
        }
    }
}
