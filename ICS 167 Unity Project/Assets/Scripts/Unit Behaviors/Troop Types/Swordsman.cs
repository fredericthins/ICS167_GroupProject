using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swordsman : TroopInstance
{
    void Start()
    {
        healthPoints = 10;
        damageStat = 5;
        isAlive = true;
        isSelected = false;
        currentTarget = null;
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
