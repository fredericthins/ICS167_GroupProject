using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : ResourceInstance
{
    // Start is called before the first frame update
    void Start()
    {
        value = 25;
        targetedHighlight = gameObject.transform.GetChild(0).gameObject;
    }
}
