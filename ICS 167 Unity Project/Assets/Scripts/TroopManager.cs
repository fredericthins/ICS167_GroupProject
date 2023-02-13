using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    // TroopManager was worked on by Frederic


    // Will be expanded upon in future builds
    List<TroopInstance> troopList;
    //Spawn troop prefab
    public void SpawnTroop(Vector3 position, GameObject troop){
        Instantiate(troop, position, Quaternion.identity);
    }
}
