using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyScript : MonoBehaviour
{
    [SerializeField]
    private int cost;

    private Image unitImage;
    private Image goldImage;
    private Color theColor;
    private Color textColor;
    private Color transparentTextColor;
    private Color goldColor;
    private Color trGoldColor;
    private GameObject priceText;
    [SerializeField]
    private int unitNum;
    [SerializeField]
    private bool isActive = false;

    public bool isEvent;

    // Start is called before the first frame update
    void Start()
    {
        priceText = gameObject.transform.Find("Price").gameObject;
        goldImage = gameObject.transform.Find("gold").gameObject.GetComponent<Image>();
        SetPrice();
        unitImage = gameObject.GetComponent<Image>();
        theColor = unitImage.color;
        theColor.a = 1;
        textColor = priceText.GetComponent<TextMeshProUGUI>().color;
        transparentTextColor = textColor;
        transparentTextColor.a = 0.2f;
        goldColor = goldImage.color;
        trGoldColor = goldColor;
        trGoldColor.a = 0.1f;

        CheckActive();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isActive)
        CheckActive();
    }

    public void Buy()
    {
        if (!isEvent)
        {
            if (cost <= GameManager.instance.gold && !isActive)
            {
                GameManager.instance.BuyUnit(unitNum);
                SetActive();

            }
            else if (unitNum == 5 && isActive)
                GameManager.instance.BuyUnit(unitNum);
            if (isActive && unitNum == 4 || unitNum == 5)
                isActive = false;
        }
        else
        {
            if (cost <= EventManager.instance.gold && !isActive)
            {
                EventManager.instance.BuyUnit(unitNum);
                SetActive();

            }
            else if (unitNum == 5 && isActive)
                EventManager.instance.BuyUnit(unitNum);
            if (isActive && unitNum == 4 || unitNum == 5)
                isActive = false;
        }

    }
    private void SetActive()
    {
        unitImage.color = theColor;
        priceText.SetActive(false);
        goldImage.gameObject.SetActive(false);
        isActive = true;
        if (unitNum == 5)
        {
            priceText.GetComponent<TextMeshProUGUI>().color = Color.black;
            priceText.GetComponent<TextMeshProUGUI>().SetText("GO");
            priceText.SetActive(true);
        }
    }

    private void CheckActive()
    {
        if (!isEvent)
        {
            if (unitNum == 2 && GameManager.instance.isUnitTwoActive)
                SetActive();
            else if (unitNum == 3 && GameManager.instance.isUnitThreeActive)
                SetActive();
            if (unitNum == 5 && GameManager.instance.canNextTimeline)
                SetActive();
            if (unitNum == 4)
                SetPrice();
            if (cost >= GameManager.instance.gold && !isActive && unitNum != 5)
            {
                priceText.GetComponent<TextMeshProUGUI>().color = transparentTextColor;
                goldImage.color = trGoldColor;
            }
            if (cost <= GameManager.instance.gold && !isActive && unitNum != 5)
            {
                priceText.GetComponent<TextMeshProUGUI>().color = textColor;
                goldImage.color = goldColor;
            }
        }
        else
        {
            if (unitNum == 2 && EventManager.instance.isUnitTwoActive)
                SetActive();
            else if (unitNum == 3 && EventManager.instance.isUnitThreeActive)
                SetActive();
            if (unitNum == 5 && EventManager.instance.canNextTimeline)
                SetActive();
            if (unitNum == 4)
                SetPrice();
            if (cost >= EventManager.instance.gold && !isActive && unitNum != 5)
            {
                priceText.GetComponent<TextMeshProUGUI>().color = transparentTextColor;
                goldImage.color = trGoldColor;
            }
            if (cost <= EventManager.instance.gold && !isActive && unitNum != 5)
            {
                priceText.GetComponent<TextMeshProUGUI>().color = textColor;
                goldImage.color = goldColor;
            }
        }
    }
    private void SetPrice()
    {
        if (!isEvent)
        {
            if (unitNum == 2)
            {
                cost = GameManager.instance.unitTwoCost;
                priceText.GetComponent<TextMeshProUGUI>().SetText(GameManager.instance.RoundedNum(cost));
            }
            else if (unitNum == 3)
            {
                cost = GameManager.instance.unitThreeCost;
                priceText.GetComponent<TextMeshProUGUI>().SetText(GameManager.instance.RoundedNum(cost));
            }
            else if (unitNum == 4)
            {
                cost = GameManager.instance.evolveCost;
                priceText.GetComponent<TextMeshProUGUI>().SetText(GameManager.instance.RoundedNum(cost));
            }
            else if (unitNum == 5)
            {
                priceText.GetComponent<TextMeshProUGUI>().SetText("Win");
            }
        }
        else
        {
            if (unitNum == 2)
            {
                cost = EventManager.instance.unitTwoCost;
                priceText.GetComponent<TextMeshProUGUI>().SetText(GameManager.instance.RoundedNum(cost));
            }
            else if (unitNum == 3)
            {
                cost = EventManager.instance.unitThreeCost;
                priceText.GetComponent<TextMeshProUGUI>().SetText(GameManager.instance.RoundedNum(cost));
            }
            else if (unitNum == 4)
            {
                cost = EventManager.instance.evolveCost;
                priceText.GetComponent<TextMeshProUGUI>().SetText(GameManager.instance.RoundedNum(cost));
            }
            else if (unitNum == 5)
            {
                priceText.GetComponent<TextMeshProUGUI>().SetText("Win");
            }
        }
    }
}
