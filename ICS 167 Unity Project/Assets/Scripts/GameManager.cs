using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static private GameManager instance;

    static private int initialGold = 125; // Default gold setting for game start
    static public bool isMultiplayer = false; // The game's default game type

    // GameManager was worked on by Frederic and Luis
    public Player P1;
    public Player P2;

    static public bool isPaused = false;

    // Turn Management
    static public int turnCount = 0;
    static public Player currentPlayer; // Is assigned a player (P1 or P2) depending on the turn

    private void Awake()
    {
        instance = this;
        resetGame();
    }

    // Turn Checking. Determines current player.
    private void Update()
    {
        // checkCurrentPlayer();
    }

    static public GameManager getGameManager()
    {
        return instance;
    }

    static public Player GetPlayer()
    {
        return currentPlayer;
    }

    private void checkCurrentPlayer()
    {
        if (turnCount == 0) // Pre-game set up (both sides buy troops)
        {
            currentPlayer = null;
        }
        else
        {
            if (turnCount % 2 == 1) // Player 1's turns
            {
                // Debug.Log("Player 1's Turn");
                currentPlayer = P1;
            }
            if (turnCount % 2 == 0) // Player 2's turns
            {
                // Debug.Log("Player 2's Turn");
                currentPlayer = P2;
            }
        } 
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
        instance.P1.setName("Player 1");
        instance.P2.setName("Player 2");
        instance.P1.setGold(initialGold);
        instance.P2.setGold(initialGold);
        turnCount = 0;
        currentPlayer = null;
    }
    

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
        turnCount++;
        Debug.Log("Turn incremented. Turn count is now: " + turnCount);
        checkCurrentPlayer();
        resetTroopConditions();
    }

    public int getTurn()
    {
        return turnCount;
    }

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
}
