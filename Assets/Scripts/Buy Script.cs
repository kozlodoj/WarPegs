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

    private bool isActive = false;

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
        if (cost <= GameManager.instance.gold && !isActive)
        {
            GameManager.instance.BuyUnit(unitNum);
            SetActive();

        }
    }
    private void SetActive()
    {
        unitImage.color = theColor;
        priceText.SetActive(false);
        goldImage.gameObject.SetActive(false);
        isActive = true;
    }

    private void CheckActive()
    {
        if (unitNum == 2 && GameManager.instance.isUnitTwoActive)
            SetActive();
        else if (unitNum == 3 && GameManager.instance.isUnitThreeActive)
            SetActive();
        if (cost >= GameManager.instance.gold && !isActive)
        {
            priceText.GetComponent<TextMeshProUGUI>().color = transparentTextColor;
            goldImage.color = trGoldColor;
        }
        if (cost <= GameManager.instance.gold && !isActive)
        {
            priceText.GetComponent<TextMeshProUGUI>().color = textColor;
            goldImage.color = goldColor;
        }
    }
    private void SetPrice()
    {
        if (unitNum == 2)
        {
            cost = GameManager.instance.unitTwoCost;
            priceText.GetComponent<TextMeshProUGUI>().SetText(cost.ToString());
        }
        else if (unitNum == 3)
        {
            cost = GameManager.instance.unitThreeCost;
            priceText.GetComponent<TextMeshProUGUI>().SetText(cost.ToString());
        }
        else if (unitNum == 4)
        {
            cost = GameManager.instance.evolveCost;
            priceText.GetComponent<TextMeshProUGUI>().SetText(cost.ToString());
        }
    }
}
