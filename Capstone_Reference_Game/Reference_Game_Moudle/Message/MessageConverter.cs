using System;
using System.Text;

namespace Capstone_Reference_Game_Module
{
    public class MessageConverter
    {
        private byte[] _message;
        public byte[] Message { get { return _message; } }


        private byte _protocol;
        public byte Protocol { get { return _protocol; } }


        private int _messageSize;
        public int MessageSize { get { return _messageSize; } }


        private int nextIndex;
        private int lastIndex;

        public MessageConverter(byte[] message)
        {
            _message = message;
            lastIndex = 0;
            nextIndex = 0;

            nextIndex = lastIndex;

            // 프로토콜 가져옴
            _protocol = NextByte();

            // 메시지 사이즈 가져옴
            _messageSize = NextInt();
            lastIndex += MessageSize;
        }

        public int NextInt()
        {
            int result = BitConverter.ToInt32(Message, nextIndex);
            nextIndex += sizeof(int);
            return result;
        }

        public bool NextBool()
        {
            bool result = BitConverter.ToBoolean(Message, nextIndex);
            nextIndex += sizeof(bool);
            return result;
        }

        public float NextFloat()
        {
            float result = BitConverter.ToSingle(Message, nextIndex);
            nextIndex += sizeof(float);
            return result;
        }

        public byte NextByte()
        {
            byte result = Message[nextIndex];
            nextIndex += sizeof(byte);
            return result;
        }

        public string NextString()
        {
            // string 타입은 앞에 몇 byte인지 붙어서 옴
            int length = NextInt();
            string result = Encoding.UTF8.GetString(Message, nextIndex, length);
            nextIndex += Encoding.Default.GetByteCount(result);
            return result;
        }

    }
}
