using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public static class InputHelper
    {
        public static uint InputUintNumber(string msg)
        {
            uint result;
            while (true)
            {
                Console.Write(msg);
                if (uint.TryParse(Console.ReadLine(), out result))
                {
                    return result;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите положительное целое число.");
                }
            }
        }
    }
}