using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    // The Hud script was made by Dale with additional methods by Luis

    // P1 UI
    public TMP_Text TroopType;
    public TMP_Text HPDisplay;
    public TMP_Text P1GoldDisplay;
    
    // P2 UI
    public TMP_Text EnemyTroopType;
    public TMP_Text EnemyHPDisplay;
    public TMP_Text P2GoldDisplay;

    public GameObject pauseDisplay;

    // Start is called before the first frame update
    void Start()
    {
        P1GoldDisplay.text = GameManager.gold.ToString();
        TroopType.text = "Troop Type";
        HPDisplay.text = "HP:";

        P2GoldDisplay.text = "$0";
        EnemyTroopType.text = "Troop Type";
        EnemyHPDisplay.text = "HP:";
}

    // Update is called once per frame
    void Update()
    {
        P1GoldDisplay.text = "$" + GameManager.gold.ToString(); // Gets static gold variable from the game manager and updates Player 1 gold display
        troopUpdate(); // Update troop UI data

        if (pauseDisplay.activeInHierarchy)
        {
            Debug.Log("Paused");
            Time.timeScale = 0; // Pauses game
            GameManager.isPaused = true;
        }
        else
        {
            Time.timeScale = 1; // Resumes game
            GameManager.isPaused = false;
        }
    }

    private void troopUpdate()
    {
        // Looks at all active troops in the scenes.
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            if (troops[i].isSelected) // If a friendly troop is currently selected, update the UI with its data
            {
                // Debug.Log(troops[i]);
                TroopInstance selectedTroop = troops[i]; // Gets selected troop

                TroopType.text = selectedTroop.GetType().ToString(); // Sets the troop type text to be the name of the troop object that is selected
                HPDisplay.text = "HP: " + selectedTroop.getHP().ToString(); // Sets the troop type text to be the name of the troop object that is selected

                if(troops[i].getCurrentTarget() != null) // If there is a target
                {
                    GameObject target = troops[i].getCurrentTarget();

                    if (target.CompareTag("Troop"))
                    {
                        TroopInstance targetComponent = troops[i].getCurrentTarget().GetComponent<TroopInstance>();// Gets TroopInstance script of the target
                        EnemyTroopType.text = targetComponent.GetType().ToString(); // Sets the troop type text to be the name of the enemy troop object that is selected
                        EnemyHPDisplay.text = "HP: " + targetComponent.getHP().ToString(); // Sets the troop type text to be the name of troop type text to be the name of the enemy troop object that is selected
                    }
                    // Needs to change when multiplayer is implemented
                    else if (target.CompareTag("Resource"))
                    {
                        ResourceInstance targetComponent = troops[i].getCurrentTarget().GetComponent<ResourceInstance>();// Gets ResourceInstance script of the target
                        EnemyTroopType.text = target.name.ToString(); // Changes enemy troop text to be the name of the resource
                        EnemyHPDisplay.text = ""; // Resource has no HP
                    }
                    
                }
                else // If there is no target then the enemy data stays as the default values
                {
                    EnemyTroopType.text = "Troop Type";
                    EnemyHPDisplay.text = "HP:";
                }
            }
        }
    }



}
