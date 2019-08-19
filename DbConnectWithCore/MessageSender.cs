using System;
using System.Collections.Generic;
using System.Text;

namespace DbConnectWithCore
{
    class MessageSender
    {
        void Sender()
        {
            //Program.SendMessage += WriteSender;
            Program.SendMessage += ReadSender;
        }

        void WriteSender()
        {
            Console.WriteLine("Файл успешно записан!");
        }
        void ReadSender()
        {
            Console.WriteLine("Файл успешно прочитан!");
        }
    }
}
