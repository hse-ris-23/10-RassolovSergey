using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class JunCard : DebitCard, IInit
    {
        public static int junCardCount = 0;
        private double cashBack; // Кешбек по карте

        // Свойства кешбека
        public double CashBack
        {
            get => cashBack;
            set
            {
                if (value < 0 || value > 100) { throw new Exception("Невозможный процент кешбека"); }
                cashBack = value;
            }
        }


        // Конструктор без параметров
        public JunCard() : base()
        {
            CashBack = 3.5;
            junCardCount++;
        }


        // Конструктор c параметром
        public JunCard(string id, string name, string time, int num, double balance, double cashBack) : base(id, name, time, num, balance)
        {
            CashBack = cashBack;
            junCardCount++;
        }


        // Конструктор копирования
        public JunCard(JunCard jCard) : base(jCard)
        {
            CashBack = jCard.CashBack;
            junCardCount++;
        }

        // Метод глубокого копирования
        public new object Clone()
        {
            junCardCount++;
            return new JunCard(Id, Name, Time, num.number, Balance, CashBack);
        }


        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса DebitCard
            CashBack = (int)InputHelper.InputUintNumber("Введите кешбек по вашей карте: "); // Вводим значение кэшбека
        }


        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса DebitCard
            CashBack = GenerateRandomTimeCashBack(); // Генерируем значение кэшбека
        }


        // Вспомогательный метод для генерации случайного процента кешбека
        public double GenerateRandomTimeCashBack()
        {
            return rnd.Next(1, 100) * rnd.NextDouble(); // Генерируем процент (от 0.00001... до 99.99999...)
        }


        // Метод просмотра объектов класса (Виртуальный)
        public override void Show()
        {
            base.Show(); // Вызываем виртуальный метод вывода базового класса DebitCard 
            Console.Write($"\tКешбек: {CashBack}%"); // Выводим новое значение кешбека
        }


        // Метод просмотра объектов класса (НЕ Виртуальный)
        public new void Print()
        {
            base.Print(); // Вызываем не виртуальный метод вывода базового класса DebitCard 
            Console.Write($"\tКешбек: {CashBack}%"); // Генерируем новое значение кешбека
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }

            if (!base.Equals(obj)) { return false; } // Вызываем Equals из базового класса для проверки полей базового класса

            JunCard otherJunCard = (JunCard)obj;

            // Сравниваем поля текущего объекта с полями другого объекта
            return CashBack == otherJunCard.CashBack;
        }
        // Метод для получения количества созданных объектов
        public new static int GetObjectCount()
        {
            return junCardCount;
        }

        // Переопределение метода ToString() для представления объекта в виде строки
        public override string ToString()
        {
            return $"{Id} | {Name} | {Time} | {num} | {Balance} | {cashBack}";
        }
    }
}