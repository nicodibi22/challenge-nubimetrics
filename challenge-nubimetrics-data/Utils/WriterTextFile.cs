using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace challenge_nubimetrics_data.Utils
{
    public interface WriterTextFile
    {
        public Task Write<T>(T content);
    }
}
