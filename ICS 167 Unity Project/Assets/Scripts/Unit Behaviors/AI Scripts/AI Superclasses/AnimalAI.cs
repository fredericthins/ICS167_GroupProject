using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalAI : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] private GameObject animal;
    [SerializeField] private TroopInstance target; // Troop to flee from
    [SerializeField] private AnimalState state; // The state of the animal (grazing, wandering, fleeing)
    [SerializeField] private int detectionRange = 20;
    private float horizontalBounds = 110f;
    private float verticalBounds = 50f;
    private int wanderDirectionX;
    private int wanderDirectionZ;
    private int stepDistance = 10;
    private int stepsTaken = 0;
    private int stepsLimit = 2;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.getGameManager();
        state = ScriptableObject.CreateInstance<GrazeState>();
        state.setAnimal(animal);
        randomizeWanderDirections();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetPlayer() == null)
        {
            // Debug.Log("AnimalState is " + state);
            state.commandAnimal();
        }
    }

    public void setState(AnimalState state)
    {
        this.state = state;
        this.state.setAnimal(animal);
    }

    public TroopInstance getTarget()
    {
        return target;
    }

    public void setTarget(TroopInstance target)
    {
        this.target = target;
    }

    public int getWanderDirectionX()
    {
        return wanderDirectionX;
    }

    public void setWanderDirectionX(int direction)
    {
        wanderDirectionX = direction;
    }

    public int getWanderDirectionZ()
    {
        return wanderDirectionZ;
    }

    public void setWanderDirectionZ(int direction)
    {
        wanderDirectionZ = direction;
    }
    
    public void randomizeWanderDirections()
    {
        wanderDirectionX = Random.Range(-1, 2);
        wanderDirectionZ = Random.Range(-1, 2);
        Debug.Log("Current wander directions are : " + wanderDirectionX + " and " + wanderDirectionZ);
    }

    public int getDetectionRange()
    {
        return detectionRange;
    }

    public int getStepsTaken()
    {
        return stepsTaken;
    }

    public int getStepsLimit()
    {
        return stepsLimit;
    }

    public int getStepDistance()
    {
        return stepDistance;
    }

    public void resetSteps()
    {
        stepsTaken = 0;
    }

    public void move(int x, int z) // Performs the move calculation and boundary check
    {

        Vector3 animalPosition = animal.transform.position;
        animalPosition += new Vector3(x, 0, z);

        if (Mathf.Abs(animalPosition.x) <= horizontalBounds && Mathf.Abs(animalPosition.z) <= verticalBounds) // Boundary Check
        {
            // Check if troop is occupying space
            bool tileBlocked = false;

            TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];

            for (int i = 0; i < troops.Length; i++)
            {
                if (troops[i].transform.position.x == animalPosition.x && troops[i].transform.position.z == animalPosition.z)
                {
                    tileBlocked = true;
                }
            }

            ResourceInstance[] resources = FindObjectsOfType(typeof(ResourceInstance)) as ResourceInstance[];

            for (int i = 0; i < resources.Length; i++)
            {
                if (resources[i].transform.position.x == animalPosition.x && resources[i].transform.position.z == animalPosition.z)
                {
                    tileBlocked = true;
                }
            }

            if (tileBlocked == false)
            {
                animal.transform.position = animalPosition;
                stepsTaken++;
            }
        }
        else
        {
            Debug.Log("Boundaries checked and enforced on animal");
            this.randomizeWanderDirections();
        }
           
    }

}

