using System;
using System.IO;
using System.Text;

namespace PBServer
{
	public abstract class SendBaseGamePacket
	{
		private MemoryStream mstream;

		public long Length
		{
			get
			{
				return this.mstream.Length;
			}
		}

		protected internal void makeme()
		{
			this.mstream = new MemoryStream();
		}

		public byte[] ToByteArray()
		{
			return this.mstream.ToArray();
		}

		protected internal abstract void write();

		protected internal void writeB(byte[] value)
		{
			this.mstream.Write(value, 0, value.Length);
		}

		protected internal void writeC(byte value)
		{
			this.mstream.WriteByte(value);
		}

		protected internal void writeD(int value)
		{
			this.writeB(BitConverter.GetBytes(value));
		}

		protected internal void writeF(double value)
		{
			this.writeB(BitConverter.GetBytes(value));
		}

		protected internal void writeH(short val)
		{
			this.writeB(BitConverter.GetBytes(val));
		}

		protected internal void writeE(ushort val)
		{
			this.writeB(BitConverter.GetBytes(val));
		}

		protected internal void writeQ(long value)
		{
			this.writeB(BitConverter.GetBytes(value));
		}

		protected internal void writeS(string value)
		{
			bool flag = value != null;
			if (flag)
			{
				this.writeB(Encoding.Unicode.GetBytes(value));
			}
			this.writeH(0);
		}

		protected internal void writeS(string name, int count)
		{
			bool flag = name != null;
			if (flag)
			{
				this.writeB(Encoding.GetEncoding(1251).GetBytes(name));
				this.writeB(new byte[count - name.Length]);
			}
		}
	}
}
