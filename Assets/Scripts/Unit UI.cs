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
    [SerializeField]
    private TextMeshProUGUI buffTextOutline;
    [SerializeField]
    private TextMeshProUGUI hpText;

    public void UpdateHP(float initialAmount, float amount)
    {
        hPBar.fillAmount = amount / initialAmount;
        if (hpText != null)
        hpText.SetText(amount.ToString("0"));
    }

    public void BufText(float amount)
    {
        if (amount != 1)
        {
            buffText.SetText("X" + amount.ToString());
            buffTextOutline.SetText("X" + amount.ToString());
        }
        else
        {
            buffText.SetText("");
            buffTextOutline.SetText("");
        }
    }
}
