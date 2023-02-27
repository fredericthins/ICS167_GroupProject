using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopManager : MonoBehaviour
{
    // TroopManager was worked on by Frederic and Luis
    private int maxTroops; // Max limit for troops in a troop list

    private GameManager gameManager;

    [SerializeField] private Player P1;
    [SerializeField] private Player P2;

    [SerializeField] private List<GameObject> P1SpawnList;
    [SerializeField] private List<GameObject> P2SpawnList;

    [SerializeField] private List<GameObject> P1TroopList;
    [SerializeField] private List<GameObject> P2TroopList;

    private void Start()
    {
        maxTroops = 5;
        P1TroopList = new List<GameObject>();
        P2TroopList = new List<GameObject>();
        gameManager = GameManager.getGameManager();
        P1 = gameManager.getP1();
        P2 = gameManager.getP2();
    }

    public int submitTroopCost(int cost) // For UI recruitment menu buttons
    {
        return cost;
    }

    // Add a troop to P1's army
    public void addP1Troop(GameObject troop)
    {
        int P1Gold = P1.getGold();
        int troopCost = troop.GetComponent<TroopInstance>().getValue();
        Debug.Log("Troop Cost is: " + troopCost);

        // Checks if the player has enough gold to buy a troop
        if (P1Gold >= troopCost)
        {
            GameObject recruitedTroop = setUpTroop(troop, P1);
            if (P1TroopList.Count < maxTroops)
            {
                P1.addGold(-troopCost);
                spawnP1Troop(recruitedTroop);
                P1TroopList.Add(recruitedTroop);
                Debug.Log("Gold remaining: " + P1.getGold());
            }
        }
    }

    public void addP2Troop(GameObject troop)
    {
        int P2Gold = P2.getGold();
        int troopCost = troop.GetComponent<TroopInstance>().getValue();

        if (P2Gold >= troopCost)
        {
            GameObject recruitedTroop = setUpTroop(troop, P2);
            if (P2TroopList.Count < maxTroops)
            {
                P2.addGold(-troopCost);
                spawnP2Troop(recruitedTroop);
                P2TroopList.Add(recruitedTroop);
            }
        }
    }

    // Assigns a player to a troop
    private GameObject setUpTroop(GameObject troop, Player player)
    {
        GameObject recruitedTroop = troop;
        recruitedTroop.GetComponent<TroopInstance>().setOwner(player);

        return recruitedTroop;
    }

    private void spawnP1Troop(GameObject troop)
    {
        bool tileBlocked = false;
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];

        for (int i = 0; i < P1SpawnList.Count; i++)
        {
            Vector3 spawnPosition = P1SpawnList[i].transform.position;
            
            for (int j = 0; j < troops.Length; j++)
            {
                if (troops[j].transform.position.x == spawnPosition.x && troops[j].transform.position.z == spawnPosition.z)
                {
                    tileBlocked = true;
                }
            }

            if (tileBlocked)
            {
                tileBlocked = false;
                continue;
            }
            else
            {
                Instantiate(troop, spawnPosition, P1SpawnList[i].transform.rotation);
                return;
            }
        }
        Debug.Log("P1 Spawns are occupied");
    }

    private void spawnP2Troop(GameObject troop)
    {
        bool tileBlocked = false;
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];

        for (int i = 0; i < P2SpawnList.Count; i++)
        {
            Vector3 spawnPosition = P2SpawnList[i].transform.position;

            for (int j = 0; j < troops.Length; j++)
            {
                if (troops[j].transform.position.x == spawnPosition.x && troops[j].transform.position.z == spawnPosition.z)
                {
                    tileBlocked = true;
                }
            }

            if (tileBlocked)
            {
                tileBlocked = false;
                continue;
            }
            else
            {
                Instantiate(troop, spawnPosition, P2SpawnList[i].transform.rotation);
                return;
            }
        }
        Debug.Log("P2 Spawns are occupied");
    }
}
