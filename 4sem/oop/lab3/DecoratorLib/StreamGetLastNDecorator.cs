using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorLib
{
    public class StreamGetLastNDecorator : StreamDecorator
    {
        public StreamGetLastNDecorator(Stream stream) : base(stream)
        {
            this.stream = stream;
        }
        public override bool CanRead => stream.CanRead;

        public override bool CanSeek => stream.CanSeek;

        public override bool CanWrite => stream.CanWrite;

        public override long Length => stream.Length;

        public override long Position { get => stream.Position; set => Position = stream.Position; }

        public override void Flush()
        {
            stream.Flush();
        }
        public override int Read(byte[] buffer, int offset, int count)
        {
            return stream.Read(buffer, offset, count);
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            return stream.Seek(offset, origin);
        }

        public override void SetLength(long value)
        {
            stream.SetLength(value);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            stream.Write(buffer, offset, count);
        }
        public byte[] Write(byte[] buffer, int n)
        {
            if (buffer.Length - n < 0)
                throw new Exception("Вы записали меньше байт, чем хотите вывести");
            stream.Write(buffer, 0, buffer.Length);
            byte[] result = new byte[n];
            int j = 0;
            for(int i = buffer.Length - n; i < buffer.Length; i++)
            {
                result[j] = buffer[i];
                j++;
            }
            return result;
        }
    }
}
