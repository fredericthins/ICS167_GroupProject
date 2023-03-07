using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CalvaryStatsDisplay : MonoBehaviour
{
    Calvary calvary;

    // Troop Stats
    public TMP_Text TroopType;
    public TMP_Text TroopHP;
    public TMP_Text TroopATT;
    public TMP_Text TroopMove;
    public TMP_Text TroopRange;
    public TMP_Text TroopCost;

    void Awake()
    {
        calvary = GameObject.Find("Calvary").GetComponent<Calvary>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TroopHP.text = "Hp: " + calvary.getHP().ToString();
        TroopATT.text = "Att: " + calvary.getATT().ToString();
        TroopMove.text = "Move: " + calvary.getMove().ToString();
        TroopRange.text = "Range: " + calvary.getRange().ToString();
        TroopCost.text = "Cost: " + calvary.getCost().ToString();
    }
}
