using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    protected InnerCharacterManager innerCharacterManager = InnerCharacterManager.Instance;
    protected InnerStat attackDamage;
    protected InnerStat armor;
    protected float hp;
    protected InnerStat maxHP;
    protected float mp;
    protected InnerStat maxMP;
    protected InnerStat firePower;
    protected InnerStat waterPower;
    protected InnerStat naturePower;
    protected InnerStat fireResist;
    protected InnerStat waterResist;
    protected InnerStat natureResist;
    protected InnerStat movementSpeed;
    protected InnerStat attackSpeed;
    protected InnerStat attackRange;
    protected InnerStat cooldownReduction;
    protected InnerStat castingSpeed;
    protected InnerStat splashArea;
    protected InnerStat hpRegen;
    protected InnerStat mpRegen;
    protected InnerStat critChance;
    protected InnerStat critDamage;
    protected InnerStat sight;

    protected int team;

    public virtual InnerStat AttackDamage => attackDamage;
    public virtual InnerStat Armor => armor;
    public virtual float HP => hp;
    public virtual InnerStat MaxHP => maxHP;
    public virtual float MP => mp;
    public virtual InnerStat MaxMP => maxMP;
    public virtual InnerStat FirePower => firePower;
    public virtual InnerStat WaterPower => waterPower;
    public virtual InnerStat NaturePower => naturePower;
    public virtual InnerStat FireResist => fireResist;
    public virtual InnerStat WaterResist => waterResist;
    public virtual InnerStat NatureResist => natureResist;
    public virtual InnerStat MovementSpeed => movementSpeed;
    public virtual InnerStat AttackSpeed => attackSpeed;
    public virtual InnerStat AttackRange => attackRange;
    public virtual InnerStat CooldownReduction => cooldownReduction;
    public virtual InnerStat CastingSpeed => castingSpeed;
    public virtual InnerStat SplashArea => splashArea;
    public virtual InnerStat HPRegen => hpRegen;
    public virtual InnerStat MPRegen => mpRegen;
    public virtual InnerStat CritChance => critChance;
    public virtual InnerStat CritDamage => critDamage;
    public virtual InnerStat Sight => sight;
    
    public virtual int Team => team;
}
