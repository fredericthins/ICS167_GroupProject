using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTile_A : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMap_A tileMap;
    public int tileNumber;

    void OnMouseDown(){
        Unit_A target = tileMap.selectedTarget.GetComponent<Unit_A>();
        if(!target.isMoving){
            tileMap.GeneratePathTo(tileX, tileY);
            target.WalkCurrentPath();
        }
    }
}
