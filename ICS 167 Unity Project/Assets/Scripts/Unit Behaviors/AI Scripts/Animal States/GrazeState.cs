using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrazeState : AnimalState
{
    public override void commandAnimal()
    {
        if (!(GameManager.getGameManager().getTurn() == 0))
        {
            WanderState state = CreateInstance<WanderState>();
            animalAI.setState(state);
        }
    }

}
