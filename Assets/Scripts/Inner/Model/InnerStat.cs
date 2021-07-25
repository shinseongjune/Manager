using System.Collections.Generic;

public class InnerStat
{
    public float baseValue;

    public bool isDirty;

    public readonly List<StatModifier> mods;

    public InnerStat(float value)
    {
        this.baseValue = value;
        mods = new List<StatModifier>();
    }
}
