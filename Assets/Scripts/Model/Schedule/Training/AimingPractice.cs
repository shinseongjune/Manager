using System;

public class AimingPractice : Training
{
    public readonly int cost = 25000;
    public readonly Tuple<STAT, int>[] statModifier = {
        new Tuple<STAT, int>(STAT.DEXTERITY, 1)
    };
}
