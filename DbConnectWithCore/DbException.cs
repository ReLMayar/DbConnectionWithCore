using System;

namespace DbConnectWithCore
{
    static class DbException
    {
        public static void TryAddData(this Exception exception)
        {
            Console.Write("Не удалось добавить данные, попытка загрузки данных");
        }

        public static void UnknownException(this Exception exception)
        {
            Console.WriteLine("Неизвестная ошибка, попробуйте позже!");
        }
    }
}