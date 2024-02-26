using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryLabWork9;

namespace ClassLibraryLab10
{
    public class CreditCard : Card, IInit
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
        public CreditCard(string id, string name, string time, int limit, int timeCredit) : base(id, name, time)
        {
            Limit = limit;
            TimeCredit = timeCredit;
        }
        // Конструктор копирования
        public CreditCard(CreditCard credCard) : base(credCard)
        {
            Limit = credCard.Limit;
            TimeCredit = credCard.TimeCredit;
        }
        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса Card
            Limit = (int)InputUintNumber("Введите баланс вашей карты: ");
            TimeCredit = (int)InputUintNumber("Введите срок погашения кредита: ");
        }

        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса Card
            Limit = GenerateRandomLimit();
            TimeCredit = GenerateRandomTimeCredit();
        }

        // Вспомогательный метод для генерации случайного Лимита по кредиту
        public virtual int GenerateRandomLimit()
        {
            return (rnd.Next(10000, 10000001)); // От 10.000 до 10млн
        }

        // Вспомогательный метод для генерации случайного срока погашения кредита
        public int GenerateRandomTimeCredit()
        {
            return (rnd.Next(1, 97)); // Максимальный срок 8 лет
        }
        // Метод просмотра объектов класса
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"\t Лимит: {Limit} \t Срок погашения: {TimeCredit}");
        }
    }
}
