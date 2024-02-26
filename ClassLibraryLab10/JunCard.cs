using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class JunCard : DebitCard
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
        public JunCard(string id, string name, string time, int balance, int cashBack) : base(id, name, time, balance)
        {
            CashBack = cashBack;
        }
        // Конструктор копирования
        public JunCard(JunCard jCard) : base(jCard)
        {
            CashBack = jCard.CashBack;
        }

        // Реализация абстрактного метода для ввода информации
        public override void Init()
        {
            base.Init(); // Вызываем метод инициализации базового класса DebitCard
            CashBack = (int)InputUintNumber("Введите кешбек по вашей карте: ");
        }

        // Метод формирования объектов класса с помощью ДСЧ
        public override void RandomInit()
        {
            base.RandomInit(); // Вызываем метод инициализации базового класса DebitCard
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
            Console.WriteLine($"ID: {Id} \t Имя: {Name} \t Срок действия: {Time} \t Баланс: {Balance}       \t Кешбек: {CashBack}%");
        }
    }
}
