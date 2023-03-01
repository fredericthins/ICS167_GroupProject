using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    // call appropiate troop type and instantiate it.

    // Troop Stats
    public TMP_Text TroopType;
    public TMP_Text TroopHP;
    public TMP_Text TroopATT;
    public TMP_Text TroopMove;
    public TMP_Text TroopRange;
    public TMP_Text TroopCost;

    // Start is called before the first frame update
    void Start()
    {
        // replace ? with objects troop data.
        //TroopType.text = "?";
        TroopHP.text = "Hp: " + "?";
        TroopATT.text = "Att: " + "?";
        TroopMove.text = "Move: " + "?";
        TroopRange.text = "Range: " + "?";
        //TroopCost.text = "Cost: " + "?";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
