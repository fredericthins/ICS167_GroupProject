using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HQ : TroopInstance
{
    void Awake()
    {
        // HQ Stats
        healthPoints = 30; // HQ HP
        stepsLimit = 0;

        // Troop Conditions
        isAlive = true; // HQ is alive when first spawned
        isSelected = false; // HQ is not selected
        currentTarget = null; // HQ has no target
    }

    // Update is called once per frame
    void Update()
    {

    }
}
