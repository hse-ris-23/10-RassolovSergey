﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ClassLibraryLab10;


namespace LabWork
{
    internal class Program
    {
        public static int AmountMonthlyRefunds(Card[] arr)
        {
            int totalRefunds = 0;   // Общая сумма возвратов
            int creditCardCount = 0; // Количество кредитных карт

            // Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
            foreach (Card item in arr)
            {
                if (item.GetType() == typeof(CreditCard)) // Проверяем, является ли текущий элемент экземпляром класса CreditCard
                {
                    CreditCard cred = item as CreditCard; // Приводим текущий элемент к типу CreditCard
                    if (cred.TimeCredit != 0) // Проверяем, что значение TimeCredit не равно 0
                    {
                        totalRefunds += cred.Limit / cred.TimeCredit; // Вычисляем ежемесячный возврат и добавляем к общей сумме
                        creditCardCount++; // Увеличиваем счетчик кредитных карт
                    }
                }
            }

            int averageRefund = 0; // Средний возврат
            if (creditCardCount != 0)
            {
                averageRefund = totalRefunds / creditCardCount; // Вычисляем средний возврат, предотвращая деление на ноль
            }

            return averageRefund; // Возвращаем средний возврат
        }

        // Вычисление владельцев карт с истекшим сроком действия
        public static string[] HoldersExCards(Card[] arr)
        {
            string[] holders = new string[40]; // Строка для записи имен (максимальное кол-во 40 т.к. мы рассматриваем список из 40 человек)
            byte counter = 0;
            foreach (Card item in arr)
            {
                string input = item.Time;               // Получаем срок действия карты
                string[] time = input.Split('/');       // Разделяем строку на числа
                int years = int.Parse(time[1]);         // Записываем год в переменную
                int month = int.Parse(time[0]);         // Записываем месяц в переменную
                if ((month > 2 && years == 24) || (years < 24))  // Проверяем, если срок прошёл то выполняем
                {
                    holders[counter] = (item.Name + " \t ");
                    counter++;
                }
            }
            return holders;
        }

