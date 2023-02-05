using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopInstance : MonoBehaviour, ITroop
{
    public int healthPoints { get; set; }
    public int damageStat { get; set; }
    public ISelectable currentTarget { get; set; }
    public bool isAlive { get; set; }
    public bool isSelected { get; set; }


    private void Initialize(int hp, int damage) // Initialize will be useful if we use a Scriptable Object for troop types
    {
        healthPoints = hp;
        damageStat = damage;
        isAlive = true;
    }


    public void attackTarget()
    {
        throw new System.NotImplementedException();
    }

    public int getValue(ISelectable selected_unit)
    {
        throw new System.NotImplementedException();
    }

    public void move(int x, int y)
    {
        throw new System.NotImplementedException();
    }

    public void select(ISelectable selected_unit)
    {
        throw new System.NotImplementedException();
    }

    public void selectTarget(ISelectable current_target)
    {
        throw new System.NotImplementedException();
    }

    public void useTarget()
    {
        throw new System.NotImplementedException();
    }
}
