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

        public static int InputLimitNumber(int num)
        {
            int timeNum = (int)InputUintNumber("Ваш выбор:");
            if (timeNum > num) { throw new Exception("Ошибка! Некорректный ввод."); }
            else if (timeNum < 0) { throw new Exception("Ошибка! Введите положительное число."); }
            else { return timeNum; }
        }
    }
}