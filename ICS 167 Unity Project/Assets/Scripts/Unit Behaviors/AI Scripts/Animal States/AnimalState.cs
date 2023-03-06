using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AnimalState : ScriptableObject
{
    protected GameObject animal;
    protected AnimalAI animalAI;

    public abstract void commandAnimal();

    public void setAnimal(GameObject animal)
    {
        this.animal = animal;
        this.animalAI = animal.GetComponent<AnimalAI>();
    }
}
