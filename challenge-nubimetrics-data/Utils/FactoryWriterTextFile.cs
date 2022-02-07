using challenge_nubimetrics_models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace challenge_nubimetrics_data.Utils
{
    public class FactoryWriterTextFile<T>
    {
		public static WriterTextFile GetWriter(string fileName)
		{
			if (fileName.ToUpper().EndsWith(".CSV"))
				return new CsvWriterFile<T>(fileName, new ConversionsListWriter());
			else if (fileName.ToUpper().EndsWith(".JSON"))
				return new JsonWriterFile<T>(fileName);
			throw new ArgumentException("La extensión del archivo no es válida.");
		}
	}
}
