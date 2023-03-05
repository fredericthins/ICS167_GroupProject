using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterState : ScriptableObject
{
    protected TroopInstance monster;
    protected MonsterAI monsterAI;

    public abstract void commandMonster();

    public void setMonster(TroopInstance monster)
    {
        this.monster = monster;
        this.monsterAI = monster.GetComponent<MonsterAI>();
    }

}
