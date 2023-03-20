using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NPCManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<GameObject> objects;


    void Start()
    {
        spawnObjects();
    }


    private void spawnObjects()
    {
        if (GameManager.isMultiplayer)
        {
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject NPC = objects[i];
                GameObject spawnedObject = PhotonNetwork.Instantiate(NPC.name, NPC.transform.position, NPC.transform.rotation);
                spawnedObject.SetActive(true);
            }

        }
        else
        {
            for (int i = 0; i < objects.Count; i++)
            {
                GameObject NPC = objects[i];
                GameObject spawnedObject = Instantiate(NPC, NPC.transform.position, NPC.transform.rotation);
                spawnedObject.SetActive(true);
            }
        }
    }


}
