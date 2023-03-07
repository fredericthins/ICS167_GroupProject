using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpearmanStatsDisplay : MonoBehaviour
{
    Spearman spearman;

    // Troop Stats
    public TMP_Text TroopType;
    public TMP_Text TroopHP;
    public TMP_Text TroopATT;
    public TMP_Text TroopMove;
    public TMP_Text TroopRange;
    public TMP_Text TroopCost;



    void Awake()
    {
        spearman = GameObject.Find("Spearman").GetComponent<Spearman>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TroopHP.text = "Hp: " + spearman.getHP().ToString();
        TroopATT.text = "Att: " + spearman.getATT().ToString();
        TroopMove.text = "Move: " + spearman.getMove().ToString();
        TroopRange.text = "Range: " + spearman.getRange().ToString();
        TroopCost.text = "Cost: " + spearman.getCost().ToString();
    }
}
