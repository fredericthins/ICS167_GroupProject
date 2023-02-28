using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken : ResourceInstance
{
    // Start is called before the first frame update
    void Start()
    {
        value = 50;
        targetedHighlight = gameObject.transform.GetChild(0).gameObject;
    }
}
