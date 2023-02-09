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
        troopCost = 80;
        attRange = 1;
        moveRange = 5;
    }

    // Update is called once per frame
    void Update()
    {
        checkClicked();
        if (isSelected) moveCheck();
    }

    private void moveCheck()
    {
        if (Input.GetKeyDown("w"))
        {
            move(0, movementSpeed);
        }
        if (Input.GetKeyDown("a"))
        {
            move(-movementSpeed, 0);
        }
        if (Input.GetKeyDown("s"))
        {
            move(0, -movementSpeed);
        }
        if (Input.GetKeyDown("d"))
        {
            move(movementSpeed, 0);
        }
    }

    private void checkClicked() // Detects if a troop is clicked on by the user
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == gameObject.transform)
                {
                    Debug.Log("Calvary was selected");
                    select();
                }
            }
        }
    }
}
