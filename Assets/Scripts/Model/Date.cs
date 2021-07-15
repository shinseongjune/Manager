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
}
