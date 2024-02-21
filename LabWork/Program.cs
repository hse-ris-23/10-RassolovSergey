using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Конструктор без параметра
            Console.WriteLine("Конструктор без параметра:");
            Card card1 = new Card();
            card1.Show();
            // Конструктор с параметром
            Console.WriteLine("Конструктор с параметро:");
            Card card2 = new Card("1111 2222 3333 4444", "Ivan Ivanov", "02 06");
            card2.Show();
            // Метод ввода информации об объектах класса с клавиатуры
            Card card3 = new Card();
            card3.Init();
            card3.Show();
            //Метод формирования объектов класса с помощью ДСЧ ?????????
            Card card4 = new Card();
            card4.RandomInit();
            card4.Show();
        }
    }
}
