using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class JunCard : Card
    {
        private int cashBack; // Кешбек по карте

        // Свойства кешбека
        public int CashBack
        {
            get => cashBack;
            set
            {
                if (value < 1 || value > 100) { throw new Exception("Невозможный процент кешбека"); }
                cashBack = value;
            }
        }
        // Конструктор без параметров
        public JunCard() : base()
        {
            CashBack = 5;
        }
        // Конструктор c параметром
        public JunCard(string id, string name, string time, int cachBack) : base(id, name, time)
        {
            CashBack = cachBack;
        }
        // Конструктор копирования
        public JunCard(JunCard jCard) : base(jCard)
        {
            CashBack = jCard.CashBack;
        }
        // Метод ввода информации об объектах класса с клавиатуры
        public DebitCard Init()
        {
            Console.WriteLine("Введите ID (используя пробелы): ");
            Id = Console.ReadLine();

            Console.WriteLine("Введите Имя (от 3 до 30 символов): ");
            Name = Console.ReadLine();

            Console.WriteLine("Введите Срок действия (в формате MM YY): ");
            Time = Console.ReadLine();

            CashBack = (int)InputUintNumber("Введите кешбек по вашей карте вашей карты: ");
            DebitCard dCard = new DebitCard(Id, Name, Time, CashBack);
            return dCard;
        }
        // Метод формирования объектов класса с помощью ДСЧ
        public override void RandomInit()
        {
            // Обновляем текущий экземпляр JunCard с случайными значениями
            Id = GenerateRandomId();
            Name = GenerateRandomName();
            Time = GenerateRandomTime();
            CashBack = GenerateRandomTimeCashBack();
        }
        // Вспомогательный метод для генерации случайного процента кешбека
        public int GenerateRandomTimeCashBack()
        {
            return rnd.Next(1, 100);
        }

        // Метод просмотра объектов класса
        public override void Show()
        {
            Console.WriteLine($"ID: {Id} \t Имя: {Name} \t Срок действия: {Time} \t Кешбек: {CashBack}%");
        }
    }
}
