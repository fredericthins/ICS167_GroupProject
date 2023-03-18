using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ooze : TroopInstance
{
    // Start is called before the first frame update
    void Start()
    {
        // Troop Stats
        healthPoints = 10; // Monster HP
        damageStat = 7; // Monster attack damage
        attackRange = 1; // Monster attack range
        stepsLimit = 3; // Total allowed moves per turn

        // Troop Conditions
        isAlive = true; // Monster is alive when first spawned
        isSelected = false; // Monster is not selected when first spawned
        currentTarget = null; // Monster has no target when first spawned
    }

    // Update is called once per frame
    void Update()
    {
        HPCheck();
    }
}
