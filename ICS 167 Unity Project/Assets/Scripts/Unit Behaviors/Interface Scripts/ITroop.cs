using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITroop
{
    // ITroop was worked on by Luis

    // Troop Stats
    public int getHP();
    public int getValue();
    // Target Choosing
    void selectTarget(); // Select entity (troop or resource)

    void interactTarget(); // Attacks enemy target or uses resource target

    void move(int x, int z); // Moves troop in int-based direction

}
