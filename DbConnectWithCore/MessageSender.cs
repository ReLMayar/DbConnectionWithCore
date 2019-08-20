using System;

namespace DbConnectWithCore
{
    class MessageSender
    {
        public MessageSender()
        {
            JsonFormatter.FileWritten += ReadSender;
            JsonFormatter.FileRead += WriteSender;
        }
        void WriteSender()
        {
            Console.WriteLine("Файл успешно записан!");
            JsonFormatter.FileWritten -= WriteSender;
        }
        void ReadSender()
        {
            Console.WriteLine("Файл успешно прочитан!");
            JsonFormatter.FileRead -= ReadSender;
        }
    }
}
