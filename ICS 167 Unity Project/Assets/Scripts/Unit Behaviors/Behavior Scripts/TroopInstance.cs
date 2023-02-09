using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopInstance : MonoBehaviour, ITroop, ISelectable
{
    public int healthPoints { get; set; } // A troop's remaining healthpoints
    public int damageStat { get; set; } // How much damage a troop can do
    public int attackRange { get; set; }
    public int stepsPerMove { get; set; }
    public GameObject currentTarget;
    public bool isAlive { get; set; } // Is troop alive
    public bool isSelected { get; set; } // Is troop selected
    public int value { get; set; } // Gold cost of troop

    public int stepDistance = 10; // Each step that a troop needs to take in the Unity grid system is 10 units (in the x or z direction)

    public int getValue()
    {
        return value;
    }

    public void moveCheck() // Gets movement input and moves troop
    {
        if (Input.GetKeyDown("w"))
        {
            move(0, stepDistance);
        }
        if (Input.GetKeyDown("a"))
        {
            move(-stepDistance, 0);
        }
        if (Input.GetKeyDown("s"))
        {
            move(0, -stepDistance);
        }
        if (Input.GetKeyDown("d"))
        {
            move(stepDistance, 0);
        }
    }

    public void move(int x, int z)
    {
        Vector3 troopPosition = transform.position;
        troopPosition += new Vector3(x, 0, z);
        transform.position = troopPosition;
    }

    public void select()
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            troops[i].unselect();
        }
        currentTarget = null;
        isSelected = true; ;
    }

    public void checkClicked() // Detects if a troop is clicked on by the user
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == gameObject.transform)
                {
                    Debug.Log(gameObject.name + " was selected");
                    select();
                }
            }
        }
    }

    public void unselect()
    {
        if (isSelected == true) Debug.Log(gameObject + " was unselected");
        isSelected = false;
    }

    public void selectTarget()
    {
        if (Input.GetMouseButtonDown(1)) // Check if user right clicks on target
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<Player>().player != gameObject.GetComponent<Player>().player)
                {
                    currentTarget = hit.transform.gameObject;

                    Debug.Log("Enemy: " + currentTarget.name + " was selected");
                }
            }
        }
    }

    public void interactTarget()
    {
        if (currentTarget.tag == "Troop")
        {
            Debug.Log("Enemy " + currentTarget.name  + " HP is " + currentTarget.GetComponent<TroopInstance>().healthPoints);
            attackTarget();
        }
    }

    private void attackTarget()
    {
        TroopInstance enemy = currentTarget.GetComponent<TroopInstance>();

        enemy.healthPoints -= damageStat;
        Debug.Log("Enemy" + currentTarget.name + " HP after attack: " + enemy.healthPoints);
    }

    private void useTarget()
    {
        throw new System.NotImplementedException();
    }
}
