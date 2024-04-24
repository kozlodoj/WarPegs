using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitUI : MonoBehaviour
{
    [SerializeField]
    private Image hPBar;

    public void UpdateHP(float initialAmount, float amount)
    {
        hPBar.fillAmount = amount / initialAmount;
    }
}
