using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class JunCard : DebitCard, IInit10
    {
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
            CashBack = 5;
        }
        // Конструктор c параметром
        public JunCard(string id, string name, string time, int num, int balance, int cashBack) : base(id, name, time, num, balance)
        {
            CashBack = cashBack;
        }
        // Конструктор копирования
        public JunCard(JunCard jCard) : base(jCard)
        {
            CashBack = jCard.CashBack;
        }

        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса DebitCard
            CashBack = (int)InputHelper.InputUintNumber("Введите кешбек по вашей карте: ");
        }

        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса DebitCard
            CashBack = GenerateRandomTimeCashBack();
        }

        // Вспомогательный метод для генерации случайного процента кешбека
        public double GenerateRandomTimeCashBack()
        {
            return rnd.Next(1, 100) * rnd.NextDouble();
        }

        // Метод просмотра объектов класса
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"\t Кешбек: {CashBack}%");
        }

        // Метод просмотра объектов класса (НЕ Виртуальный)
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"\t Кешбек: {CashBack}%");
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Вызываем Equals из базового класса для проверки полей базового класса
            if (!base.Equals(obj))
                return false;

            JunCard otherJunCard = (JunCard)obj;

            // Сравниваем поля текущего объекта с полями другого объекта
            return CashBack == otherJunCard.CashBack;
        }

    }
}