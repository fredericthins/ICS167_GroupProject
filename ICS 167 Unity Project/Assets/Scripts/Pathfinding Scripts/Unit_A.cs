using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_A : MonoBehaviour
{
    public int tileX;
    public int tileY;
    public TileMap_A tilemap;
    public List<Node> currentPath = null;
    public float smoothTime = 0.1f;
    private Vector3 velocity = Vector3.zero;
    public bool isMoving;

    void Update(){
        if(currentPath != null){

            int currNode = 0;

            while(currNode <currentPath.Count - 1){
                Vector3 start = tilemap.TileCoordToWorldCoord(currentPath[currNode].x, currentPath[currNode].y) + new Vector3(0,0,-1f);
                Vector3 end = tilemap.TileCoordToWorldCoord(currentPath[currNode + 1].x, currentPath[currNode + 1].y) + new Vector3(0,0,-1f);

                
                Debug.DrawLine(start, end, Color.red);

                currNode++;
            }
        }
    }
    
    public void WalkCurrentPath(){
        if(currentPath == null){
            return;
        }

        
        if(!isMoving){
            StartCoroutine(SmoothWalk());
        }
        
    }

    IEnumerator SmoothWalk(){
        isMoving = true;

        Node end = currentPath[1];
        Node start = currentPath[0];

        Vector3 endCoord = tilemap.TileCoordToWorldCoord(end.x,end.y);

        while(Vector3.Distance(transform.position, endCoord) >= 0.001f){
            transform.position = Vector3.SmoothDamp(transform.position, endCoord, ref velocity, smoothTime);
            yield return null;
        }

        transform.position = endCoord;

        currentPath.RemoveAt(0);

        if(currentPath.Count >= 2){
            StartCoroutine(SmoothWalk());
        } 
        if(currentPath.Count == 1){
            tileX = currentPath[0].x;
            tileY = currentPath[0].y;
            isMoving = false;
            currentPath = null;
        }
    }
}
