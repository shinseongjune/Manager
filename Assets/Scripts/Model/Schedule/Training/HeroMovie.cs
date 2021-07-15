using System;

public class HeroMovie : Training
{
    public readonly int cost = 25000;
    public readonly Tuple<STAT, int>[] statModifier = {
        new Tuple<STAT, int>(STAT.RESOLVE, 1)
    };
}
