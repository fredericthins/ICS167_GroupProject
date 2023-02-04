using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTile_A : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMap_A tileMap;
    
    void OnMouseDown(){
        Debug.Log("Mouse Click");

        tileMap.GeneratePathTo(tileX, tileY);
        Unit_A target = tileMap.selectedTarget.GetComponent<Unit_A>();
        target.WalkCurrentPath();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
