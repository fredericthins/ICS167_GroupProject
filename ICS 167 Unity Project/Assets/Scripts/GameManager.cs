using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{   //Player1 Gold - Implement Player 2 Gold later;
    int gold; 
    List<ResourceInstance> mapResources;

    //Spawn resource prefab
    public void SpawnResource(Vector3 position, GameObject resource){
        Instantiate(resource, position, Quaternion.identity);
    }
}
