using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ArcherStatsDisplay : MonoBehaviour
{
    Archer archer;

    public TMP_Text TroopType;
    public TMP_Text TroopHP;
    public TMP_Text TroopATT;
    public TMP_Text TroopMove;
    public TMP_Text TroopRange;
    public TMP_Text TroopCost;

    void Awake()
    {
        archer = GameObject.Find("Archer").GetComponent<Archer>();

    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TroopHP.text = "Hp: " + archer.getHP().ToString();
        TroopATT.text = "Att: " + archer.getATT().ToString();
        TroopMove.text = "Move: " + archer.getMove().ToString();
        TroopRange.text = "Range: " + archer.getRange().ToString();
        TroopCost.text = "Cost: " + archer.getCost().ToString();
    }
}
