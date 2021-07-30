using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    InnerCharacterManager innerCharacterManager = InnerCharacterManager.Instance;

    InnerStat attackDamage;
    InnerStat armor;

    InnerStat hp;
    InnerStat maxHP;

    InnerStat mp;
    InnerStat maxMP;

    InnerStat firePower;
    InnerStat waterPower;
    InnerStat naturePower;

    InnerStat fireResist;
    InnerStat waterResist;
    InnerStat natureResist;

    InnerStat movementSpeed;
    InnerStat attackSpeed;
    InnerStat attackRange;

    InnerStat cooldownReduction;
    InnerStat castingSpeed;
    InnerStat splashMag;

    InnerStat hpRegen;
    InnerStat mpRegen;

    InnerStat critChance;
    InnerStat critMag;

    InnerStat sight;

    public InnerStat AttackDamage => attackDamage;
    public InnerStat Armor => armor;

    public InnerStat HP => hp;
    public InnerStat MaxHP => maxHP;

    public InnerStat MP => mp;
    public InnerStat MaxMP => maxMP;

    public InnerStat FirePower => firePower;
    public InnerStat WaterPower => waterPower;
    public InnerStat NaturePower => naturePower;

    public InnerStat FireResist => fireResist;
    public InnerStat WaterResist => waterResist;
    public InnerStat NatureResist => natureResist;

    public InnerStat MovementSpeed => movementSpeed;
    public InnerStat AttackSpeed => attackSpeed;
    public InnerStat AttackRange => attackRange;

    public InnerStat CooldownReduction => cooldownReduction;
    public InnerStat CastingSpeed => castingSpeed;
    public InnerStat SplashMag => splashMag;

    public InnerStat HPRegen => hpRegen;
    public InnerStat MPRegen => mpRegen;

    public InnerStat CritChance => critChance;
    public InnerStat CritMag => critMag;

    public InnerStat Sight => sight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
