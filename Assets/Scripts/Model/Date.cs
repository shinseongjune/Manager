public class Date
{
    public int year = 2021;
    public int month = 7;
    public int quarter = 1;

    public static Date operator ++(Date date)
    {
        date.quarter++;
        if(date.quarter > 4)
        {
            date.quarter = 1;
            date.month++;
        }
        if(date.month > 12)
        {
            date.month = 1;
            date.year++;
        }
        return date;
    }

    public static bool operator ==(Date date1, Date date2)
    {
        if (date1.year == date2.year && date1.month == date2.month && date1.quarter == date2.quarter) return true;
        return false;
    }

    public static bool operator !=(Date date1, Date date2)
    {
        if (date1 == date2) return false;
        return true;
    }

    public override bool Equals(object o)
    {
        if (o == null)
            return false;

        var second = o as Date;

        return second != null && year == second.year && month == second.month && quarter == second.quarter;
    }

    public override int GetHashCode()
    {
        return int.Parse((year.ToString() + month + quarter));
    }

    public static Date operator +(Date date, int i)
    {
        date.quarter += i;
        if(i > 4)
        {
            int m = 0;
            if(date.quarter % 4 == 0)
            {
                m = date.quarter / 4 - 1;
                date.quarter = 4;
            }
            else
            {
                m = date.quarter / 4;
                date.quarter %= 4;
            }
            date.month += m;
            if(m > 12)
            {
                int y = 0;
                if(date.month % 12 == 0)
                {
                    y = date.month / 12 - 1;
                    date.month = 12;
                }
                else
                {
                    y = date.month / 12;
                    date.month %= 12;
                }
                date.year += y;
            }
        }
        return date;
    }
}
