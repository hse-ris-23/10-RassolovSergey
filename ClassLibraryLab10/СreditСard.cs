using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class CreditCard : Card, IInit10
    {
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
        }
        // Конструктор c параметром
        public CreditCard(string id, string name, string time, int num, int limit, int timeCredit) : base(id, name, time, num)
        {
            Limit = limit;
            TimeCredit = timeCredit;
        }
        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса Card
            Limit = (int)InputHelper.InputUintNumber("Введите баланс вашей карты: ");
            TimeCredit = (int)InputHelper.InputUintNumber("Введите срок погашения кредита: ");
        }

        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса Card
            Limit = GenerateRandomLimit();
            TimeCredit = GenerateRandomTimeCredit();
        }

        // Вспомогательный метод для генерации случайного Лимита по кредиту
        private int GenerateRandomLimit()
        {
            return (rnd.Next(10000, 10000001)); // От 10.000 до 10млн
        }

        // Вспомогательный метод для генерации случайного срока погашения кредита
        private int GenerateRandomTimeCredit()
        {
            return (rnd.Next(1, 97)); // Максимальный срок 8 лет
        }
        // Метод просмотра объектов класса
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"\t Лимит: {Limit} \t Срок погашения: {TimeCredit}");
        }

        // Метод просмотра объектов класса (НЕ Виртуальный)
        public new void Print()
        {
            base.Print();
            Console.WriteLine($"\t Лимит: {Limit} \t Срок погашения: {TimeCredit}");
        }

    }
}
