using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopInstance : MonoBehaviour, ITroop, ISelectable
{
    // TroopInstance was updated by Luis, Frederic, and Dale
    // All objects that inherit from TroopInstance were worked on by all members of the group

    // HQ Stats
    private bool isHQ;

    // Troop Stats
    [SerializeField] protected Player owner;
    protected int healthPoints; // A troop's remaining healthpoints
    protected int damageStat; // How much damage a troop can do
    [SerializeField] protected int value;
    protected int attackRange { get; set; }
    protected bool attackSpent = false;
    protected int stepsLimit { get; set; } // How many times a troop can move
    protected int stepsTaken = 0;
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

    public void setOwner(Player player)
    {
        owner = player;
    }

    public Player getOwner()
    {
        return owner;
    }

    public void HPCheck()
    {
        if (healthPoints <= 0) Destroy(gameObject);
    }

    public GameObject getCurrentTarget()
    {
        return currentTarget;
    }

    public int getHP()
    {
        return healthPoints;
    }

    public int getValue()
    {
        return value;
    }

    public int getATT()
    {
        return damageStat;
    }

    public int getRange()
    {
        return attackRange;
    }

    public int getMove()
    {
        return stepsLimit;
    }

    public int getCost()
    {
        return value;
    }

    public int getStepDistance()
    {
        return stepDistance;
    }

    public int getStepsTaken()
    {
        return stepsTaken;
    }

    public int getStepsLimit()
    {
        return stepsLimit;
    }

    public bool getAttackSpent()
    {
        return attackSpent;
    }

    public void moveCheck() // Gets movement input and moves troop
    {
        if (stepsTaken < stepsLimit)
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
        else Debug.Log("Cannot move anymore");
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

            ResourceInstance[] resources = FindObjectsOfType(typeof(ResourceInstance)) as ResourceInstance[];

            for (int i = 0; i < resources.Length; i++)
            {
                if (resources[i].transform.position.x == troopPosition.x && resources[i].transform.position.z == troopPosition.z)
                {
                    tileBlocked = true;
                }
            }

            if (tileBlocked == false)
            {
                transform.position = troopPosition;
                stepsTaken++;
            }
        }
        else Debug.Log("Boundaries checked and enforced");

        // Steps limit will be implemented when the turn system is implemented in future builds
    }

    public void select() // Selects troop and unselects all other troops
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            if (troops[i].isSelected)
            {
                troops[i].unselect();
                troops[i].selectedHighlight.SetActive(false);
                if (troops[i].getCurrentTarget() != null && troops[i].getCurrentTarget().CompareTag("Troop")) troops[i].currentTarget.GetComponent<TroopInstance>().targetedHighlight.SetActive(false); // If current target is a troop, turn off its highlight when switching troop
                else if (troops[i].getCurrentTarget() != null && troops[i].getCurrentTarget().CompareTag("Resource")) troops[i].currentTarget.GetComponent<ResourceInstance>().targetedHighlight.SetActive(false); // If current target is a resource, turn off its highlight when switching troop
            } 
        }
        currentTarget = null;
        isSelected = true;
        selectedHighlight.SetActive(true);
    }

    public void resetSteps()
    {
        stepsTaken = 0;
    }    

    public void resetHighlights()
    {
        selectedHighlight.SetActive(false);
        targetedHighlight.SetActive(false);
    }    

    public void resetAttacks()
    {
        attackSpent = false;
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
                    if(hit.transform.GetComponent<TroopInstance>().getOwner() == GameManager.GetPlayer()) // NOTE!: This statement needs to change for future builds (currently only supports 1 player).
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

    public void spendAttack()
    {
        attackSpent = true;
    }

    public void selectTarget() // Selects target (enemy troop or resource)
    {
        if (Input.GetMouseButtonDown(1)) // Check if user right clicks on target
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.CompareTag("Troop") || hit.transform.CompareTag("HQ"))
                {
                    if (hit.transform.GetComponent<TroopInstance>().getOwner() != GameManager.GetPlayer())
                    {
                        if (currentTarget != null && ( currentTarget.CompareTag("Troop") || currentTarget.CompareTag("HQ") ) ) currentTarget.GetComponent<TroopInstance>().targetedHighlight.SetActive(false); // Turn off previous troop target's highlight if new target is selected
                        else if (currentTarget != null && currentTarget.CompareTag("Resource")) currentTarget.GetComponent<ResourceInstance>().targetedHighlight.SetActive(false); // Turn off previous resource target's highlight if new target is selected

                        currentTarget = hit.transform.gameObject; // Sets a troops current target
                        hit.transform.gameObject.GetComponent<TroopInstance>().targetedHighlight.SetActive(true); // Activates the targeted highlight for the target
                        Debug.Log("Enemy: " + currentTarget.name + " was selected");
                    }
                }
                else if (hit.transform.CompareTag("Resource"))
                {
                    if (currentTarget != null && ( currentTarget.CompareTag("Troop") || currentTarget.CompareTag("HQ") ) ) currentTarget.GetComponent<TroopInstance>().targetedHighlight.SetActive(false); // Turn off previous troop target's highlight if new target is selected
                    else if (currentTarget != null && currentTarget.CompareTag("Resource")) currentTarget.GetComponent<ResourceInstance>().resetHighlight();// Turn off previous resource target's highlight if new target is selected

                    currentTarget = hit.transform.gameObject; // Sets resource as a current target
                    hit.transform.gameObject.GetComponent<ResourceInstance>().setHighlight(); // Activates the targeted highlight for the target
                    Debug.Log("Resource: " + currentTarget.name + " was selected");
                }
                
            }
        }
    }

    public void interactTarget() // Troop interacts with the target (attacks enemy or harvests resource)
    {
        if (currentTarget.CompareTag("Troop") || currentTarget.CompareTag("HQ"))
        {
            if (Mathf.Abs(gameObject.transform.position.x - currentTarget.transform.position.x) <= (attackRange * stepDistance) && (Mathf.Abs(gameObject.transform.position.z - currentTarget.transform.position.z) <= (attackRange * stepDistance) ) )
            {
                Debug.Log("Enemy in range: " + currentTarget.name + " HP is " + currentTarget.GetComponent<TroopInstance>().healthPoints);
                attackTarget();
            }
            else Debug.Log("Enemy not in range: " + currentTarget.name + " HP is " + currentTarget.GetComponent<TroopInstance>().healthPoints);
        }
        else if (currentTarget.tag == "Resource")
        {
            if (Mathf.Abs(gameObject.transform.position.x - currentTarget.transform.position.x) <= stepDistance && (Mathf.Abs(gameObject.transform.position.z - currentTarget.transform.position.z) <= stepDistance))
            {
                useTarget();
            }
        }
    }

    public void attackTarget() // Performs attack calculation
    {
        if (!attackSpent)
        {
            TroopInstance enemy = currentTarget.GetComponent<TroopInstance>();

            enemy.healthPoints -= damageStat;
            Debug.Log("Enemy" + currentTarget.name + " HP after attack: " + enemy.healthPoints);
            attackSpent = true;
        }
        else
        {
            Debug.Log("Out of attacks");
        }
    }

    public void useTarget() // Performs harvest calculation
    {
        ResourceInstance resource = currentTarget.GetComponent<ResourceInstance>();
        owner.addGold(resource.harvest());
        Destroy(currentTarget);
        currentTarget = null;
    }

    public void takeDamage(int damage)
    {
        healthPoints -= damage;
        Debug.Log(gameObject.name + " took damage");
    }
}
