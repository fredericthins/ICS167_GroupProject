using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    List<TroopInstance> troopList;
    //Spawn troop prefab
    public void SpawnTroop(Vector3 position, GameObject troop){
        Instantiate(troop, position, Quaternion.identity);
    }
}
