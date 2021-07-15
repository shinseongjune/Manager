using System;

public class StrategyStudy : Training
{
    public readonly int cost = 25000;
    public readonly Tuple<STAT, int>[] statModifier = {
        new Tuple<STAT, int>(STAT.INTELLECT, 1)
    };
}
