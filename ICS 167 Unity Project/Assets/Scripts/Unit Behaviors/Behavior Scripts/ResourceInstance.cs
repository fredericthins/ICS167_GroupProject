using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceInstance : MonoBehaviour, IHarvestable, ISelectable
{
    public bool isSelected { get; set; }

    public int harvest()
    {
        throw new System.NotImplementedException();
    }

    public void select()
    {

    }

    public void unselect()
    {

    }
}
