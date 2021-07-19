using System.Collections.Generic;

public class DateComparer : IComparer<Date>
{
    public int Compare(Date x, Date y)
    {
        if (x.year.CompareTo(y.year) != 0)
        {
            return x.year.CompareTo(y.year);
        }
        else if (x.month.CompareTo(y.month) != 0)
        {
            return x.month.CompareTo(y.month);
        }
        else if (x.quarter.CompareTo(y.quarter) != 0)
        {
            return x.quarter.CompareTo(y.quarter);
        }
        else
        {
            return 0;
        }
    }
}