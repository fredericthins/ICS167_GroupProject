using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OozeAI : MonsterAI
{
    private GameManager gameManager;
    private TroopInstance targetTroop;
    [SerializeField] private TroopInstance monster;
    [SerializeField] private MonsterState state; // The state of the monster (standing, patrolling, hunting)
    private int patrolDirection;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.getGameManager();
        state = ScriptableObject.CreateInstance<IdleState>();
        state.setMonster(monster);
        patrolDirection = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetPlayer() == null)
        {
            Debug.Log("State is " + state);
            state.commandMonster();
        }
    }

    public override void setState(MonsterState state)
    {
        this.state = state;
        state.setMonster(monster);
    }

    public override int getPatrolDirection()
    {
        return patrolDirection;
    }
    public override void setPatrolDirection(int direction)
    {
        patrolDirection = direction;
    }

    public override TroopInstance getTarget()
    {
        return targetTroop;
    }
    public override void setTarget(TroopInstance target)
    {
        targetTroop = target;
    }
}
