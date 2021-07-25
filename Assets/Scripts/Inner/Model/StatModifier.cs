public class StatModifier
{
    public readonly float value;

    public readonly STAT_MODS stat_mod;

    public StatModifier(float value, STAT_MODS stat_mod)
    {
        this.value = value;
        this.stat_mod = stat_mod;
    }
}
