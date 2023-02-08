using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    // Player Owner { get; set; }    // Need to define Player class to differentiate the owner of troops (neutral owner for animals)

    public bool isSelected {get; set;}

    public void select()
    {
        isSelected = true;
    }

}
