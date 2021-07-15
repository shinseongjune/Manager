using System;

public class Exercise : Training
{
    public readonly int cost = 25000;
    public readonly Tuple<STAT, int>[] statModifier = { 
        new Tuple<STAT, int>(STAT.STAMINA, 1)
    };
}
