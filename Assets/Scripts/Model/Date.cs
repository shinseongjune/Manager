public class Date
{
    public int year = 2021;
    public int month = 7;
    public int quarter = 1;

    public Date()
    {

    }

    public Date(int y, int m, int q)
    {
        year = y;
        month = m;
        quarter = q;
    }

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
        Date date1 = new Date(date.year, date.month, date.quarter);
        date1.quarter += i;
        if(date1.quarter > 4)
        {
            int m = 0;
            if(date1.quarter % 4 == 0)
            {
                m = date1.quarter / 4 - 1;
                date1.quarter = 4;
            }
            else
            {
                m = date1.quarter / 4;
                date1.quarter %= 4;
            }

            date1.month += m;
            if(m > 12)
            {
                int y = 0;
                if(date1.month % 12 == 0)
                {
                    y = date1.month / 12 - 1;
                    date1.month = 12;
                }
                else
                {
                    y = date1.month / 12;
                    date1.month %= 12;
                }
                date1.year += y;
            }
        }
        return date1;
    }

    public int CompareTo(Date date)
    {
        if (year.CompareTo(date.year) != 0)
        {
            return year.CompareTo(date.year);
        }
        else if (month.CompareTo(date.month) != 0)
        {
            return month.CompareTo(date.month);
        }
        else if (quarter.CompareTo(date.quarter) != 0)
        {
            return quarter.CompareTo(date.quarter);
        }
        else
        {
            return 0;
        }
    }
}
