using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuffBuy : MonoBehaviour
{
    private TextMeshProUGUI costText;
    private TextMeshProUGUI rateText;
    private Image goldImage;

    private Color theColor;
    private Color textColor;
    private Color transperentTextColor;
    private Color goldColor;
    private Color trGoldColor;

    private int currentEra = 0;
    private int previousEra = 0;
    // Start is called before the first frame update
    void Start()
    {
        theColor = gameObject.GetComponent<Image>().color;

        costText = transform.Find("Cost Text").gameObject.GetComponent<TextMeshProUGUI>();
        rateText = transform.Find("BuffText").gameObject.GetComponent<TextMeshProUGUI>();
        goldImage = costText.transform.Find("gold").gameObject.GetComponent<Image>();
        rateText.SetText(GameManager.instance.buff.ToString() + "%");
        costText.SetText(GameManager.instance.buffCost.ToString());

        textColor = costText.GetComponent<TextMeshProUGUI>().color;
        transperentTextColor = textColor;
        transperentTextColor.a = 0.1f;
        goldColor = goldImage.color;
        trGoldColor = goldColor;
        trGoldColor.a = 0.1f;
        CheckActive();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive())
            NotEnoughMoney();
        if (EraChanged())
        {
            rateText.SetText(GameManager.instance.buff.ToString() + "%");
            costText.SetText(GameManager.instance.buffCost.ToString());
        }
    }

    public void BuyBuff()
    {
        if (IsActive())
        {
            GameManager.instance.BuyBuff();
            costText.SetText(GameManager.instance.buffCost.ToString());
            rateText.SetText(GameManager.instance.buff.ToString() + "%");
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
        costText.SetText(GameManager.instance.buffCost.ToString());
        rateText.SetText(GameManager.instance.buff.ToString() + "%");
    }

    private bool IsActive()
    {
        if (GameManager.instance.diamonds >= GameManager.instance.buffCost)
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
    private bool EraChanged()
    {
        currentEra = GameManager.instance.playerEra;
        if (currentEra == previousEra)
            return false;
        else
        {
            previousEra = currentEra;
            return true;
        }
    }
}
