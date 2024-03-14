using System;
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
            int srd = 0;            // Переменная для записи средней суммы
            int countCredCard = 0;  // Переменная для подсчета карт
            double sredF;           // Переменная для финального подсчета и вывода

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
        public static string[] HoldersExCards(Card[] arr)
        {
            string[] holders = new string[20];
            byte counter = 0;
            foreach (Card item in arr)
            {
                string input = item.Time;               // Получаем срок действия карты
                string[] time = input.Split('/');       // Разделяем строку на числа
                int years = int.Parse(time[1]);         // Записываем год в переменную
                int month = int.Parse(time[0]);         // Записываем месяц в переменную
                if ((month > 2 && years == 24) || (years< 24))  // Проверяем, если срок прошёл то выполняем
                {

                    holders[counter] = (item.Name + " \t ");
                    counter++;
                }
            }
            return holders;
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
                    double balance = ((JunCard)item).Balance;       // Баланс? Молодежнгая карта должна зависить от дебетовой?
                    sum += balance* (cachBack/100);
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Card[] arr = new Card[20];  // Создаём список для хранение экземпляров классов
            for (int i = 0; i < 20;)    // Создаём 20 экземпляров класса
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

            Console.WriteLine("Выводим экземпляры класса (Виртуальными методами)");
            // Выводим экземпляры класса (Виртуальными методами)
            foreach (Card item in arr)
            {
                Console.Write(countCard + ")\t");
                item.Show();
                countCard++;
            }

            // Выводим экземпляры класса (не Виртуальными методами)
            Console.WriteLine("Выводим экземпляры класса (Не виртуальными методами)");



            // Средняя сумма ежемесячных возвратов по доступным лимитам всех кредитных карт.
            Console.WriteLine($"\nСредняя плата по кредитам: \t {AmountMonthlyRefunds(arr)} \n");


            // Владельцы карт с истёкшим сроком действия.
            Console.WriteLine("\nВладельцы просроченных карт:");
            Console.WriteLine("(Дата задана сроком написания: 25.02.24)");
            foreach (var elem in HoldersExCards(arr))
            {
                Console.WriteLine(elem);
            }


            //Общая сумма возможного кешбека по всем действующим молодёжным картам.
            double sum = 0;
            foreach (Card item in arr)
            {
                if (item is JunCard jun)
                {
                    double cachBack = ((JunCard)item).CashBack; // Создаем переменную кешбека 
                    double balance = ((JunCard)item).Balance;   // Баланс? Молодежнгая карта должна зависить от дебетовой?
                    sum += balance * (cachBack/100);
                }
            }
            Console.WriteLine($"\nОбщая сумма возможного кешбека по всем действующим молодёжным картам: \t {sum}");


            // Выводим экземпляры класса (Виртуальными методами)
            countCard = 1;
            Console.WriteLine("\n\nИсходный:\n");
            foreach (Card item in arr)
            {
                Console.Write(countCard + ")\t");
                item.Show();
                countCard++;
            }


            // Создаем элемент для поиска
            Console.WriteLine("\nДобавленная новая карта на 1 слот списка\n");
            DebitCard dcard = new DebitCard("1111 2222 3333 4444", "User", "03/26", 1, 12300);
            arr[0] = dcard;

            // Сортировка по Имени
            Array.Sort(arr);

            // Выводим экземпляры класса
            Console.WriteLine("\nОтсортированный по Id:\n");
            countCard = 1;
            foreach (Card item in arr)
            {
                Console.Write(countCard + ")\t");
                item.Show();
                countCard++;
            }

            // Бинарный поиск по Id
            Console.WriteLine("\nНомер карты в списке: ");
            int pos = Array.BinarySearch(arr, new DebitCard("1111 2222 3333 4444", "User", "03/26", 1, 12300)); // Поиск карты в массиве
            if (pos < 0)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Элемент находится на {pos+1} позиции");
            }



            // Сортировка по сроку карты
            Array.Sort(arr, new SortByTime());


            // Выводим экземпляры класса (Виртуальными методами)
            Console.WriteLine("\n\nОтсортированный по сроку карты:\n");
            countCard = 1;
            foreach (Card item in arr)
            {
                Console.Write(countCard + ")\t");
                item.Show();
                countCard++;
            }


            // Бинарный поиск по Time
            Console.WriteLine("\nНомер карты в списке: ");
            pos = Array.BinarySearch(arr, new DebitCard("1111 2222 3333 4444", "User", "03/26", 1, 12300), new SortByTime()); // Поиск карты в массиве
            if (pos < 0)
            {
                Console.WriteLine("Элемент не найден");
            }
            else
            {
                Console.WriteLine($"Элемент находится на {pos+1} позиции");
            }


            // Демонстрация копирования
            DebitCard dCardOrig = new DebitCard();                      // Создаем объект
            dCardOrig.RandomInit();                                     // Заполняем значениями ДСЧ
            Console.WriteLine("Orig\t" + dCardOrig);                    // Выводим
            DebitCard dCardCopy = (DebitCard)dCardOrig.ShallowCopy();   // Копируем
            Console.WriteLine("Copy\t" + dCardCopy);

            // Демонстрация глубокого копирования
            DebitCard dCardClone = dCardOrig.Clone() as DebitCard;
            Console.WriteLine("Clone\t" + dCardClone);


            Console.WriteLine("После изменений:");
            dCardCopy.Name = "copy" + dCardOrig.Name;
            dCardCopy.num.number = 100;

            dCardClone.Name = "clone" + dCardOrig.Name;
            dCardClone.num.number = 200;
            Console.WriteLine(dCardOrig);
            Console.WriteLine(dCardCopy);
            Console.WriteLine(dCardClone);


            // Подсчитаем кол-во объектов каждого типа
            Console.WriteLine("\n\nКол-во объектов класса Card: \t \t" + Card.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса DebitCard: \t" + DebitCard.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса JunCard: \t" + JunCard.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса CreditCard: \t" + CreditCard.GetObjectCount());
            Console.WriteLine("Кол-во объектов класса GeoCoordinates: \t" + GeoCoordinates.GetObjectCount());
        }
    }
}