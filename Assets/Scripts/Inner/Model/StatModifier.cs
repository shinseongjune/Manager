public class StatModifier
{
    public readonly float value;

    public readonly STAT_MODS type;

    public readonly int order;

    public readonly object source;

    public StatModifier(float value, STAT_MODS type, int order, object source)
    {
        this.value = value;
        this.type = type;
        this.order = order;
        this.source = source;
    }

    public StatModifier(float value, STAT_MODS type) : this(value, type, (int)type, null) { }

    public StatModifier(float value, STAT_MODS type, int order) : this(value, type, order, null) { }

    public StatModifier(float value, STAT_MODS type, object source) : this(value, type, (int)type, source) { }
}
