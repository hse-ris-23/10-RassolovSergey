using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork
{
    internal class NumberClass
    {
        // Вспомогательная функция Проверка ввода числа (Uint)
        protected static uint InputUintNumber(string msg)
        {
            Console.Write(msg);
            bool isConvert;
            uint number;
            do
            {
                isConvert = uint.TryParse(Console.ReadLine(), out number);
                Console.ForegroundColor = ConsoleColor.Red;
                if (!isConvert) Console.WriteLine("Ошибка! Введите целое положительное число.");
                Console.ForegroundColor = ConsoleColor.White;
            } while (!isConvert);
            return number;
        }
    }
}
