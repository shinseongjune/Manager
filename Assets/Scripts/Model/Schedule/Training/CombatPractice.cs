using System;

public class CombatPractice : Training
{
    public readonly int cost = 25000;
    public readonly Tuple<STAT, int>[] statModifier = {
        new Tuple<STAT, int>(STAT.AGGRESSION, 3)
    };
}
