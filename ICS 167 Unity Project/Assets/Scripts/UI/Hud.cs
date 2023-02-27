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
    public TMP_Text P2TroopType;
    public TMP_Text P2HPDisplay;
    public TMP_Text P2GoldDisplay;
    public GameObject pauseDisplay;

    // Game Data
    private GameManager gameManager;
    private Player P1;
    private Player P2;
    public TMP_Text turnDisplay;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.getGameManager();

        P1 = gameManager.getP1();
        P2 = gameManager.getP2();

        P1GoldDisplay.text = P1.getGold().ToString();
        TroopType.text = "TROOP TYPE";
        HPDisplay.text = "HP:";

        P2GoldDisplay.text = P2.getGold().ToString();
        P2TroopType.text = "TROOP TYPE";
        P2HPDisplay.text = "HP:";
}

    // Update is called once per frame
    void Update()
    {
        P1GoldDisplay.SetText("$" + P1.getGold().ToString()); // Gets gold variable from the game manager and updates Player 1 gold display
        P2GoldDisplay.SetText("$" + P2.getGold().ToString()); // Gets gold variable from the game manager and updates Player 2 gold display
        troopUpdate(); // Update troop UI data
        pauseCheck(); // Checks if game is paused

        
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
                        P2TroopType.text = targetComponent.GetType().ToString(); // Sets the troop type text to be the name of the enemy troop object that is selected
                        P2HPDisplay.text = "HP: " + targetComponent.getHP().ToString(); // Sets the troop type text to be the name of troop type text to be the name of the enemy troop object that is selected
                    }
                    else if (target.CompareTag("Resource"))
                    {
                        ResourceInstance targetComponent = troops[i].getCurrentTarget().GetComponent<ResourceInstance>();// Gets ResourceInstance script of the target
                        P2TroopType.text = target.name.ToString(); // Changes enemy troop text to be the name of the resource
                        P2HPDisplay.text = ""; // Resource has no HP
                    }
                    
                }
                else // If there is no target then the enemy data stays as the default values
                {
                    P2TroopType.text = "TROOP TYPE";
                    P2HPDisplay.text = "HP:";
                }
            }
        }
    }

    private void pauseCheck()
    {
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

    public void updateTurnText()
    {
        
        Player actingPlayer = GameManager.GetPlayer();
        Debug.Log("Turn text update has been called with current player: " + actingPlayer.getName());

        if (actingPlayer != null)
        {
            turnDisplay.SetText(actingPlayer.getName() + "'s Turn");
            Debug.Log("Turn text has been updated");
        }
    }
}
