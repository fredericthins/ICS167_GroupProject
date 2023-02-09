using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spearman : TroopInstance
{
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = 7;
        damageStat = 3;
        isAlive = true;
        isSelected = false;
        value = 40;
        attackRange = 2;
        stepsLimit = 3;
        currentTarget = null;
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
