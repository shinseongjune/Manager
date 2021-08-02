using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construct : Unit
{
    public override InnerStat AttackDamage => attackDamage;
    public override InnerStat Armor => armor;
    public override float HP => hp;
    public override InnerStat MaxHP => maxHP;
    public override float MP => mp;
    public override InnerStat MaxMP => maxMP;
    public override InnerStat FirePower => firePower = new InnerStat(0);
    public override InnerStat WaterPower => waterPower = new InnerStat(0);
    public override InnerStat NaturePower => naturePower = new InnerStat(0);
    public override InnerStat FireResist => fireResist;
    public override InnerStat WaterResist => waterResist;
    public override InnerStat NatureResist => natureResist;
    public override InnerStat MovementSpeed => movementSpeed = new InnerStat(0);
    public override InnerStat AttackSpeed => attackSpeed;
    public override InnerStat AttackRange => attackRange;
    public override InnerStat CooldownReduction => cooldownReduction = new InnerStat(0);
    public override InnerStat CastingSpeed => castingSpeed = new InnerStat(0);
    public override InnerStat SplashArea => splashArea = new InnerStat(0);
    public override InnerStat HPRegen => hpRegen;
    public override InnerStat MPRegen => mpRegen;
    public override InnerStat CritChance => critChance = new InnerStat(0);
    public override InnerStat CritDamage => critDamage = new InnerStat(0);
    public override InnerStat Sight => sight;

    public override int Team => team;


}
