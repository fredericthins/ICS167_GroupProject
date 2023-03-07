using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoutStatsDisplay : MonoBehaviour
{
    Scout scout;

    public TMP_Text TroopType;
    public TMP_Text TroopHP;
    public TMP_Text TroopATT;
    public TMP_Text TroopMove;
    public TMP_Text TroopRange;
    public TMP_Text TroopCost;

    void Awake()
    {
        scout = GameObject.Find("Scout").GetComponent<Scout>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TroopHP.text = "Hp: " + scout.getHP().ToString();
        TroopATT.text = "Att: " + scout.getATT().ToString();
        TroopMove.text = "Move: " + scout.getMove().ToString();
        TroopRange.text = "Range: " + scout.getRange().ToString();
        TroopCost.text = "Cost: " + scout.getCost().ToString();
    }
}
