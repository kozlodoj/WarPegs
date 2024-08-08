using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpecialPeg : MonoBehaviour
{
    [SerializeField]
    private Image lvlBar;
    [SerializeField]
    private TextMeshProUGUI lvlText;
    public int pegNumber;
    public float lvl;
    public float chance;
   

    public void SetLvlUI(float lvl)
    {
        lvlBar.fillAmount = lvl % 1;
        lvlText.SetText("lvl " + (lvl - (lvl % 1)));
        
        
    }
   
}
