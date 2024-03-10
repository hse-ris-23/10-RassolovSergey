using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab9
{
    public class GeoCoordinatesArray : GeoCoordinates, IInit9
    {
        // Вспомогательная функция Проверка ввода числа (Uint)
        static int coutObj = 0;
        private GeoCoordinates[] coordinatesArray;

        // Конструктор без параметров
        public GeoCoordinatesArray()
        {
            coordinatesArray = new GeoCoordinates[0];
            coutObj++;
        }
        // Конструктор с параметрами, принимающий массив GeoCoordinates (Заполнение ДСЧ)
        public GeoCoordinatesArray(int count, Random rnd)
        {
            if (count <= 0)
            {
                throw new ArgumentException("Количество элементов должно быть больше нуля.");
            }
            coordinatesArray = new GeoCoordinates[count];
            for (int i = 0; i < count; i++)
            {
                double latitude = rnd.NextDouble() * (90 - (-90)) + (-90);     // Генерация случайной широты в диапазоне [-90, 90)
                double longitude = rnd.NextDouble() * (180 - (-180)) + (-180); // Генерация случайной долготы в диапазоне [-180, 180)
                coordinatesArray[i] = new GeoCoordinates(latitude, longitude);
            }
            coutObj++;
        }

        // Конструктор глубокого копирования
        public GeoCoordinatesArray(GeoCoordinatesArray other)
        {
            this.coordinatesArray = new GeoCoordinates[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                this.coordinatesArray[i] = new GeoCoordinates(other.coordinatesArray[i]);
            }
            coutObj++;
        }

        // Длинна
        public int Length
        {
            get => coordinatesArray.Length;
        }

        // Конструктор с параметрами, заполняющий массив элементами
        public GeoCoordinatesArray(uint count)
        {
            coordinatesArray = new GeoCoordinates[count];

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Введите координаты для {i + 1} локации:");
                coordinatesArray[i] = new GeoCoordinates();
                bool flagLat = false;
                bool flagLon = false;
                while (flagLat != true)
                {
                    if (coordinatesArray[i].Latitude == 0.01) { coordinatesArray[i].Latitude = InputDoubleNumber("Широта: "); }
                    else flagLat = true;
                }
                while (flagLon != true)
                {
                    if (coordinatesArray[i].Longitude == 0.01) { coordinatesArray[i].Longitude = InputDoubleNumber("Долгота: "); }
                    else flagLon = true;
                }
            }
            coutObj++;
        }

        // Метод для просмотра элементов массива
        public new void Show()
        {
            if (Length <= 0)
            {
                throw new Exception("Массив пуст!");
            }
            foreach (GeoCoordinates coord in coordinatesArray)
            {
                Console.WriteLine($"Долгота: {coord.Latitude}, Широта: {coord.Longitude}");
            }
        }

        // Вспомогательный метод для ввода числа с клавиатуры
        private double InputDoubleNumber(string prompt)
        {
            double number;
            Console.Write(prompt);
            while (!double.TryParse(Console.ReadLine(), out number))
            {
                Console.WriteLine("Ошибка: Введите корректное число.");
                Console.Write(prompt);
            }
            return number;
        }
        // Индексатор для доступа к элементам коллекции
        public GeoCoordinates this[int index]
        {
            get
            {
                // Проверяем, не выходит ли индекс за пределы массива
                if (index < 0 || index >= coordinatesArray.Length)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений.");
                }
                return coordinatesArray[index];
            }
            set
            {
                // Проверяем, не выходит ли индекс за пределы массива
                if (index < 0 || index >= coordinatesArray.Length)
                {
                    throw new IndexOutOfRangeException("Индекс находится вне диапазона допустимых значений.");
                }
                coordinatesArray[index] = value;
            }
        }
        // Метод для получения количества созданных объектов
        public static new int GetObjectCount()
        {
            return coutObj;
        }


        // Поиск локации ближайшей к "Острову ноль"
        public void FindNearestToZeroIslandIndex()
        {
            if (coordinatesArray.Length == 0)
            {
                throw new InvalidOperationException("Массив пуст!");
            }

            double minDistance = double.MaxValue;
            int nearestIndex = 0;

            // Координаты "Острова Ноль"
            double zeroLatitude = 0;
            double zeroLongitude = 0;

            for (int i = 0; i < coordinatesArray.Length; i++)
            {
                // Вычисляем расстояние между текущей точкой и "Островом Ноль"
                double distance = coordinatesArray[i].Distance(new GeoCoordinates(zeroLatitude, zeroLongitude));

                // Если найдено более близкое расстояние, обновляем переменные
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestIndex = i;
                }
            }
            Console.WriteLine(nearestIndex);
        }

        // Заполение вручную
        public virtual new void Init()
        {
            int count = (int)InputUintNumber("Введите желаемую длину массива: "); // Считываем длинну масива
            GeoCoordinatesArray geoArr = new GeoCoordinatesArray(1);
            for (int i = 0; i < count; i++)
            {
                GeoCoordinates locRnd = new GeoCoordinates();
                geoArr[i] = locRnd;
            }
        }

        // Метод генерации рандомных значений
        public virtual void RandomInit(Random rnd)
        {
            if (Length <= 0)
            {
                throw new ArgumentException("Количество элементов должно быть больше нуля.");
            }
            coordinatesArray = new GeoCoordinates[Length];
            for (int i = 0; i < Length; i++)
            {
                double latitude = rnd.NextDouble() * (90 - (-90)) + (-90);     // Генерация случайной широты в диапазоне [-90, 90)
                double longitude = rnd.NextDouble() * (180 - (-180)) + (-180); // Генерация случайной долготы в диапазоне [-180, 180)
                coordinatesArray[i] = new GeoCoordinates(latitude, longitude);
            }
            coutObj++;
        }

        public override int GetHashCode()
        {
            int hashCode = 17; // Начальное значение хеш-кода

            // Комбинируем хеш-коды элементов массива
            foreach (GeoCoordinatesArray coord in coordinatesArray)
            {
                hashCode = hashCode * 31 + coord.GetHashCode();
            }

            return hashCode;
        }

    }
}