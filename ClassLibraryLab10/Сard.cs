using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class Card : IInit, IComparable, ICloneable, IEnumerable<Card>
    {
        public static int CardCount = 0;
        public IdNumber num;
        public static Random rnd = new Random(1000);// Вспомогательный
        private string id;                          // ID владельца
        private string name;                        // Имя владельца
        private string time;                        // Срок действия



        // Свойства для id
        public string Id
        {
            get => id;
            set
            {
                if (value == null || value.Length != 19 || (!value.All(char.IsDigit) & (value[4] != ' ' || value[9] != ' ' || value[14] != ' '))) // Проверка на длину, наличие только цифр и пробелов
                {
                    throw new Exception("Неверный формат id!");
                }

                id = value;
            }
        }

        // Свойства для name
        public string Name
        {
            get => name;
            set
            {
                if (value == null || value.Length > 30 || value.Length < 3)
                {
                    throw new Exception("Невозможная длина имени");
                }

                name = value;
            }
        }

        // Свойства для Срока действия
        public string Time
        {
            get => time;
            set    // Проверка:     
            {      // на пустоту     -----на длинну-----   -------------на то что месяц это число------------  -на наличие "/"-     -------------на то что год это число------------
                if (value == null || value.Length != 5 || !char.IsDigit(value[0]) || !char.IsDigit(value[1]) || value[2] != '/' || !char.IsDigit(value[3]) || !char.IsDigit(value[4])) // Проверка на длину, наличие только цифр и пробела
                {
                    throw new Exception("Неверный формат срока действия карты");
                }

                int month = int.Parse(value.Substring(0, 2));
                int year = int.Parse(value.Substring(3, 2));

                if (month < 1 || month > 12 || year < 0 || year > 99)
                {
                    throw new Exception("Неверный формат срока действия карты");
                }

                time = value;
            }
        }

        public int Key => throw new NotImplementedException();

        // Конструктор без параметра
        public Card()
        {
            Id = "0000 0000 0000 0000";
            Name = "User Name";
            Time = "01/28";
            num = new IdNumber(1);
            CardCount++;
        }

        // Конструктор с параметром
        public Card(string id, string name, string time, int number)
        {
            Id = id;
            Name = name;
            Time = time;
            num = new IdNumber(number);
            CardCount++;
        }

        // Конструктор копирования
        public Card(Card mCard)
        {
            Card copyCard = (Card)mCard.MemberwiseClone();  // Копирование полей с помощью метода MemberwiseClone()
            CardCount++;                                    // Увеличение счетчика карточек
        }


        // Метод глубокого копирования
        public object Clone()
        {
            CardCount++;
            return new Card(Id, Name, Time, num.number);
        }

        // Метод поверхностного копирования
        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        // Метод просмотра объектов класса (Виртуальный)
        public virtual void Show()
        {
            Console.Write($"ID: {Id} \t Имя: {Name} \t Срок действия: {Time} \t Номер: {num}");
        }


        // Метод просмотра объектов класса (НЕ Виртуальный)
        public void Print()
        {
            Console.Write($"ID: {Id} \t Имя: {Name} \t Срок действия: {Time} \t Номер: {num}");
        }

        // Преобразование в строку
        public override string ToString()
        {
            return $"{id} | {Name} | {Time} | {num}";
        }

        // Реализация метода Init интерфейса IInit
        public virtual void Init()
        {
            Console.WriteLine("Введите ID (используя пробелы): ");
            Id = Console.ReadLine();

            Console.WriteLine("Введите Имя (от 3 до 30 символов): ");
            Name = Console.ReadLine();

            Console.WriteLine("Введите Срок действия (в формате MM YY): ");
            Time = Console.ReadLine();

            num.number = (int)InputHelper.InputUintNumber("Введите номер объекта:");
        }


        // Реализация метода RandomInit интерфейса IInit
        public virtual void RandomInit()
        {
            Id = GenerateRandomId();
            Name = GenerateRandomName();
            Time = GenerateRandomTime();
            num.number = rnd.Next(1, 1000);
        }


        // Вспомогательный метод для генерации случайного ID
        public string GenerateRandomId()
        {
            // Генерируем 16 случайных цифр и добавляем пробелы
            return string.Format("{0:D4} {1:D4} {2:D4} {3:D4}", rnd.Next(10000), rnd.Next(10000), rnd.Next(10000), rnd.Next(10000));
        }
    
        // Вспомогательный метод для генерации случайного имени
        public string GenerateRandomName()
        {
            // Пример генерации случайного имени
            string[] names = { "Ivan", "Maria", "John", "Anna", "Alex", "Olga" };
            return names[rnd.Next(names.Length)];
        }

        // Вспомогательный метод для генерации случайного срока действия
        public string GenerateRandomTime()
        {
            // Генерируем случайный месяц (от 01 до 12) и год (от 00 до 99)
            return string.Format("{0:D2}/{1:D2}", rnd.Next(1, 13), rnd.Next(20, 35));
        }

        public override bool Equals(object obj)
        {
            // Проверяем, является ли переданный объект null или не является объектом класса Card
            if (obj == null) return false;
            if (!(obj is Card)) return false;

            // Приводим объект к типу Card
            Card other = (Card)obj;

            // Сравниваем значения широты текущего объекта с другим объектом GeoCoordinates
            return this.Id == other.Id && this.Name == other.Name && this.Time == other.Time;
        }


        public int CompareTo(object obj)
        {
            if (obj == null) { return -1; }
            if (!(obj is  Card)) { return -1; }
            Card card = obj as Card;
            return String.Compare(this.id, card.Id);
        }

        // Метод - GetHashCode
        public override int GetHashCode()
        {
            return Id.GetHashCode(); // Возвращаем хеш-код по уникальному идентификатору
        }

        // Метод для получения количества созданных объектов
        public static int GetObjectCount()
        {
            return CardCount;
        }

        // Реализация метода GetEnumerator()
        public IEnumerator<Card> GetEnumerator()
        {
            yield return this;
        }

        // Реализация метода GetEnumerator() интерфейса IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}