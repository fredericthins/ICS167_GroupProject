using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITroop : ISelectable
{
    // Troop Stats
    int healthPoints {get; set;}
    int damageStat {get; set;}

    // Target Choosing
    ISelectable currentTarget {get; set;}

    void selectTarget(ISelectable currentTarget);

    void attackTarget(); // Attacks the selected target

    void useTarget(); // Uses the target (harvests animals/crop/ other resource). Might need to change this method depdending on implementation.

    void move(int x, int y); // Moves troop in int-based direction (Probably needs to be changed when tile map is developed)

}
