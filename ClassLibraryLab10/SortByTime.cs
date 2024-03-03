using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class SortByTime : IComparer
    {
        public int Compare(object x, object y)
        {
            Card card1 = x as Card;
            Card card2 = y as Card;
            int month1 = int.Parse(card1.Time.Substring(0, 2));         // Месяц 1 карты
            int year1 = int.Parse(card1.Time.Substring(3, 2)) + 2000;   // Год 1 карты
            int month2 = int.Parse(card2.Time.Substring(0, 2));         // Месяц 2 карты
            int year2 = int.Parse(card2.Time.Substring(3, 2)) + 2000;   // Год 2 карты

            // Сравнение сроков карт
            if (year1 < year2) { return -1; }
            else if (year1 > year2) { return 1; }
            else
            {
                if (month1 < month2) { return -1; }
                if (month1 > month2) { return 1; }
                else { return 0; }
            }
        }
    }
}
