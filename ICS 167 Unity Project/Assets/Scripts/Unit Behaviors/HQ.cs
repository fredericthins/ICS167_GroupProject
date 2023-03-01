using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : TroopInstance
{
    void Awake()
    {
        // HQ Stats
        healthPoints = 30; // Swordsman HP
        stepsLimit = 0;

        // Troop Conditions
        isAlive = true; // Swordsman is alive when first spawned
        isSelected = false; // Swordsman is not selected when first spawned
    }

    // Update is called once per frame
    void Update()
    {

    }
}
