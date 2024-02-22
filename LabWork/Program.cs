﻿using System;
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
            //// Демонстрация класса Card
            {
                //// Класс CARD
                //// Конструктор без параметра
                //Console.WriteLine("\nКонструктор без параметра:");
                //Card card1 = new Card();
                //card1.Show();
                //// Конструктор с параметром
                //Console.WriteLine("\nКонструктор с параметро:");
                //Card card2 = new Card("1111 2222 3333 4444", "Ivan Ivanov", "02 06");
                //card2.Show();
                //// Конструктор копировнаия
                //Console.WriteLine("\nКонструктор копировнаия:");
                //Card card2Copy = new Card(card2);
                //card2Copy.Show();
                //// Метод ввода информации об объектах класса с клавиатуры
                //Console.WriteLine("\nМетод ввода информации об объектах класса с клавиатур:");
                //Card card3 = new Card();
                //card3.Init();
                //card3.Show();
                ////Метод формирования объектов класса с помощью ДСЧ
                //Console.WriteLine("\nМетод формирования объектов класса с помощью ДСЧ:");
                //Card card4 = new Card();
                //card4.RandomInit();
                //card4.Show();
            }
            //// Демонстрация класса DebitCard
            {
                //// Класс DebitCard
                //// Конструктор Дебетовой карты без параметра
                //Console.WriteLine("\nКонструктор Дебетовой карты без параметра:");
                //DebitCard dCard1 = new DebitCard();
                //dCard1.Show();
                //// Конструктор Дебетовой карты с параметром
                //Console.WriteLine("\nКонструктор Дебетовой карты с параметром:");
                //DebitCard dCard2 = new DebitCard("4444 3333 2222 1111", "Ivan Ivanov", "05 26", 2340);
                //dCard2.Show();
                //// Конструктор Дебетовой карты "Копирования"
                //Console.WriteLine("\nКонструктор Дебетовой карты \"Копирования\":");
                //DebitCard dCard2Copy = new DebitCard(dCard2);
                //dCard2Copy.Show();
                //// Метод ввода информации об объектах класса с клавиатуры
                //Console.WriteLine("\n(Дебетовая карта) Метод ввода информации об объектах класса с клавиатуры:");
                //DebitCard dCard3 = new DebitCard();
                //dCard3.Init();
                //dCard3.Show();
                //// Метод формирования объектов класса с помощью ДСЧ
                //Console.WriteLine("\n(Дебетовая карта) Метод формирования объектов класса с помощью ДСЧ:");
                //DebitCard dCard4 = new DebitCard();
                //DebitCard dCard5 = new DebitCard();
                //dCard4.RandomInit();
                //dCard4.Show();
                //dCard5.RandomInit();
                //dCard5.Show();
            }
            //// Демонстрация класса JunCard
            {
                //// Класс JunCard
                //// Конструктор Дебетовой карты без параметра
                //Console.WriteLine("\nКонструктор молодёжной карты без параметра:");
                //JunCard jCard1 = new JunCard();
                //jCard1.Show();
                //// Конструктор Дебетовой карты с параметром
                //Console.WriteLine("\nКонструктор молодёжной карты с параметром:");
                //JunCard jCard2 = new JunCard("4444 3333 2222 1111", "Ivan Ivanov", "05 26", 12);
                //jCard2.Show();
                //// Конструктор Дебетовой карты "Копирования"
                //Console.WriteLine("\nКонструктор молодёжной карты \"Копирования\":");
                //JunCard jCard2Copy = new JunCard(jCard2);
                //jCard2Copy.Show();
                //// Метод ввода информации об объектах класса с клавиатуры
                //Console.WriteLine("\n(Молодёжной карта) Метод ввода информации об объектах класса с клавиатуры:");
                //JunCard jCard3 = new JunCard();
                //jCard3.Init();
                //jCard3.Show();
                //// Метод формирования объектов класса с помощью ДСЧ
                //Console.WriteLine("\n(Молодёжной карта) Метод формирования объектов класса с помощью ДСЧ:");
                //JunCard jCard4 = new JunCard();
                //JunCard jCard5 = new JunCard();
                //jCard4.RandomInit();
                //jCard4.Show();
                //jCard5.RandomInit();
                //jCard5.Show();
            }
            //// Демонстрация класса CreditCard
            {
                //// Класс CreditCard
                //// Конструктор Дебетовой карты без параметра
                //Console.WriteLine("\nКонструктор кредитной карты без параметра:");
                //CreditCard credCard1 = new CreditCard();
                //credCard1.Show();
                //// Конструктор Дебетовой карты с параметром
                //Console.WriteLine("\nКонструктор кредитной карты с параметром:");
                //CreditCard credCard2 = new CreditCard("4444 3333 2222 1111", "Ivan Ivanov", "05 26", 100000, 48);
                //credCard2.Show();
                //// Конструктор Дебетовой карты "Копирования"
                //Console.WriteLine("\nКонструктор кредитной карты \"Копирования\":");
                //CreditCard credCard2Copy = new CreditCard(credCard2);
                //credCard2Copy.Show();
                //// Метод ввода информации об объектах класса с клавиатуры
                //Console.WriteLine("\n(Кредитная карта) Метод ввода информации об объектах класса с клавиатуры:");
                //CreditCard credCard3 = new CreditCard();
                //credCard3.Init();
                //credCard3.Show();
                //// Метод формирования объектов класса с помощью ДСЧ
                //Console.WriteLine("\n(Кредитная карта) Метод формирования объектов класса с помощью ДСЧ:");
                //CreditCard credCard4 = new CreditCard();
                //CreditCard credCard5 = new CreditCard();
                //credCard4.RandomInit();
                //credCard4.Show();
                //credCard5.RandomInit();
                //credCard5.Show();
            }

            Card[] arr = new Card[40]; // Создаём список для хранение экземпляров классов
            for (int i = 0; i < 40;) // Создаём 10 экземпляров класса
            {
                // Создаём и генерируем объект класса Card
                arr[i] = new Card();
                arr[i].RandomInit();
                // Создаём и генерируем объект класса DebitCard
                arr[i+1] = new DebitCard();
                arr[i+1].RandomInit();
                // Создаём и генерируем объект класса JunCard
                arr[i+2] = new JunCard();
                arr[i+2].RandomInit();
                // Создаём и генерируем объект класса CreditCard
                arr[i+3] = new CreditCard();
                arr[i+3].RandomInit();
                i += 4;
            }
            int countDebitCard = 1;
            foreach (Card item in arr) // Выводим экземпляры класса
            {
                if (item is DebitCard) { }
                Console.Write(countDebitCard + ")\t");
                item.Show();
                countDebitCard++;
            }
        }
    }
}
