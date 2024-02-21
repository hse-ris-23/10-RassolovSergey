﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork
{
    internal class Card
    {
        public static Random rnd = new Random(1000); // Вспомогательный
        private string id;      // ID владельца
        private string name;    // Имя владельца
        private string time;    // Срок действия

        // Свойства для id
        public string Id
        {
            get => id;
            set
            {
                if (value.Length != 19 || (!value.All(char.IsDigit) & (value[4] != ' ' || value[9] != ' ' || value[14] != ' '))) // Проверка на длину, наличие только цифр и пробелов
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
                if (value.Length > 30 || value.Length < 3)
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
            set
            {
                if (value.Length != 5 & (!char.IsDigit(value[0]) || !char.IsDigit(value[1])) & (value[2] != ' ') & ((int)(value[0]+value[1]) >= 1) & ((int)(value[0]+value[1]) <= 12)) // Проверка на длину, наличие только цифр и пробела
                {
                    throw new Exception("Неверный формат срока действия карты");
                }

                time = value;
            }
        }
        // Конструктор без параметра
        public Card()
        {
            Id = "0000 0000 0000 0000";
            Name = "User Name";
            Time = "01 28";
        }

        // Конструктор с параметром
        public Card(string id, string name, string time)
        {
            Id = id;
            Name = name;
            Time = time;
        }
        // Конструктор копирования
        public Card(Card card)
        {
            Id = card.Id;
            Name = card.name;
            Time = card.Time;
        }
        // Метод просмотра объектов класса
        public void Show()
        {
            Console.WriteLine($"ID: {Id} \t Имя: {Name} \t Срок действия: {Time}");
        }
        // Метод ввода информации об объектах класса с клавиатуры
        public Card Init()
        {
            Console.WriteLine("Введите ID (используя пробелы): ");
            Id = Console.ReadLine();

            Console.WriteLine("Введите Имя (от 3 до 30 символов): ");
            Name = Console.ReadLine();

            Console.WriteLine("Введите Срок действия (в формате MM YY): ");
            Time = Console.ReadLine();
            Card card = new Card(Id, Name, Time);
            return card;
        }
        // Метод формирования объектов класса с помощью ДСЧ
        public Card RandomInit()
        {
            // Создаем новый объект класса Card с случайными значениями
            Card card = new Card
            {
                Id = GenerateRandomId(),
                Name = GenerateRandomName(),
                Time = GenerateRandomTime()
            };
            return card;
        }

        // Вспомогательный метод для генерации случайного ID
        private string GenerateRandomId()
        {
            // Генерируем 19 случайных цифр и добавляем пробелы
            return string.Format("{0:D4} {1:D4} {2:D4} {3:D4}", rnd.Next(10000), rnd.Next(10000), rnd.Next(10000), rnd.Next(10000));
        }

        // Вспомогательный метод для генерации случайного имени
        private string GenerateRandomName()
        {
            // Пример генерации случайного имени
            string[] names = { "Ivan", "Maria", "John", "Anna", "Alex", "Olga" };
            return names[rnd.Next(names.Length)];
        }

        // Вспомогательный метод для генерации случайного срока действия
        private string GenerateRandomTime()
        {
            // Генерируем случайный месяц (от 01 до 12) и год (от 00 до 99)
            return string.Format("{0:D2} {1:D2}", rnd.Next(1, 13), rnd.Next(0, 100));
        }

    }
}

