using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterAI : MonoBehaviour
{
    public abstract void setState(MonsterState state);
    public abstract TroopInstance getTarget();
    public abstract void setTarget(TroopInstance target);
    public abstract int getPatrolDirection();
    public abstract void setPatrolDirection(int direction);
}
