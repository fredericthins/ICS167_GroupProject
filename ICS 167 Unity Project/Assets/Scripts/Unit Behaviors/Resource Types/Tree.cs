using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : ResourceInstance
{
    // Start is called before the first frame update
    void Start()
    {
        value = 15;
        targetedHighlight = gameObject.transform.GetChild(0).gameObject;
    }

}
