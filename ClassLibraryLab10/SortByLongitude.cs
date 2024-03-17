using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryLab10
{
    public class SortByLongitude: IComparer
    {
        public int Compare(object x, object y)
        {
            GeoCoordinates loc1 = x as GeoCoordinates;
            GeoCoordinates loc2 = y as GeoCoordinates;

            if (loc1.Longitude < loc2.Longitude) { return -1; }
            else if (loc1.Longitude > loc2.Longitude) { return 1; }
            else { return 0; }
        }
    }
}