        // Вывод на консоль владельцев карт с истекшим сроком действия
        public static void PrintHoldersExCards(string[] holders)
        {
            Console.WriteLine("\nВладельцы просроченных карт:");
            Console.WriteLine("(Дата задана сроком написания: 25.02.24)");
            foreach (var item in holders)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                }
            }
        }

        //Общая сумма возможного кешбека по всем действующим молодёжным картам
        public static double SumCashback(Card[] arr)
        {
            double sum = 0;
            foreach (Card item in arr)
            {
                if (item is JunCard jun)
                {
                    double cachBack = ((JunCard)item).CashBack;     // Создаем переменную кешбека 
                    double balance = ((JunCard)item).Balance;       // Создаем переменную баланса
                    sum += balance* (cachBack/100);
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Card[] arrCard = new Card[40];  // Создаём список для хранение экземпляров классов


            // Создаём 40 экземпляров класса
            for (int i = 0; i < 40; i += 4) 
            {
                // Создаем и генерируем объект класса Card
                arrCard[i] = new Card();
                arrCard[i].RandomInit();
                // Создаем и генерируем объект класса DebitCard
                arrCard[i+1] = new DebitCard();
                arrCard[i+1].RandomInit();
                // Создаём и генерируем объект класса JunCard
                arrCard[i+2] = new JunCard();
                arrCard[i+2].RandomInit();
                // Создаём и генерируем объект класса CreditCard
                arrCard[i+3] = new CreditCard();
                arrCard[i+3].RandomInit();
            }



            // Вывод экземпляров класса arrCard
            // Выводим экземпляры класса (Виртуальными методами)
            Console.WriteLine("Выводим экземпляры класса (Виртуальными методами)");
            int helperCountCard = 1;
            foreach (Card item in arrCard)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                Console.WriteLine();
                helperCountCard++;
            }


            // Выводим экземпляры класса (не Виртуальными методами)
            Console.WriteLine("Выводим экземпляры класса (Не виртуальными методами)");
            helperCountCard = 1;
            foreach (Card item in arrCard)
            {
                Console.Write($"\n{helperCountCard}" + ")\t");  // Проверяем что item является объектом класса DebitCard
                if (item is JunCard)    // Проверяем что item является объектом класса JunCard
                {
                    JunCard jCard = item as JunCard;
                    jCard.Print();
                }
                else if (item is DebitCard)
                {
                    DebitCard dCard = item as DebitCard;
                    dCard.Print();
                }
                else if (typeof(CreditCard).IsInstanceOfType(item)) // Проверяем что item является объектом класса CreditCard
                {
                    CreditCard creditCard = item as CreditCard;
                    creditCard.Print();
                }
                else if (item is Card)  // Проверяем что item является объектом класса Card
                {
                    item.Print();
                }
                helperCountCard++;
            }



            // Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
            Console.WriteLine($"\nСредняя плата по кредитам: \t {AmountMonthlyRefunds(arrCard)} \n");


            // Владельцы карт с истёкшим сроком действия.
            string[] holders = HoldersExCards(arrCard); // Создаем список владельцев просроченных карт
            PrintHoldersExCards(holders);               // Выводим список владельцев просроченных карт


            //Общая сумма возможного кешбека по всем действующим молодёжным картам.
            Console.WriteLine($"\nОбщая сумма возможного кешбека по всем действующим молодёжным картам: \t {SumCashback(arrCard)}");



            // Создаем элемент для поиска
            Console.WriteLine("\nДобавленная новая карта на 1 слот списка\n");
            DebitCard dcard = new DebitCard("1111 2222 3333 4444", "User", "03/26", 1, 12300);
            arrCard[0] = dcard;

            // Выводим экземпляры класса
            Console.WriteLine("\nДо сортировки:\n");
            helperCountCard = 1;
            foreach (Card item in arrCard)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                Console.WriteLine();
                helperCountCard++;
            }

            // Сортировка по Id
            Array.Sort(arrCard);

            // Выводим экземпляры класса
            Console.WriteLine("\nОтсортированный по Id:\n");
            helperCountCard = 1;
            foreach (Card item in arrCard)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                Console.WriteLine();
                helperCountCard++;
            }

            // Бинарный поиск по Id
            Console.Write("\nНомер карты в списке: \t");
            int pos = Array.BinarySearch(arrCard, new DebitCard("1111 2222 3333 4444", "User", "03/26", 1, 12300)); // Поиск карты в массиве
            if (pos < 0)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Элемент находится на {pos+1} позиции");
            }



            // Сортировка по сроку карты
            Array.Sort(arrCard, new SortByTime());


            // Выводим экземпляры класса (Виртуальными методами)
            Console.WriteLine("\n\nОтсортированный по сроку карты:\n");
            helperCountCard = 1;
            foreach (Card item in arrCard)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                Console.WriteLine();
                helperCountCard++;
            }



            // Бинарный поиск по Time
            Console.WriteLine("\nНомер карты в списке: ");
            pos = Array.BinarySearch(arrCard, new DebitCard("1111 2222 3333 4444", "User", "03/26", 1, 12300), new SortByTime()); // Поиск карты в массиве
            if (pos < 0)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Элемент находится на {pos+2} позиции");
            }


            // Демонстрация копирования
            Console.WriteLine("\n\nДемонстрация поверхностного и глубокого копирования"); 
            DebitCard dCardOrig = new DebitCard();                      // Создаем объект
            dCardOrig.RandomInit();                                     // Заполняем значениями ДСЧ
            Console.WriteLine("Orig\t" + dCardOrig);                    // Выводим

            DebitCard dCardCopy = (DebitCard)dCardOrig.ShallowCopy();   // Копируем
            Console.WriteLine("Copy\t" + dCardCopy);                    // Выводим

            DebitCard dCardClone = dCardOrig.Clone() as DebitCard;      // Копируем
            Console.WriteLine("Clone\t" + dCardClone);                  // Выводим


            Console.WriteLine("\n\nПосле изменений:");                      
            dCardCopy.Name = dCardOrig.Name;
            dCardCopy.num.number = 100;

            dCardClone.Name = dCardOrig.Name;
            dCardClone.num.number = 200;
            Console.WriteLine("Orig\t" + dCardOrig);
            Console.WriteLine("Copy\t" + dCardCopy);
            Console.WriteLine("Clone\t" + dCardClone);



            GeoCoordinates[] arrLocal = new GeoCoordinates[40];  // Создаём список для хранение экземпляров классов


            // Создаём 40 экземпляров класса
            for (int i = 0; i < 40; i++)
            {
                // Создаем и генерируем объект класса Card
                arrLocal[i] = new GeoCoordinates();
                arrLocal[i].RandomInit();
            }

            // Добавляем 1 элемент для поиска
            Console.WriteLine(" \n\n(Добавлен 1 элемент для поиска)");
            GeoCoordinates searchloc = new GeoCoordinates(10, -10);
            arrLocal[0] = searchloc;



            // Вывод экземпляров класса arrLocal
            // Выводим экземпляры класса (Виртуальными методами)
            Console.WriteLine("Выводим экземпляры класса (Виртуальными методами)");
            helperCountCard = 1;
            foreach (GeoCoordinates item in arrLocal)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                helperCountCard++;
            }

            // Сортировка по Широте
            Array.Sort(arrLocal);

            // Выводим экземпляры класса
            Console.WriteLine("\nОтсортированный по Широте:\n");
            helperCountCard = 1;
            foreach (GeoCoordinates item in arrLocal)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                helperCountCard++;
            }

            // Бинарный поиск по Широте
            Console.Write("\nНомер локации в списке: \t");
            GeoCoordinates target = new GeoCoordinates(10, -10);
            int posLoc = Array.BinarySearch(arrLocal, target);
            if (posLoc < 0)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Элемент находится на {posLoc + 1} позиции");
            }

            // Сортировка по Долготе
            Array.Sort(arrLocal, new SortByLongitude());


            // Выводим экземпляры класса
            Console.WriteLine("\nОтсортированный по Долготе:\n");
            helperCountCard = 1;
            foreach (GeoCoordinates item in arrLocal)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                helperCountCard++;
            }

            // Подсчитаем кол-во объектов каждого типа
            Console.WriteLine("\n\nКол-во объектов класса Card: \t \t" + Card.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса DebitCard: \t" + DebitCard.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса JunCard: \t" + JunCard.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса CreditCard: \t" + CreditCard.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса GeoCoordinates: \t" + GeoCoordinates.GetObjectCount());
        }
    }
}