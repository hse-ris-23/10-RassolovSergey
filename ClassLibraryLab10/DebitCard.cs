using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public abstract class DebitCard : Card, IInit
    {
        private int balance; // Баланс владельца

        // Свойства для баланса
        public int Balance
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
        public DebitCard(string id, string name, string time, int balance) : base(id, name, time)
        {
            Balance =  balance;
        }
        // Конструктор копирования
        public DebitCard(DebitCard dCard) : base(dCard)
        {
            Balance = balance;
        }
        // Реализация метода Init интерфейса IInit
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса Card
            Balance = (int)InputUintNumber("Введите ваш баланс: ");
        }

        // Реализация метода RandomInit интерфейса IInit
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса DebitCard
            Balance = GenerateRandomBalance();
        }

        // Вспомогательный метод для генерации случайного баланса
        public int GenerateRandomBalance()
        {
            return (rnd.Next(1, 100000));
        }
        // Метод просмотра объектов класса
        public abstract override void Show();
    }
}
