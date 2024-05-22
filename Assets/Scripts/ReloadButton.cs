using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ReloadButton : MonoBehaviour
{
    private TextMeshProUGUI costText;
    private TextMeshProUGUI rateText;
    private Image goldImage;

    private Color theColor;
    private Color textColor;
    private Color transperentTextColor;
    private Color goldColor;
    private Color trGoldColor;

    // Start is called before the first frame update
    void Start()
    {
        theColor = gameObject.GetComponent<Image>().color;
        
        costText = transform.Find("Cost Text").gameObject.GetComponent<TextMeshProUGUI>();
        rateText = transform.Find("ReloadRate Text").gameObject.GetComponent<TextMeshProUGUI>();
        goldImage = costText.transform.Find("gold").gameObject.GetComponent<Image>();
        rateText.SetText(GameManager.instance.reloadRate.ToString() + " Sec");
        costText.SetText(GameManager.instance.reloadCost.ToString());

        textColor = costText.GetComponent<TextMeshProUGUI>().color;
        transperentTextColor = textColor;
        transperentTextColor.a = 0.1f;

        goldColor = goldImage.color;
        trGoldColor = goldColor;
        trGoldColor.a = 0.1f;
        CheckActive();
    }

    private void Update()
    {
        if (!IsActive())
            NotEnoughMoney();
    }

    public void BuyReload()
    {
        if (IsActive())
        {
            GameManager.instance.BuyReloadTime();
            costText.SetText(GameManager.instance.reloadCost.ToString());
            rateText.SetText(GameManager.instance.reloadRate.ToString() + " Sec");
            CheckActive();
        }
    }

    private void SetActive()
    {
        theColor.a = 1f;
        gameObject.GetComponent<Image>().color = theColor;
        gameObject.GetComponent<Button>().enabled = true;
        costText.GetComponent<TextMeshProUGUI>().color = textColor;
        goldImage.color = goldColor;

    }
    private void NotEnoughMoney()
    {
        theColor.a = 0.1f;
        gameObject.GetComponent<Button>().enabled = false;
        gameObject.GetComponent<Image>().color = theColor;
        costText.GetComponent<TextMeshProUGUI>().color = transperentTextColor;
        goldImage.color = trGoldColor;
    }

    private bool IsActive()
    {
        if (GameManager.instance.gold >= GameManager.instance.reloadCost)
            return true;
        else
            return false;

    }
    private void CheckActive()
    {
        if (IsActive())
            SetActive();
        else
            NotEnoughMoney();
    }
}
