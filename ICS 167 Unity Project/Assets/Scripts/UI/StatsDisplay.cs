using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsDisplay : MonoBehaviour
{
    
    Swordsman swordsman;
    
    // Troop Stats
    public TMP_Text TroopType;
    public TMP_Text TroopHP;
    public TMP_Text TroopATT;
    public TMP_Text TroopMove;
    public TMP_Text TroopRange;
    public TMP_Text TroopCost;

    

    void Awake()
    {
        swordsman = GameObject.Find("Swordsman").GetComponent<Swordsman>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TroopHP.text = "Hp: " + swordsman.getHP().ToString();
        TroopATT.text = "Att: " + swordsman.getATT().ToString();
        TroopMove.text = "Move: " + swordsman.getMove().ToString();
        TroopRange.text = "Range: " + swordsman.getRange().ToString();
        TroopCost.text = "Cost: " + swordsman.getCost().ToString();
    }

}
