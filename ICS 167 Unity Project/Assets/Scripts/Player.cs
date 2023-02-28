using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player was made by Luis

    [SerializeField] private string playerName;
    [SerializeField] private int gold;

    // Methods for setting and getting the player name
    public void setName(string name)
    {
        playerName = name;
    }

    public string getName()
    {
        return playerName;
    }

    // Methods for setting and getting player gold
    public void setGold(int amount)
    {
        gold = amount;
    }

    public void addGold(int amount)
    {
        gold += amount;
    }

    public int getGold()
    {
        return gold;
    }
}
