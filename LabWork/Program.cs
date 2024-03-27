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
        public static int AmountMonthlyRefunds(Card[] arr)  // Используется typeof и as
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
        public static double SumCashback(Card[] arr)  // Используется is
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
                if (item is JunCard jCard)    // Проверяем что item является объектом класса JunCard
                {
                    jCard.Print();
                }
                else if (item is DebitCard dCard)
                {
                    dCard.Print();
                }
                else if (item is CreditCard creditCard)
                {
                    creditCard.Print();
                }
                else if (item is Card card)  // Проверяем что item является объектом класса Card
                {
                    card.Print();
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
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (GeoCoordinates item in arrLocal)
            {
                Console.Write(helperCountCard + ")\t");
                item.Show();
                helperCountCard++;
            }
            Console.WriteLine("-------------------------------------------------------------------");

            // Создаем массив из 50 объектов
            object[] objects = new object[50];

            // Заполняем массив объектами различных классов с помощью RandomInit
            Random rnd = new Random();
            for (int i = 0; i < objects.Length; i++)
            {
                int classType = rnd.Next(5); // Генерируем случайное число от 0 до 4, чтобы определить тип объекта

                switch (classType)
                {
                    case 0: // Создаем объект класса DebitCard
                        DebitCard debitCard = new DebitCard();
                        debitCard.RandomInit();
                        objects[i] = debitCard;
                        break;
                    case 1: // Создаем объект класса JunCard
                        JunCard junCard = new JunCard();
                        junCard.RandomInit();
                        objects[i] = junCard;
                        break;
                    case 2: // Создаем объект класса CreditCard
                        CreditCard creditCard = new CreditCard();
                        creditCard.RandomInit();
                        objects[i] = creditCard;
                        break;
                    case 3: // Создаем объект класса GeoCoordinates
                        GeoCoordinates geoCoordinates = new GeoCoordinates();
                        geoCoordinates.RandomInit();
                        objects[i] = geoCoordinates;
                        break;
                    case 4: // Создаем объект класса Card
                        Card card = new Card();
                        card.RandomInit();
                        objects[i] = card; 
                        break;
                }
            }

            // Выводим информацию о каждом объекте после вызова метода RandomInit
            Console.WriteLine("\n\nМассив объектов ВСЕХ классов:");

            helperCountCard = 1; // Вспомогательная переменная

            // Создаем счетчикм для подсчета кол-во объектов каждого класса в массиве
            // (в теории можно сделать слоднее, но нужно ли это когда у нас всего 5 классов)
            int CountJunCard = 0;
            int CountDebitCard = 0;
            int CountCreditCard = 0;
            int CountCard = 0;
            int CountGeoCoordinates = 0;

            // Перебор и вывод  всех элементов массива
            Console.WriteLine("\n-------------------------------------------------------------------");
            foreach (var obj in objects)
            {
                Console.Write("\n" + helperCountCard + ")\t"); // Вывод номера "1), 2), 3)"
                if (obj is JunCard jCard)
                {
                    jCard.Show();
                    CountJunCard++;
                }
                else if (obj is DebitCard dCard)
                {
                    dCard.Show();
                    CountDebitCard++;
                }
                else if (obj is CreditCard creditCard)
                {
                    creditCard.Show();
                    CountCreditCard++;
                }
                else if (obj is Card card)
                {
                    card.Show();
                    CountCard++;
                }
                else if (obj is GeoCoordinates loc)
                {
                    loc.Show();
                    CountGeoCoordinates++;
                }
                helperCountCard++; // Добавление +1 к номеру
            }
            Console.WriteLine("\n-------------------------------------------------------------------");

            Console.WriteLine("\nДанный массив содержит следующие объекты классов:");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Объекты класса Card: {CountCard} экземпляров");
            Console.WriteLine($"Объекты класса DebitCard: {CountDebitCard} экземпляров");
            Console.WriteLine($"Объекты класса JunCard: {CountJunCard} экземпляров");
            Console.WriteLine($"Объекты класса CreditCard: {CountCreditCard} экземпляров");
            Console.WriteLine($"Объекты класса GeoCoordinates: {CountGeoCoordinates} экземпляров");
            Console.WriteLine("-------------------------------------------------------------------");



            // Выводим информацию о количестве созданных объектов для каждого класса
            Console.WriteLine("\nВ данной программе было использованно:");
            Console.WriteLine("-------------------------------------------------------------------");
            Console.WriteLine($"Объекты класса Card: {Card.GetObjectCount()}");
            Console.WriteLine($"Объекты класса DebitCard: {DebitCard.GetObjectCount()}");
            Console.WriteLine($"Объекты класса JunCard: {JunCard.GetObjectCount()}");
            Console.WriteLine($"Объекты класса CreditCard: {CreditCard.GetObjectCount()}");
            Console.WriteLine($"Объекты класса GeoCoordinates: {GeoCoordinates.GetObjectCount()}");
            Console.WriteLine("-------------------------------------------------------------------");
        }
    }
}