using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUI : MonoBehaviour
{
    [SerializeField]
    private Image hPBar;
    [SerializeField]
    private TextMeshProUGUI buffText;

    public void UpdateHP(float initialAmount, float amount)
    {
        hPBar.fillAmount = amount / initialAmount;
    }

    public void BufText(float amount)
    {
        buffText.SetText("X " + amount.ToString());
    }
}
