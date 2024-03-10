using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class DebitCard : Card, IInit10, ICloneable
    {
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
        }
        // Конструктор c параметром
        public DebitCard(string id, string name, string time, int num, double balance) : base(id, name, time, num)
        {
            Balance =  balance;
        }
        // Конструктор копирования
        public DebitCard(DebitCard dCard) : base(dCard)
        {
            Balance = dCard.Balance;
        }
        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса Card
            Balance = (int)InputHelper.InputUintNumber("Введите ваш баланс: ");
        }

        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса DebitCard
            Balance = GenerateRandomBalance();
        }

        // Вспомогательный метод для генерации случайного баланса
        public double GenerateRandomBalance()
        {
            return ((rnd.Next(1, 100000)) * rnd.NextDouble());
        }
        // Метод просмотра объектов класса
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"\tБаланс: {Balance}");
        }

        // Метод просмотра объектов класса (НЕ Виртуальный)
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"\t Баланс: {Balance}");
        }

        // Метод поверхностного копирования
        public new object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Вызываем Equals из базового класса для проверки полей базового класса
            if (!base.Equals(obj))
                return false;

            DebitCard otherDebitCard = (DebitCard)obj;

            // Сравниваем поля текущего объекта с полями другого объекта
            return Balance == otherDebitCard.Balance;
        }
        // Метод глубокого копирования
        public object Clone()
        {
            return new DebitCard(Id, Name, Time, num.number, Balance);
        }
    }
}