using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class GeoCoordinates : IInit, IComparable
    {
        public static int objectCount = 0;


        // GeoCoordinates
        private double latitude;  // Широта
        private double longitude; // Долгота
        private static readonly Random rnd = new Random(); // Объект Random, созданный вне конструктора
        private const double earthRadius = 6371;  // Радиус Земли в (км)

        // Конструктор без параметров
        public GeoCoordinates() { latitude = 0.01; longitude = 0.01; objectCount++; }


        // Конструктор с параметром (Конструктор с параметрами, использующий свойства для инициализации полей)
        public GeoCoordinates(double lat, double lon) { latitude = lat; longitude = lon; objectCount++; }


        // Конструктор с параметрами, заполняющий элементы случайными значениями
        public GeoCoordinates(Random rnd)
        {
            latitude = rnd.NextDouble() * (90 - (-90)) + (-90);     // Генерация случайной широты в диапазоне [-90, 90)
            longitude = rnd.NextDouble() * (180 - (-180)) + (-180); // Генерация случайной долготы в диапазоне [-180, 180)
        }

        // Конструктор копирования
        public GeoCoordinates(GeoCoordinates loc)
        {
            Latitude = loc.Latitude;
            Longitude = loc.Longitude;
            objectCount++;
        }


        // Функция ввода широты
        public double Latitude
        {
            get => latitude;
            set
            {
                if (value < -90 || value > 90) // Проверка Диапозона широты
                {
                    throw new Exception("Ошибка: Недопустимое значения Широты!");
                }
                else
                {
                    latitude = value;
                }
            }
        }


        // Функция ввода Долготы
        public double Longitude
        {
            get => longitude;
            set
            {
                if (value < -180 || value > 180) // Проверка Диапозона широты
                {
                    throw new Exception("Ошибка: Недопустимое значения Долготы!");
                }
                else
                {
                    longitude = value;
                }
            }
        }

        // Метод просмотра объекта класса (Виртуальный)
        public virtual void Show()
        {
            Console.WriteLine($"Широта: {Latitude}, Долгота: {Longitude}");
        }

        // Метод просмотра объекта класса (Не виртуальный)
        public void Print()
        {
            Console.WriteLine($"Широта: {Latitude}, Долгота: {Longitude}");
        }


        // Метод позволяющий задать координыты вручную
        public GeoCoordinates CreateFromUserInput()
        {
            GeoCoordinates loc = new GeoCoordinates(); // Создаем новый объект локации
            
            Console.Write("Введите значение широты: "); // Запрашиваем у пользователя ввод широты

            // Проверка на корректность введенных данных
            while (!double.TryParse(Console.ReadLine(), out latitude) || latitude < -90 || latitude > 90)
            {
                throw new Exception("Ошибка: Введите корректное значение широты (-90 до 90): ");
            }

            Console.Write("Введите значение долготы: "); // Запрашиваем у пользователя ввод долготы

            // Проверка на корректность введенных данных
            while (!double.TryParse(Console.ReadLine(), out longitude) || longitude < -180 || longitude > 180)
            {
                throw new Exception("Ошибка: Введите корректное значение долготы (-180 до 180): ");
            }
            return loc;
        }


        // Метод для получения количества созданных объектов
        public static int GetObjectCount()
        {
            return objectCount;
        }

        // Поиск растояния (Static)
        public static double DistanceSt(GeoCoordinates Location1, GeoCoordinates Location2)
        {
            // Переводим значения широты и долготы из градусов в радианы
            double lat1 = DegreesToRadiansSt(Location1.latitude);
            double lon1 = DegreesToRadiansSt(Location1.longitude);
            double lat2 = DegreesToRadiansSt(Location2.latitude);
            double lon2 = DegreesToRadiansSt(Location2.longitude);

            // Вычисляем разницу между широтами и долготами
            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;

            // Вычисляем расстояние с помощью формулы Гаверсинуса
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;

            return distance;
        }

        // Преообразование в меридианы (Static)
        public static double DegreesToRadiansSt(double degrees)
        {
            return degrees * Math.PI / 180;
        }


        // Поиск растояния (Метод класса)
        public double Distance(GeoCoordinates location)
        {
            // Переводим значения широты и долготы из градусов в радианы
            double lat1 = DegreesToRadians(latitude);
            double lon1 = DegreesToRadians(longitude);
            double lat2 = DegreesToRadians(location.latitude);
            double lon2 = DegreesToRadians(location.longitude);

            // Вычисляем разницу между широтами и долготами
            double deltaLat = lat2 - lat1;
            double deltaLon = lon2 - lon1;

            // Вычисляем расстояние с помощью формулы Гаверсинуса
            double a = Math.Sin(deltaLat / 2) * Math.Sin(deltaLat / 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Sin(deltaLon / 2) * Math.Sin(deltaLon / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadius * c;

            return distance;
        }

        // Преобразование в меридианы (Метод класса)
        public double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }



        // Унарные операторы (++)
        public static GeoCoordinates operator ++(GeoCoordinates loc)
        {
            return new GeoCoordinates(loc.Latitude += 0.01, loc.Longitude += 0.01);
        }

        // Унарные операторы (-)
        public static GeoCoordinates operator -(GeoCoordinates loc)
        {
            return new GeoCoordinates(-loc.Latitude, -loc.Longitude);
        }



        // Операции приведения типа bool (явная)
        // explicit - явное преобразование
        public static explicit operator bool(GeoCoordinates loc)
        {
            // Проверяем, находится ли точка на экваторе
            return loc.Latitude == 0;
        }

        // Операции приведения типа string (неявная)
        // implicit - не явное преобразование
        public static implicit operator string(GeoCoordinates loc)
        {
            if (loc.Longitude > 0) { return "Восточная долгота"; }
            if (loc.Longitude < 0) { return "Западная долгота"; }
            else return "Нулевой меридиан";
        }



        // Проверяем, находятся ли обе точки на одной параллели (имеют одинаковую широту)
        public static bool operator ==(GeoCoordinates loc1, GeoCoordinates loc2)
        {
            return loc1.Latitude == loc2.Latitude;
        }

        // Проверка на различность меридиан
        public static bool operator !=(GeoCoordinates loc1, GeoCoordinates loc2)
        {
            return !(loc1.Longitude == loc2.Longitude);
        }



        // Реализация метода Init интерфейса IInit
        public virtual void Init()
        {
            Latitude = (int)InputHelper.InputUintNumber("Введите значение Широты: ");   // Заполнение Широты
            Longitude = (int)InputHelper.InputUintNumber("Введите значение Долготы: "); // Заполнение Долготы
        }

        // Реализация метода RandomInit интерфейса IInit
        public virtual void RandomInit()
        {
            Latitude = rnd.NextDouble() * (90 - (-90)) + (-90);     // Генерация случайной широты в диапазоне [-90, 90)
            Longitude = rnd.NextDouble() * (180 - (-180)) + (-180); // Генерация случайной долготы в диапазоне [-180, 180)
        }



        public override bool Equals(object obj)
        {
            // Проверяем, является ли переданный объект null или не является объектом класса GeoCoordinates
            if (obj == null) return false;
            if (!(obj is GeoCoordinates)) return false;

            // Приводим объект к типу GeoCoordinates
            GeoCoordinates other = (GeoCoordinates)obj;

            // Сравниваем значения широты текущего объекта с другим объектом GeoCoordinates
            return this.Latitude == other.Latitude && this.Longitude == other.Longitude;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) { return -1; }
            if (!(obj is  GeoCoordinates)) { return -1; }
            GeoCoordinates loc = obj as GeoCoordinates;
            if (this.Latitude > loc.Latitude) { return 1; }

            else if (this.Latitude < loc.Latitude) { return -1; }

            else { return 0; }
        }
    }
}