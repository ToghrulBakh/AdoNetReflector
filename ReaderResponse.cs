using System.Collections.Generic;

namespace AdoNetReflector
{
    public class ReaderResponse<T> : AdoNetResponse
    {
        public IEnumerable<T> Data { get; set; }
    }
}
