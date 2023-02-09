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
    public int troopCost { get; set; } // Gold cost of troop
    public int attRange { get; set; } // Attack range (based on tile units)
    public int moveRange { get; set; } // Movement range (based on tile units)

    public void attackTarget()
    {
        throw new System.NotImplementedException();
    }

    public int getValue(ISelectable selected_unit)
    {
        return troopCost;
    }

    //public void move(int x, int z)
    public void move(int x, int y)
    {
        //Vector3 troopPosition = transform.position;
        Vector2 troopPosition = transform.position;
        //troopPosition += new Vector3(x, 0, z);
        troopPosition += new Vector2(x, y);
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
