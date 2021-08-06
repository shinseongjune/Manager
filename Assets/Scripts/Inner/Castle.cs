using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : Construct, IDamagable
{
    //stats==================================================
    public override InnerStat AttackDamage => attackDamage = new InnerStat(0);
    public override InnerStat Armor => armor = new InnerStat(100);
    public override float HP => hp = 2500;
    public override InnerStat MaxHP => maxHP = new InnerStat(2500);
    public override float MP => mp = 0;
    public override InnerStat MaxMP => maxMP = new InnerStat(0);
    public override InnerStat FireResist => fireResist = new InnerStat(50);
    public override InnerStat WaterResist => waterResist = new InnerStat(50);
    public override InnerStat NatureResist => natureResist = new InnerStat(50);
    public override InnerStat AttackSpeed => attackSpeed = new InnerStat(0);
    public override InnerStat AttackRange => attackRange = new InnerStat(0);
    public override InnerStat HPRegen => hpRegen = new InnerStat(0);
    public override InnerStat MPRegen => mpRegen = new InnerStat(0);

    public override int Team => team;
    //========================================================

    // IDamagable=====================================
    public bool IsAlive => hp > 0;

    public void TakeDamage(int damage, GameObject hitEffect)
    {
        if (!IsAlive)
        {
            return;
        }

        hp -= damage;

        //TODO: �ǰ� ����Ʈ + �ǰ� ����� �ʿ���� ������ ����.
        //if (hitEffect)
        //{
        //    Instantiate<GameObject>(hitEffect, hitPoint);
        //}

        //if (IsAlive)
        //{
        //    animator?.SetTrigger(hitTriggerHash);
        //}
        //else
        //{
        //    animator?.SetBool(isAliveHash, false);
        //}
    }
    //===============================================
}
