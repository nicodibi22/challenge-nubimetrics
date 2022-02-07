using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_data.Utils
{
    public class FactoryWriterTextFile
    {
		public static WriterTextFile GetWriter(string fileName)
		{
			if (fileName.ToUpper().EndsWith(".CSV"))
				return new CsvWriterFile(fileName);
			else if (fileName.ToUpper().EndsWith(".JSON"))
				return new JsonWriterFile(fileName);
			throw new ArgumentException("La extensión del archivo no es válida.");
		}
	}
}
