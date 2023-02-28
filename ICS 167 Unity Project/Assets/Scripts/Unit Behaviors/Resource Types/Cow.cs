using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : ResourceInstance
{
    // Start is called before the first frame update
    void Start()
    {
        value = 30;
        targetedHighlight = gameObject.transform.GetChild(0).gameObject;
    }
}
