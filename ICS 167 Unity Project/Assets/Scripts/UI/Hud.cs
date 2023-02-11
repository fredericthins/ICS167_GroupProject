using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hud : MonoBehaviour
{
    
    public TMP_Text TroopType;
    public TMP_Text HPDisplay;
    public TMP_Text P1GoldDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        P1GoldDisplay.text = "$125";
        TroopType.text = "Swordsman";
        HPDisplay.text = "HP: 100";
    }
}
