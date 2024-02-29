using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLab10;
using ClassLibraryLab9;


namespace LabWork
{
    internal class Program 
    {
        static Random rnd = new Random();
        public static int AmountMonthlyRefunds(Card[] arr)
        {
            int srd = 0;            // Переменная для записи средней суммы
            int countCredCard = 0;  // Переменная для подсчета карт
            double sredF = 0;       // Переменная для финального подсчета и вывода

            // Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
            foreach (Card item in arr)
            {
                if (item is CreditCard cred)
                {
                    srd += (cred.Limit / cred.TimeCredit);
                    countCredCard++;
                }
            }

            sredF = srd / countCredCard;
            return (int)sredF;
        }


        // Владельцы карт с истёкшим сроком действия.
        public static void HoldersExCards(Card[] arr)
        {
            foreach (Card item in arr)
            {
                string input = item.Time;               // Получаем срок действия карты
                string[] time = input.Split(' ');       // Разделяем строку на числа
                int years = int.Parse(time[1]);         // Записываем год в переменную
                int month = int.Parse(time[0]);         // Записываем месяц в переменную
                if ((month > 2 && years == 24) || (years< 24))  // Проверяем, если срок прошёл то выполняем
                {
                    Console.Write(item.Name + " \t ");  // Имя Владельца
                    item.Show();                        // Информация о карте (Для проверки)
                }
            }
}
        //Общая сумма возможного кешбека по всем действующим молодёжным картам
        public static void SumCashback(Card[] arr)
        {
            double sum = 0;
            foreach (Card item in arr)
            {
                if (item is JunCard jun)
                {
                    double cachBack = ((JunCard)item).CashBack; // Создаем переменную кешбека 
                    int balance = ((JunCard)item).Balance;      // Баланс? Молодежнгая карта должна зависить от дебетовой?
                    sum += balance* (cachBack/100);
                }
            }
            Console.WriteLine($"\nОбщая сумма возможного кешбека по всем действующим молодёжным картам: \t {sum}");
        }

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

            Card[] arr = new Card[20];  // Создаём список для хранение экземпляров классов
            for (int i = 0; i < 20;)    // Создаём 10 экземпляров класса
            {
                // Создаём и генерируем объект класса JunCard
                arr[i] = new JunCard();
                arr[i].RandomInit();
                // Создаём и генерируем объект класса CreditCard
                arr[i+1] = new CreditCard();
                arr[i+1].RandomInit();
                i += 2;
            }
            int countCard = 1;


            // Выводим экземпляры класса (Виртуальными методами)
            foreach (Card item in arr) 
            {
                Console.Write(countCard + ")\t");
                item.Show();
                countCard++;
            }


            // Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
            Console.WriteLine($"\nСредняя плата по кредитам: \t {AmountMonthlyRefunds(arr)} \n");


            // Владельцы карт с истёкшим сроком действия.
            Console.WriteLine("\nВладельцы просроченных карт:");
            Console.WriteLine("(Дата задана сроком написания: 25.02.24)");
            HoldersExCards(arr);


            //Общая сумма возможного кешбека по всем действующим молодёжным картам.
            double sum = 0;
            foreach (Card item in arr)
            {
                if (item is JunCard jun)
                {
                    double cachBack = ((JunCard)item).CashBack; // Создаем переменную кешбека 
                    int balance = ((JunCard)item).Balance;      // Баланс? Молодежнгая карта должна зависить от дебетовой?
                    sum += balance * (cachBack/100);
                }
            }
            Console.WriteLine($"\nОбщая сумма возможного кешбека по всем действующим молодёжным картам: \t {sum}");


            // Вывод массива из элементов Локаций
            Console.WriteLine("(лабараторная работа №9) Массив объектов локаций:");
            GeoCoordinatesArray geoArr = new GeoCoordinatesArray(20, rnd);
            geoArr.Show();

        }
    }
}
