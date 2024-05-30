using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class DebitCard : Card, ICloneable
    {
        public static int debitCardCount = 0;
        private double balance; // Баланс владельца

        // Свойства для баланса
        public double Balance
        {
            get => balance;
            set
            {
                if (value < 0) { balance = 0; }
                if (value > 10000000) { throw new Exception("Превышел лимит по вашей карте"); } // Лимит хранимых средств: 10млн.
                balance = value;
            }
        }


        // Конструктор без параметров
        public DebitCard() : base()
        {
            Balance = 0;
            debitCardCount++;
        }


        // Конструктор c параметром
        public DebitCard(string id, string name, string time, int num, double balance) : base(id, name, time, num)
        {
            Balance =  balance;
            debitCardCount++;
        }


        // Конструктор копирования
        public DebitCard(DebitCard dCard) : base(dCard)
        {
            Balance = dCard.Balance;
            debitCardCount++;
        }

        // Метод глубокого копирования
        public new object Clone()
        {
            debitCardCount++;
            return new DebitCard(Id, Name, Time, num.number, Balance);
        }

        // Метод поверхностного копирования
        public new object ShallowCopy()
        {
            return MemberwiseClone();
        }

        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса Card
            Balance = (int)InputHelper.InputUintNumber("Введите ваш баланс: "); // Добавляем значение баланса
        }

        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit();                  // Вызываем метод инициализации базового класса DebitCard
            Balance = GenerateRandomBalance();  // Генерирует баланс с помошью ДСЧ
        }

        // Вспомогательный метод для генерации случайного баланса
        public double GenerateRandomBalance()
        {
            return ((rnd.Next(1, 100000)) * rnd.NextDouble());
        }

        // Метод просмотра объектов класса
        public override void Show()
        {
            base.Show();                            // Вызываем метод просмотра базового класса Card
            Console.Write($"\tБаланс: {Balance}");  // Добавляем выведение баланса
        }

        // Метод просмотра объектов класса (НЕ Виртуальный)
        public new void Print()
        {
            base.Print();                               // Вызываем метод просмотра базового класса Card
            Console.Write($"\tБаланс: {Balance}"); // Добавляем выведение баланса
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }

            if (!base.Equals(obj)) { return false; } // Вызываем Equals из базового класса для проверки полей базового класса

            DebitCard otherDebitCard = (DebitCard)obj;

            return Balance == otherDebitCard.Balance; // Сравниваем поля текущего объекта с полями другого объекта
        }
        // Метод для получения количества созданных объектов
        public static int GetObjectCount()
        {
            return debitCardCount;
        }

        // Переопределение метода ToString() для представления объекта в виде строки
        public override string ToString()
        {
            return $"{Id} | {Name} | {Time} | {num} | {Balance}";
        }
    }
}