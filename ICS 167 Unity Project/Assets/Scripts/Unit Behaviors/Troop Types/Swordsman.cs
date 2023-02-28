using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : TroopInstance
{
    void Awake()
    {
        // Troop Stats
        healthPoints = 10; // Swordsman HP
        damageStat = 5; // Swordsman attack damage
        attackRange = 1; // Swordsman attack range
        stepsLimit = 3; // Total moves allowed per turn
        value = 20;

        // Troop Conditions
        isAlive = true; // Swordsman is alive when first spawned
        isSelected = false; // Swordsman is not selected when first spawned
        currentTarget = null; // Swordsman has no target when first spawned

        // Highlight Child Objects
        targetedHighlight = gameObject.transform.GetChild(0).gameObject;
        selectedHighlight = gameObject.transform.GetChild(1).gameObject;
    }

    void Update()
    {
        if(!GameManager.isPaused)
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
