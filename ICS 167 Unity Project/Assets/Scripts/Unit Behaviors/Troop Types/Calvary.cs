using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calvary : TroopInstance
{
    // Start is called before the first frame update
    void Start()
    {
        // Troop Stats
        healthPoints = 15; // Cavalry HP
        damageStat = 4; // Cavalry attack damage
        attackRange = 1; // Cavalry attack range
        stepsLimit = 5; // Total allowed moves per turn

        // Troop Conditions
        isAlive = true; // Cavalry is alive when first spawned
        isSelected = false; // Cavalry is not selected when first spawned
        currentTarget = null; // Cavalry has no target when first spawned

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
