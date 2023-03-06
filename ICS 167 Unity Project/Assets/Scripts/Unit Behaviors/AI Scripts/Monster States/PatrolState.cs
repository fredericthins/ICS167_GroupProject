using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : MonsterState
{
    public override void commandMonster()
    {
        patrol();
    }

    // Monster patrols its area looking for troops to hunt
    private void patrol()
	{
        // Check if a troop is within stepDistance of the monster here. 
        TroopInstance detectedTroop = detectTroop();
		
        if (detectedTroop == null)
        {
            //Debug.Log("Patrol Direction is " + monsterAI.getPatrolDirection());
            // If no adjacent troop
            while (monster.getStepsTaken() < monster.getStepsLimit())
            {
                monster.move(monster.getStepDistance() * monsterAI.getPatrolDirection(), 0);
                // check if troop is detected again. If so, switch state to “Hunting”, set target, and return
                detectedTroop = detectTroop();
                if (detectedTroop != null)
                {
                    HuntState state = CreateInstance<HuntState>();
                    monsterAI.setState(state);
                    monsterAI.setTarget(detectedTroop);
                    return;
                }
                // If not, then continue
                if (monster.getStepsTaken() == monster.getStepsLimit()) monsterAI.setPatrolDirection(-(monsterAI.getPatrolDirection())); // Switches patrol direction to the opposite direction
            }
        }
        else
        {
            HuntState state = CreateInstance<HuntState>();
            monsterAI.setState(state);
            monsterAI.setTarget(detectedTroop);
            return;
        }
		
	}

    // Checks if a troop is in its area
    private TroopInstance detectTroop()
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            if (troops[i] != monster.GetComponent<TroopInstance>() && troops[i].CompareTag("Troop") && Mathf.Abs(monster.transform.position.x - troops[i].transform.position.x) <= (monster.getStepDistance()) && (Mathf.Abs(monster.transform.position.z - troops[i].transform.position.z) <= (monster.getStepDistance())))
            {
                return troops[i].GetComponent<TroopInstance>();
            }
        }

        return null;
    }

}
