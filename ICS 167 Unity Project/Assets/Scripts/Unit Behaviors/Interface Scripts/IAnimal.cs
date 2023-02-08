using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimal : ISelectable
{
    // Returns its value to the player that harvests it
    public int harvest();

}
