using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntState : MonsterState
{
    public override void commandMonster()
    {
        hunt();
    }


    // Attack troop if they approch monster
    void hunt()
	{
        TroopInstance detectedTroop = detectTroop();
        
        // If a troop is detected then attack
        if (detectedTroop != null)
        {
            if (monster.getAttackSpent() == false)
            {
                Debug.Log("Attack is done while in hunt state");
                monsterAI.getTarget().takeDamage(monster.getATT());
                monster.spendAttack();
            }
        }
        // Else, switch back to patrol
        else
        {
            PatrolState state = CreateInstance<PatrolState>();
            monsterAI.setState(state);
            monsterAI.setTarget(null);
            return;
        }
        
	}

    // Check if troop is in monster detection range
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
