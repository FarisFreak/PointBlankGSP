using System;
using System.Text;

namespace PBServer.network
{
	public abstract class ReceiveBaseGamePacket
	{
		private byte[] _buffer;

		private GameClient _Client;

		private int _offset;

		protected internal byte[] getBuffer()
		{
			return this._buffer;
		}

		protected internal GameClient getClient()
		{
			return this._Client;
		}

		protected internal void ignore(int in_offset)
		{
			this._offset += in_offset;
			CLogger.getInstance().info("Ignore " + in_offset + "bytes");
		}

		protected internal void makeme(GameClient Client, byte[] buffer)
		{
			this._Client = Client;
			this._buffer = buffer;
			this._offset = 2;
			this.read();
		}

		protected internal abstract void read();

		protected internal byte[] readB(int Length)
		{
			byte[] array = new byte[Length];
			Array.Copy(this._buffer, this._offset, array, 0, Length);
			this._offset += Length;
			return array;
		}

		protected internal byte readC()
		{
			byte result = this._buffer[this._offset];
			this._offset++;
			return result;
		}

		protected internal int readD()
		{
			int result = BitConverter.ToInt32(this._buffer, this._offset);
			this._offset += 4;
			return result;
		}

		protected internal double readF()
		{
			double result = BitConverter.ToDouble(this._buffer, this._offset);
			this._offset += 8;
			return result;
		}

		protected internal short readH()
		{
			short result = BitConverter.ToInt16(this._buffer, this._offset);
			this._offset += 2;
			return result;
		}

		protected internal long readQ()
		{
			long result = BitConverter.ToInt64(this._buffer, this._offset);
			this._offset += 8;
			return result;
		}

		protected internal string readS()
		{
			string text = "";
			try
			{
				text = Encoding.Unicode.GetString(this._buffer, this._offset, this._buffer.Length - this._offset);
				int num = text.IndexOf('\0');
				bool flag = num != -1;
				if (flag)
				{
					text = text.Substring(0, num);
				}
				this._offset += text.Length + 1;
			}
			catch (Exception ex)
			{
				CLogger.getInstance().error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
			}
			return text;
		}

		protected internal string readS(int Length)
		{
			string text = "";
			try
			{
				text = Encoding.GetEncoding(1251).GetString(this._buffer, this._offset, Length);
				int num = text.IndexOf('\0');
				bool flag = num != -1;
				if (flag)
				{
					text = text.Substring(0, num);
				}
				this._offset += Length;
			}
			catch (Exception ex)
			{
				CLogger.getInstance().error("while reading string from packet, " + ex.Message + " " + ex.StackTrace);
			}
			return text;
		}

		protected internal abstract void run();
	}
}
