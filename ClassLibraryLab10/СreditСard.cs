using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class CreditCard : Card, IInit
    {
        public static int creditCardCount = 0;
        private int limit; // Лимит средств
        private int timeCredit; // Срок погашения

        // Свойства Лимита
        public int Limit
        {
            get => limit;
            set
            {
                if (value <= 0) { throw new Exception("Вам не одобрен кредит"); }
                limit = value;
            }
        }


        // Свойства срока погашения
        public int TimeCredit
        {
            get => timeCredit;
            set
            {
                if (value <= 0) { throw new Exception("Срок истёк!"); } // Счет в месяцах
                timeCredit = value;
            }
        }


        // Конструктор без параметров
        public CreditCard() : base()
        {
            limit = 10000; // 10.000 рублей 
            timeCredit = 12; // Срок на 12 месяцев
            creditCardCount++;
        }


        // Конструктор c параметром
        public CreditCard(string id, string name, string time, int num, int limit, int timeCredit) : base(id, name, time, num)
        {
            Limit = limit;
            TimeCredit = timeCredit;
            creditCardCount++;
        }

        // Конструктор копирования
        public CreditCard(CreditCard creditCard) : base(creditCard)
        {
            Limit = creditCard.Limit;
            creditCardCount++;
        }

        // Метод глубокого копирования
        public new object Clone()
        {
            creditCardCount++;
            return new JunCard(Id, Name, Time, num.number, Limit, TimeCredit);
        }


        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса Card
            Limit = (int)InputHelper.InputUintNumber("Введите баланс вашей карты: ");           // Получаем значение для поля Limit
            TimeCredit = (int)InputHelper.InputUintNumber("Введите срок погашения кредита: ");  // Получаем значение для поля TimeCredit
        }


        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса Card
            Limit = GenerateRandomLimit();              // Генерируем значение для поля Limit
            TimeCredit = GenerateRandomTimeCredit();    // Генерируем значение для поля TimeCredit
        }


        // Вспомогательный метод для генерации случайного Лимита по кредиту
        private int GenerateRandomLimit()
        {
            return (rnd.Next(10000, 10000001)); // От 10.000 до 10 млн.
        }


        // Вспомогательный метод для генерации случайного срока погашения кредита
        private int GenerateRandomTimeCredit()
        {
            return (rnd.Next(1, 97)); // Максимальный срок 8 лет (96 месяцев)
        }


        // Метод просмотра объектов класса (Виртуальный)
        public override void Show()
        {
            base.Show();    // Выводим основные значение класса Card
            Console.WriteLine($"\tЛимит: {Limit} \t                Срок погашения: {TimeCredit}"); // Выводим значение класса CreditCard (Limit и TimeCredit)
        }


        // Метод просмотра объектов класса (Не Виртуальный)
        public new void Print() 
        {
            base.Print(); // Выводим основные значение класса Card
            Console.WriteLine($"\tЛимит: {Limit} \t                Срок погашения: {TimeCredit}"); // Выводим значение класса CreditCard (Limit и TimeCredit)
        }


        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType()) { return false; }

            if (!base.Equals(obj)) { return false; } // Вызываем Equals из базового класса для проверки полей базового класса

            CreditCard otherCreditCard = (CreditCard)obj;

            // Сравниваем поля текущего объекта с полями другого объекта
            return Limit == otherCreditCard.Limit && TimeCredit == otherCreditCard.TimeCredit;
        }
        // Метод для получения количества созданных объектов
        public new static int GetObjectCount()
        {
            return creditCardCount;
        }

        // Переопределение метода ToString() для представления объекта в виде строки
        public override string ToString()
        {
            base.ToString();
            return $"{Id} {Name} {Time} {num} {limit} {timeCredit}";
        }
    }
}
