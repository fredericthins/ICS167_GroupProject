using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calvary : TroopInstance
{
    int movementSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 15;
        damageStat = 4;
        isAlive = true;
        isSelected = false;
        value = 80;
        attackRange = 1;
        stepsPerMove = 5;
    }

    // Update is called once per frame
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
