using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BaseHPButton : MonoBehaviour
{
    private TextMeshProUGUI costText;
    private TextMeshProUGUI rateText;

    private Color theColor;

    // Start is called before the first frame update
    void Start()
    {
        theColor = gameObject.GetComponent<Image>().color;
        
        costText = transform.Find("Cost Text").gameObject.GetComponent<TextMeshProUGUI>();
        rateText = transform.Find("HPText").gameObject.GetComponent<TextMeshProUGUI>();
        rateText.SetText(GameManager.instance.reloadRate.ToString() + " HP");
        costText.SetText(GameManager.instance.reloadCost.ToString());
        CheckActive();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsActive())
            NotEnoughMoney();
    }

    public void BuyHP()
    {
        if (IsActive())
        {
            GameManager.instance.BuyHP();
            costText.SetText(GameManager.instance.hPCost.ToString());
            rateText.SetText(GameManager.instance.baseHP.ToString() + " HP");
            CheckActive();
        }
    }

    private void SetActive()
    {
        theColor.a = 1f;
        gameObject.GetComponent<Image>().color = theColor;
        gameObject.GetComponent<Button>().enabled = true;
    }
    private void NotEnoughMoney()
    {
        theColor.a = 0.1f;
        gameObject.GetComponent<Button>().enabled = false;
        gameObject.GetComponent<Image>().color = theColor;
    }

    private bool IsActive()
    {
        if (GameManager.instance.gold >= GameManager.instance.hPCost)
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
