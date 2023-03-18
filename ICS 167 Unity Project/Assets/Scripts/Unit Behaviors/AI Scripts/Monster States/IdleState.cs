using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : MonsterState
{
    public override void commandMonster()
    {
        if(!( GameManager.getGameManager().getTurn() == 0) )
        {
            PatrolState state = CreateInstance<PatrolState>();
            monsterAI.setState(state);
        }
    }
}
