using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopInstance : MonoBehaviour, ITroop, ISelectable
{
    // Troop Stats
    protected int healthPoints; // A troop's remaining healthpoints
    protected int damageStat; // How much damage a troop can do
    protected int attackRange { get; set; }
    protected int value { get; set; } // Gold cost of troop
    protected int stepsLimit { get; set; } // How many times a troop can move
    protected int stepDistance = 10; // Each step that a troop needs to take in the Unity grid system is 10 units (in the x or z direction)

    // Troop Conditions
    protected GameObject currentTarget;
    public bool isAlive; // Is troop alive
    public bool isSelected { set; get; } // Is troop selected

    // Bounds variables will likely need to be changed in future builds to support different map sizes
    private float horizontalBounds = 110f; // Troops should not be able to move past this distance horizontally (negative or positive)
    private float VerticalBounds = 50f; // Troops should not be able to move past this distance vertically (negative or positive)

    // Highlight Child Objects
    [SerializeField] protected GameObject selectedHighlight;
    [SerializeField] protected GameObject targetedHighlight;

    public int getValue()
    {
        return value;
    }

    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }

    public int getHP()
    {
        return healthPoints;
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

    public void move(int x, int z) // Performs the move calculation and boundary check
    {
        Vector3 troopPosition = transform.position;
        troopPosition += new Vector3(x, 0, z);

        if (Mathf.Abs(troopPosition.x) < horizontalBounds && Mathf.Abs(troopPosition.z) < VerticalBounds) // Boundary Check
        {
            // Check if troop is occupying space
            bool tileBlocked = false;

            TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
            
            for (int i = 0; i < troops.Length; i++)
            {
                if (troops[i].transform.position.x == troopPosition.x && troops[i].transform.position.z == troopPosition.z)
                {
                    tileBlocked = true;
                }
            }

            if (tileBlocked == false) transform.position = troopPosition;
        }
        else Debug.Log("Boundaries checked and enforced");

        // Steps limit will be implemented when the turn system is implemented in future builds
    }

    public void select() // Selects troop and unselects all other troops
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            troops[i].unselect();
            troops[i].targetedHighlight.SetActive(false);
        }
        currentTarget = null;
        isSelected = true; ;
        targetedHighlight.SetActive(true);
    }

    public void checkClicked() // Detects if a troop is clicked on by the user and selects clicked troop (if any)
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == gameObject.transform)
                {
                    if(hit.transform.GetComponent<Player>().player != "Player 2") // NOTE!: This statement needs to change for future builds (currently only supports 1 player).
                    {
                        Debug.Log(gameObject.name + " was selected");
                        select();
                    }
                }
            }
        }
    }

    public void unselect() // Unselects troop
    {
        if (isSelected == true) Debug.Log(gameObject + " was unselected");
        isSelected = false;
    }

    public void selectTarget() // Selects target (enemy troop or resource)
    {
        if (Input.GetMouseButtonDown(1)) // Check if user right clicks on target
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.GetComponent<Player>().player != gameObject.GetComponent<Player>().player)
                {
                    if (currentTarget != null) currentTarget.GetComponent<TroopInstance>().targetedHighlight.SetActive(false); // Turn off previous target's highlight if new target is selected

                    currentTarget = hit.transform.gameObject; // Sets a troops current target
                    hit.transform.gameObject.GetComponent<TroopInstance>().targetedHighlight.SetActive(true); // Activates the targeted highlight for the target
                    Debug.Log("Enemy: " + currentTarget.name + " was selected");
                }
            }
        }
    }

    public void interactTarget() // Troop interacts with the target (attacks enemy or harvests resource)
    {
        if (currentTarget.tag == "Troop")
        {
            if ((currentTarget.transform.position.x <= gameObject.transform.position.x + (attackRange * stepDistance) && (currentTarget.transform.position.z <= gameObject.transform.position.z + (attackRange * stepDistance))))
            {
                Debug.Log("Enemy in range: " + currentTarget.name + " HP is " + currentTarget.GetComponent<TroopInstance>().healthPoints);
                attackTarget();
            }
            else Debug.Log("Enemy not in range: " + currentTarget.name + " HP is " + currentTarget.GetComponent<TroopInstance>().healthPoints);
        }
        else if (currentTarget.tag == "Resource")
        {
            useTarget();
        }
    }

    private void attackTarget() // Performs attack calculation
    {
        TroopInstance enemy = currentTarget.GetComponent<TroopInstance>();

        enemy.healthPoints -= damageStat;
        Debug.Log("Enemy" + currentTarget.name + " HP after attack: " + enemy.healthPoints);
    }

    private void useTarget() // Performs harvest calculation
    {
        throw new System.NotImplementedException();
    }
}
