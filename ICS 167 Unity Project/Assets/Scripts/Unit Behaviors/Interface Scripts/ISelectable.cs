using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectable
{
    public bool isSelected {get; set;}

    public void select();
    public void unselect();

}
