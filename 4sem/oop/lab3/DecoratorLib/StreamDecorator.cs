using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorLib
{
    public abstract class StreamDecorator : Stream
    {
        protected Stream stream;

        public StreamDecorator(Stream stream)
        {
            this.stream = stream;
        }
        public void SetStream(Stream stream)
        {
            this.stream = stream;
        }
    }
}
