using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BaseHPButton : MonoBehaviour
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

    public bool isEvent;
    // Start is called before the first frame update
    void Start()
    {
        theColor = gameObject.GetComponent<Image>().color;
        
        costText = transform.Find("Cost Text").gameObject.GetComponent<TextMeshProUGUI>();
        rateText = transform.Find("HPText").gameObject.GetComponent<TextMeshProUGUI>();
        goldImage = costText.transform.Find("gold").gameObject.GetComponent<Image>();
        if (!isEvent)
        {
            rateText.SetText(GameManager.instance.baseHP.ToString() + " HP");
            costText.SetText(GameManager.instance.RoundedNum(GameManager.instance.hPCost));
        }
        else
        {
            rateText.SetText(EventManager.instance.baseHP.ToString() + " HP");
            costText.SetText(GameManager.instance.RoundedNum(EventManager.instance.hPCost));
        }
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
        if (EraChanged() && !isEvent)
        {
            rateText.SetText(GameManager.instance.baseHP.ToString() + " HP");
            costText.SetText(GameManager.instance.RoundedNum(GameManager.instance.hPCost));
        }
        else if (EraChanged() && isEvent)
        {
            rateText.SetText(EventManager.instance.baseHP.ToString() + " HP");
            costText.SetText(GameManager.instance.RoundedNum(EventManager.instance.hPCost));
        }
    }

    public void BuyHP()
    {
        if (IsActive() && !isEvent)
        {
            GameManager.instance.BuyHP();
            costText.SetText(GameManager.instance.RoundedNum(GameManager.instance.hPCost));
            rateText.SetText(GameManager.instance.baseHP.ToString() + " HP");
            CheckActive();
        }
        if (IsActive() && isEvent)
        {
            EventManager.instance.BuyHP();
            costText.SetText(GameManager.instance.RoundedNum(EventManager.instance.hPCost));
            rateText.SetText(EventManager.instance.baseHP.ToString() + " HP");
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
        if (!isEvent)
        {
            costText.SetText(GameManager.instance.RoundedNum(GameManager.instance.hPCost));
            rateText.SetText(GameManager.instance.baseHP.ToString() + " HP");
        }
        else
        {
            costText.SetText(GameManager.instance.RoundedNum(EventManager.instance.hPCost));
            rateText.SetText(EventManager.instance.baseHP.ToString() + " HP");
        }
    }

    private bool IsActive()
    {
        if (!isEvent)
        {
            if (GameManager.instance.gold >= GameManager.instance.hPCost)
                return true;
            else
                return false;
        }
        else
        {
            if (EventManager.instance.gold >= EventManager.instance.hPCost)
                return true;
            else
                return false;
        }

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
        if (!isEvent)
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
        else
        {
            currentEra = EventManager.instance.playerEra;
            if (currentEra == previousEra)
                return false;
            else
            {
                previousEra = currentEra;
                return true;
            }
        }
    }
}
