using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleeState : AnimalState
{
    public override void commandAnimal()
    {
        flee();
    }


    void flee()
    {

        // If a troop is detected then attack
        if (animalAI.getTarget() != null)
        {
            Vector3 awayDirection = animal.transform.position - animalAI.getTarget().transform.position;
            awayDirection.Normalize();

            animalAI.setWanderDirectionX((int)Mathf.Ceil(awayDirection.x));
            animalAI.setWanderDirectionZ((int)Mathf.Ceil(awayDirection.z));

            // Debug.Log("Flee x and z are " + animalAI.getWanderDirectionX() + " and " + animalAI.getWanderDirectionZ() );
            animalAI.move(animalAI.getStepDistance() * animalAI.getWanderDirectionX(), animalAI.getStepDistance() * animalAI.getWanderDirectionZ());

            TroopInstance detectedTroop = detectTroop();
            if (detectedTroop == null) animalAI.setTarget(null);
        }
        // Else, switch back to patrol
        else
        {
            WanderState state = CreateInstance<WanderState>();
            animalAI.setState(state);
            animalAI.setTarget(null);
            animalAI.randomizeWanderDirections();
            return;
        }

    }


    private TroopInstance detectTroop()
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            if (!troops[i].CompareTag("HQ") && Mathf.Abs(animal.transform.position.x - troops[i].transform.position.x) <= (animalAI.getDetectionRange()) && (Mathf.Abs(animal.transform.position.z - troops[i].transform.position.z) <= animalAI.getDetectionRange()))
            {
                return troops[i].GetComponent<TroopInstance>();
            }
        }

        return null;
    }

}
