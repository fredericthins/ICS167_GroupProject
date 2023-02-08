using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopInstance : MonoBehaviour, ITroop, ISelectable
{
    public int healthPoints { get; set; } // A troop's remaining healthpoints
    public int damageStat { get; set; } // How much damage a troop can do
    public ISelectable currentTarget { get; set; } // Troop's current target
    public bool isAlive { get; set; } // Is troop alive
    public bool isSelected { get; set; } // Is troop selected
    public int value { get; set; } // Gold cost of troop

    public void attackTarget()
    {
        throw new System.NotImplementedException();
    }

    public int getValue(ISelectable selected_unit)
    {
        return value;
    }

    public void move(int x, int z)
    {
        Vector3 troopPosition = transform.position;
        troopPosition += new Vector3(x, 0, z);
        transform.position = troopPosition;
    }

    public void select()
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            troops[i].unselect();
        }

        isSelected = true; ;
    }

    public void unselect()
    {
        if (isSelected == true) Debug.Log(gameObject + " was unselected");
        isSelected = false;
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
