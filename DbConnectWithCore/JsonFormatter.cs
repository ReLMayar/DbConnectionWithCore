using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DbConnectWithCore
{
    class JsonFormatter
    {
        public static event Action FileWritten;
        public static event Action FileRead;

        public async void SerializeObjectAsync<T>(T fileToWrite, string path)
        {
            await Task.Run(() => SerializeObject(fileToWrite, path));
        }

        public async void DeserializeObjectAsync<T>(T fileFormat, string path)
        {
            await Task.Run(() => DeserializeObject(fileFormat, path));
        }

        private void SerializeObject<T>(T fileToWrite, string path)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, fileToWrite);
                FileWritten?.Invoke();
            }
        }

        private T DeserializeObject<T>(T fileFormat, string path)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(T));
            using (var file = new FileStream(path, FileMode.OpenOrCreate))
            {
                fileFormat = (T)jsonFormatter.ReadObject(file);
                FileRead?.Invoke();

                for (int i = 0; i < 3000; i += 1000)
                {
                    Thread.Sleep(i);
                    Console.Write(".");
                }

                return fileFormat;
            }
        }
    }
}