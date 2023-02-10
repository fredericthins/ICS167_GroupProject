using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : TroopInstance
{
    // Start is called before the first frame update
    void Start()
    {
        // Troop Stats
        healthPoints = 7; // Spearman HP
        damageStat = 3; // Spearman attack damage
        value = 40; // Spearman gold cost
        attackRange = 2; // Spearman attack range
        stepsLimit = 3; // Total allowed moves per turn

        // Troop Conditions
        isAlive = true; // Spearman is alive when first spawned
        isSelected = false; // Spearman is not selected when first spawned
        currentTarget = null; // Spearman has no target when first spawned
    }

    void Update()
    {
        checkClicked(); // If the troop is clicked then isSelected becomes true
        if (isSelected)
        {
            moveCheck(); // If a troop is selected, then it can move if the user inputs a movement key (WASD)
            selectTarget(); // Checks if the user right clicks an enemy

            if (currentTarget != null && Input.GetKeyDown("space"))
            {
                //Debug.Log("space key was pressed");
                interactTarget();
            }
        }
    }
}
