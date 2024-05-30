using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class IdNumber: IComparable
    {
        public int number;

        public IdNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Число не может быть меньше 0.");
            }
            this.number = number;
        }

        // Метод приведения к строке
        public override string ToString()
        {
            return number.ToString();
        }

        // Метод Equals
        public override bool Equals(object obj)
        {
            if (obj is IdNumber n)
            {
                return this.number == n.number;
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            IdNumber other = obj as IdNumber;
            if (other == null)
            {
                throw new ArgumentException("Объект не является типом IdNumber");
            }

            return this.number.CompareTo(other.number);
        }
    }
}