using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInstance : MonoBehaviour, IHarvestable, ISelectable
{
    // ResourceInstance was updated by Luis, Frederic, and Dale
    // All objects that inherit from ResourceInstance were worked on by all members of the group

    public bool isSelected { get; set; }
    [SerializeField] protected int value;
    public GameObject targetedHighlight;

    public int harvest()
    {
        //GameManager.gold += value;
        return value; // Returns value
    }
    public void resetHighlight()
    {
        targetedHighlight.SetActive(false);
    }
    public void setHighlight()
    {
        targetedHighlight.SetActive(true);
    }
}
