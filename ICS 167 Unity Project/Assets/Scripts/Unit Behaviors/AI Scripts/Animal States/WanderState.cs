using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : AnimalState
{
    public override void commandAnimal()
    {
        TroopInstance detectedTroop = detectTroop();

        if (detectedTroop == null)
        {
            // If no adjacent troop
            if (animalAI.getStepsTaken() < animalAI.getStepsLimit())
            {
                animalAI.move(animalAI.getStepDistance() * animalAI.getWanderDirectionX(), animalAI.getStepDistance() * animalAI.getWanderDirectionZ());
                // check if troop is detected. If so, switch state to “Flee”, set target, and return
                detectedTroop = detectTroop();
                if (detectedTroop != null)
                {
                    FleeState state = CreateInstance<FleeState>();
                    animalAI.setState(state);
                    animalAI.setTarget(detectedTroop);
                    return;
                }
                // If not, then continue
                if (animalAI.getStepsTaken() == animalAI.getStepsLimit() - 1) animalAI.randomizeWanderDirections(); // Randomize wander direction
            }
        }
        else
        {
            FleeState state = CreateInstance<FleeState>();
            animalAI.setState(state);
            animalAI.setTarget(detectedTroop);
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
