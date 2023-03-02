using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : TroopInstance
{
    void Start()
    {
        // Troop Stats
        healthPoints = 7; // Archer HP
        damageStat = 2; // Archer attack damage
        value = 55; // Archer gold cost
        attackRange = 6; // Archer attack range
        stepsLimit = 3; // Total allowed moves per turn

        // Troop Conditions
        isAlive = true; // Archer is alive when first spawned
        isSelected = false; // Archer is not selected when first spawned
        currentTarget = null; // Archer has no target when first spawned

        // Highlight Child Objects
        targetedHighlight = gameObject.transform.GetChild(0).gameObject;
        selectedHighlight = gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if (!GameManager.isPaused)
        {
            HPCheck();
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


}
