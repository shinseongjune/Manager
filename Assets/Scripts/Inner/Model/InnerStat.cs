using System.Collections.Generic;

public class InnerStat
{
    public float baseValue;

    public float _value;

    public bool isDirty;

    public List<StatModifier> mods;

    private float lastBaseValue;

    public InnerStat(float value)
    {
        this.baseValue = value;
        this._value = value;
        lastBaseValue = value;
        mods = new List<StatModifier>();
    }

    public float Value
    {
        get
        {
            if (isDirty || lastBaseValue != baseValue)
            {
                lastBaseValue = baseValue;
                _value = InnerCharacterManager.Instance.CalculateFinalValue(ref baseValue, ref mods);
                isDirty = false;
            }
            return _value;
        }
    }
}
