using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // GameManager was worked on by Frederic and Luis
    static private GameManager instance;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private TMP_Text winnerMessage;

    static private int initialGold = 125; // Default gold setting for game start
    static public bool isMultiplayer = false; // The game's default game type

    public bool settingUp;
    public Player P1; // Player 1 Object
    public Player P2; // Player 2 Object
    [SerializeField] private TroopInstance P1Hq; // Player 1's Headquarters data
    [SerializeField] private TroopInstance P2Hq; // Player 2's Headquarters data

    [SerializeField] private TroopManager troopData;

    [SerializeField] private int minimumGold; // Minimum amount of gold needed to purchase cheapest troop (used for end conditions and stored here for future changes)


    static public bool isPaused = false;
    private bool gameIsOver;

    // Turn Management
    static public int turnCount = 0;
    static public Player currentPlayer; // Is assigned a player (P1 or P2) depending on the turn


    private void Awake()
    {
        instance = this;
        gameIsOver = false;
        resetGame();
        settingUp = true;
    }

    // Turn Checking. Determines current player.
    private void Update()
    {
        checkCurrentPlayer();
        if (!gameIsOver) checkEndConditions();
    }

    static public GameManager getGameManager()
    {
        return instance;
    }

    static public Player GetPlayer()
    {
        return currentPlayer;
    }

    public bool getSettingUp()
    {
        return settingUp;
    }

    private void checkCurrentPlayer()
    {
        if (turnCount == 0) // Pre-game set up (both sides buy troops)
        {
            currentPlayer = null;
        }
        else
        {
            if (turnCount % 4 == 1) // Player 1's turns
            {
                // Debug.Log("Player 1's Turn");
                currentPlayer = P1;
            }
            if (turnCount % 4 == 2) // NPC turn
            {
                // Debug.Log("NPC Turn");
                currentPlayer = null;
            }
            if (turnCount % 4 == 3) // Player 2's turns
            {
                // Debug.Log("Player 2's Turn");
                currentPlayer = P2;
            }
            if (turnCount % 4 == 0) // Player 2's turns
            {
                // Debug.Log("NPC's Turn");
                currentPlayer = null;
            }
        } 
    }

    private void checkEndConditions()
    {
        // If P1 or P2 have there HQ destroyed than the game ends.
        if (P1Hq.getHP() <= 0)
        {
            Debug.Log("Player 2 Wins. Player 1's HQ was destroyed.");
            Time.timeScale = 0; // Pauses game
            isPaused = true;
            triggerGameOver(P2);
        }
        if (P2Hq.getHP() <= 0)
        {
            Debug.Log("Player 1 Wins. Player 2's HQ was destroyed.");
            Time.timeScale = 0; // Pauses game
            isPaused = true;
            triggerGameOver(P1);
        }

        // If P1 or P2 have less than the minimum gold needed to buy a troop and is out of troops then the game ends.
        if (P1.getGold() < minimumGold && troopData.getP1Troops().Count <= 0)
        {
            Debug.Log("Player 2 Wins. Player 1 is out of resources and troops.");
            Time.timeScale = 0; // Pauses game
            isPaused = true;
            triggerGameOver(P2);
        }
        if (P2.getGold() < minimumGold && troopData.getP2Troops().Count <= 0)
        {
            Debug.Log("Player 1 Wins. Player 2 is out of resources and troops.");
            Time.timeScale = 0; // Pauses game
            isPaused = true;
            triggerGameOver(P1);
        }
    }

    // Triggers the game over
    private void triggerGameOver(Player winner)
    {
        gameIsOver = true;
        winnerMessage.SetText(winner.getName() + " wins!");
        gameOverScreen.SetActive(true);
    }

    public Player getP1()
    {
        return P1;
    }
    public Player getP2()
    {
        return P2;
    }

    // Default settings for new game
    static public void resetGame()
    {
        instance.P1.setGold(initialGold);
        instance.P2.setGold(initialGold);
        turnCount = 0;
        currentPlayer = null;
    }
    
    // For future use in online multiplayer
    static public void enableMultiplayer()
    {
        isMultiplayer = true;
    }

    static public void disableMultiplayer()
    {
        isMultiplayer = false;
    }

    // Increments turn count
    public void nextTurn()
    {
        if (!gameIsOver)
        {
            turnCount++;
            Debug.Log("Turn incremented. Turn count is now: " + turnCount);
            checkCurrentPlayer();
            resetTroopConditions();
            resetResourceConditions();
            settingUp = false;
        }     
    }

    // Gets current turn
    public int getTurn()
    {
        return turnCount;
    }

    // Resets troop conditions
    private void resetTroopConditions()
    {
        TroopInstance[] troops = FindObjectsOfType(typeof(TroopInstance)) as TroopInstance[];
        for (int i = 0; i < troops.Length; i++)
        {
            troops[i].resetSteps();
            troops[i].resetHighlights();
            troops[i].resetAttacks();
            troops[i].unselect();
        }
    }

    // Reset resource conditions
    private void resetResourceConditions()
    {

        ResourceInstance[] resources = FindObjectsOfType(typeof(ResourceInstance)) as ResourceInstance[];

        for (int i = 0; i < resources.Length; i++)
        {
            if (resources != null)
            {
                resources[i].resetHighlight();
                if (resources[i].GetComponent<AnimalAI>() != null)
                {
                    resources[i].GetComponent<AnimalAI>().resetSteps();
                }
            }    
        }
    }
}
