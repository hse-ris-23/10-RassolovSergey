using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class DebitCard : Card
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
            Balance = dCard.Balance;
        }
        // Метод ввода информации об объектах класса с клавиатуры
        public override void Init()
        {
            Console.WriteLine("Введите ID (используя пробелы): ");
            Id = Console.ReadLine();

            Console.WriteLine("Введите Имя (от 3 до 30 символов): ");
            Name = Console.ReadLine();

            Console.WriteLine("Введите Срок действия (в формате MM YY): ");
            Time = Console.ReadLine();

            Balance = (int)InputUintNumber("Введите баланс вашей карты: ");
            DebitCard dCard = new DebitCard(Id, Name, Time, Balance);
        }
        // Метод формирования объектов класса с помощью ДСЧ
        public override void RandomInit()
        {
            // Обновляем текущий экземпляр DebitCard с случайными значениями
            Id = GenerateRandomId();
            Name = GenerateRandomName();
            Time = GenerateRandomTime();
            Balance = GenerateRandomBalance();
        }

        // Вспомогательный метод для генерации случайного баланса
        public int GenerateRandomBalance()
        {
            return (rnd.Next(1, 100000));
        }
        // Метод просмотра объектов класса
        public override void Show()
        {
            Console.WriteLine($"ID: {Id} \t Имя: {Name} \t Срок действия: {Time} \t Баланс: {Balance}");
        }
    }
}
