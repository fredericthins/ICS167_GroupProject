using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInstance : MonoBehaviour, IHarvestable, ISelectable
{
    public bool isSelected { get; set; }
    [SerializeField] protected int value;
    public GameObject selectedHighlight;
    public GameObject targetedHighlight;

    public int harvest()
    {
        GameManager.gold += value; // Updates P1 gold in static GameManager
        return value; // Returns value
    }

}
