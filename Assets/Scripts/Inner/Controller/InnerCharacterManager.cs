using System;
using System.Collections;
using System.Collections.Generic;

public class InnerCharacterManager
{
    //singleton=========================================================
    private static readonly InnerCharacterManager instance = new InnerCharacterManager();

    static InnerCharacterManager()
    {

    }

    private InnerCharacterManager()
    {

    }

    public static InnerCharacterManager Instance
    {
        get
        {
            return instance;
        }
    }
    //===================================================================

    public void AddModifier(ref InnerStat innerStat, StatModifier mod)
    {
        innerStat.isDirty = true;
        innerStat.mods.Add(mod);
        innerStat.mods.Sort(CompareModifierOrder);
    }

    public bool RemoveModifier(ref InnerStat innerStat, StatModifier mod)
    {
        if (innerStat.mods.Remove(mod))
        {
            innerStat.isDirty = true;
            return true;
        }
        return false;
    }

    public float CalculateFinalValue(ref float baseValue, ref List<StatModifier> mods)
    {
        float finalValue = baseValue;
        float sumPercentAdd = 0;

        for (int i = 0; i < mods.Count; i++)
        {
            StatModifier mod = mods[i];

            switch (mod.type)
            {
                case STAT_MODS.PLAYER_STAT:
                    finalValue *= 1 + mod.value;
                    break;
                case STAT_MODS.FLAT:
                    finalValue += mod.value;
                    break;
                case STAT_MODS.MULA:
                    sumPercentAdd += mod.value;

                    if (i + 1 >= mods.Count || mods[i + 1].type != STAT_MODS.MULA)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                    break;
                case STAT_MODS.MULB:
                    sumPercentAdd += mod.value;

                    if (i + 1 >= mods.Count || mods[i + 1].type != STAT_MODS.MULB)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                    break;
                case STAT_MODS.MULC:
                    sumPercentAdd += mod.value;

                    if (i + 1 >= mods.Count || mods[i + 1].type != STAT_MODS.MULC)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                    break;
                case STAT_MODS.MULD:
                    sumPercentAdd += mod.value;

                    if (i + 1 >= mods.Count || mods[i + 1].type != STAT_MODS.MULD)
                    {
                        finalValue *= 1 + sumPercentAdd;
                        sumPercentAdd = 0;
                    }
                    break;
            }
        }

        return (float)Math.Round(finalValue, 4);
    }

    private int CompareModifierOrder(StatModifier a, StatModifier b)
    {
        if (a.order < b.order)
            return -1;
        else if (a.order > b.order)
            return 1;
        return 0;
    }

    //TODO: 특정 소스의 모든 수정치 제거 구현. 아마 캐릭터를 통과시켜야 할듯.
    //public bool RemoveAllModifiersFromSource(object source)
    //{
    //    bool didRemove = false;

    //    for (int i = statModifiers.Count - 1; i >= 0; i--)
    //    {
    //        if (statModifiers[i].Source == source)
    //        {
    //            isDirty = true;
    //            didRemove = true;
    //            statModifiers.RemoveAt(i);
    //        }
    //    }
    //    return didRemove;
    //}
}
