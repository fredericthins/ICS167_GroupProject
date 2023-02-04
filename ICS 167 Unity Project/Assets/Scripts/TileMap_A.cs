using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TileMap_A : MonoBehaviour
{
    public GameObject selectedTarget;
    public TileType_A[] tileTypes;

    int[,] tiles;

    int mapSizeX = 15;
    int mapSizeY = 15;

    Node[,] graph;
    List<Node> currentPath;

    void Start(){
        selectedTarget.GetComponent<Unit_A>().tileX = (int)selectedTarget.transform.position.x;
        selectedTarget.GetComponent<Unit_A>().tileY = (int)selectedTarget.transform.position.y;
        selectedTarget.GetComponent<Unit_A>().tilemap = this;
        tiles = new int[mapSizeX, mapSizeY];

        GenerateMapData();
        GeneratePathfindingGraph();
        GenerateMapVisual();
    }

    void GenerateMapData(){
        for(int x = 0; x < mapSizeX; x++){
            for(int y = 0; y < mapSizeY; y++){
                //Default set up is full grass
                tiles[x,y] = 0;
            }
        }

        tiles[4,4] = 2;
        tiles[4,5] = 2;
        tiles[4,6] = 2;
        tiles[4,7] = 2;
        tiles[5,7] = 2;
        tiles[5,8] = 2;
        tiles[5,9] = 2;
        tiles[5,10] = 2;
        tiles[4,5] = 2;

        tiles[10,10] = 1;
        tiles[10,11] = 1;
        tiles[11,11] = 1;
        tiles[12,12] = 1;
        tiles[12,11] = 1;
        tiles[11,12] = 1;
        tiles[13,12] = 1;
        tiles[12,13] = 1;
    }

    public class Node{
        public List<Node> edges;
        public int x;
        public int y;

        public Node(){
            edges = new List<Node>();
        }

        public float DistanceTo(Node node){
            return Vector2.Distance(
                new Vector2(x, y),
                new Vector2(node.x, node.y)
            );
        }
    }

    float CostToEnterTile(int sourceX, int sourceY, int targetX, int targetY){
        TileType_A tt = tileTypes[tiles[targetX,targetY]];
        float cost = tt.movementCost;

        if(!IsEnterable(targetX,targetY)){
            return Mathf.Infinity;
        }
        if(sourceX != targetX && sourceY != targetY){
            cost += 0.001f;
        }
        return cost;
    }
    void GeneratePathfindingGraph(){
        graph = new Node[mapSizeX, mapSizeY];

        for(int x = 0; x < mapSizeX; x++){
            for(int y = 0; y < mapSizeY; y++){
                graph[x, y] = new Node();
                graph[x, y].x = x;
                graph[x, y].y = y;
            }
        }

        for(int x = 0; x < mapSizeX; x++){
            for(int y = 0; y < mapSizeY; y++){
                
                List<Node> n_edges = graph[x,y].edges;

                if(x > 0){
                    n_edges.Add(graph[x - 1, y]);
                    if(y > 0){
                        n_edges.Add(graph[x - 1, y - 1]);
                    }
                    if(y < mapSizeY - 1){
                        n_edges.Add(graph[x - 1, y + 1]);
                    }
                }
                if(x < mapSizeX - 1){
                    n_edges.Add(graph[x + 1, y]);
                    if(y > 0){
                        n_edges.Add(graph[x + 1, y - 1]);
                    }
                    if(y < mapSizeY - 1){
                        n_edges.Add(graph[x + 1, y + 1]);
                    }
                }
                if(y > 0){
                    n_edges.Add(graph[x, y - 1]);
                }
                if(y < mapSizeY - 1){
                    n_edges.Add(graph[x, y + 1]);
                }
            }
        }
    }

    void GenerateMapVisual(){
        for(int x = 0; x < mapSizeX; x++){
            for(int y = 0; y < mapSizeY; y++){
                TileType_A tt = tileTypes[tiles[x,y]];

                GameObject tile = Instantiate(tt.tileVisualPrefab, new Vector3(x, y, 0), Quaternion.identity);

                InteractableTile_A it_A = tile.GetComponent<InteractableTile_A>();
                it_A.tileX = x;
                it_A.tileY = y;
                it_A.tileMap = this;
            }
        }
    }

    public Vector3 TileCoordToWorldCoord(int x, int y){
        return new Vector3(x, y, -0.1f);
    }

    public bool IsEnterable(int x, int y){
        TileType_A tt = tileTypes[tiles[x,y]];
        return tt.isWalkable;
    }

    public void GeneratePathTo(int x, int y){
        selectedTarget.GetComponent<Unit_A>().currentPath = null;

        if(!IsEnterable(x,y))
        {
            return;
        }
        
        Dictionary<Node, float> dist = new Dictionary<Node, float>();
        Dictionary<Node, Node> prev = new Dictionary<Node, Node>();

        List<Node> unvisited = new List<Node>();

        Node source = graph[
            selectedTarget.GetComponent<Unit_A>().tileX,
            selectedTarget.GetComponent<Unit_A>().tileY
        ];
        Node target = graph[
            x,
            y
        ];

        dist[source] = 0;
        prev[source] = null;

        foreach(Node v in graph){
            if(v != source){
                dist[v] = Mathf.Infinity;
                prev[v] = null;
            }

            unvisited.Add(v);
        }

        while(unvisited.Count > 0){
            Node u = null;

            //Check each node for the shortest value/distance
            foreach(Node possibleU in unvisited){
                if(u == null || dist[possibleU] < dist[u]){
                    u = possibleU;
                }
            }

            if(u == target){
                break;
            }

            unvisited.Remove(u);

            foreach(Node v in u.edges){
                //float alt = dist[u] + u.DistanceTo(v);
                float alt = dist[u] + CostToEnterTile(u.x, u.y, v.x, v.y);
                if(alt < dist[v]){
                    dist[v] = alt;
                    prev[v] = u;
                }
            }
        }
        
        if(prev[target] == null){
            return;
        }

        List<Node> currentPath = new List<Node>();

        Node curr = target;

        while(curr != null){
            currentPath.Add(curr);
            curr = prev[curr];
        }

        currentPath.Reverse();

        selectedTarget.GetComponent<Unit_A>().currentPath = currentPath;
    }
}
