using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI diamondText;
    [SerializeField]
    private TextMeshProUGUI TimeLineText;
    private GameObject baseMenu;
    private GameObject store;

    // Start is called before the first frame update
    void Start()
    {
        
        baseMenu = GameObject.Find("Base Menu");
        store = transform.Find("Store").gameObject;
        SetGoldText(GameManager.instance.gold);
        SetDiamondText(GameManager.instance.diamonds);
        ManageEra();
        
    }

    public void SetGoldText(int amount)
    {
        goldText.SetText(amount.ToString());
    }
    public void SetDiamondText(int amount)
    {
        diamondText.SetText(amount.ToString());
    }
    public void Play()
    {
        GameManager.instance.LevelSelect(6);
    }

    public void BackToMenu()
    {
        GameManager.instance.BackToMenu();
    }
    public void ActivateStore()
    {
        baseMenu.SetActive(false);
        store.SetActive(true);
    }
    public void ActivateBaseMenu()
    {
        store.SetActive(false);
        baseMenu.SetActive(true);
    }

    public void NextEra()
    {
        SetTimeLineText();
        if (GameManager.instance.playerEra == 0)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            SetGoldText(GameManager.instance.gold);
        }
        else if (GameManager.instance.playerEra == 1)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            SetGoldText(GameManager.instance.gold);
        }
        else if (GameManager.instance.playerEra == 2)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            SetGoldText(GameManager.instance.gold);
        }
        else if (GameManager.instance.playerEra == 3)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            SetGoldText(GameManager.instance.gold);
        }
        else if (GameManager.instance.playerEra == 4)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            SetGoldText(GameManager.instance.gold);
        }
        else if (GameManager.instance.playerEra == 5)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(true);
            SetGoldText(GameManager.instance.gold);
        }

    }
    private void ManageEra()
    {
        SetTimeLineText();
        if (GameManager.instance.playerEra == 0)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
        }
        else if (GameManager.instance.playerEra == 1)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
        }
        else if (GameManager.instance.playerEra == 2)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
        }
        else if (GameManager.instance.playerEra == 3)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
        }
        else if (GameManager.instance.playerEra == 4)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
        }
        else if (GameManager.instance.playerEra == 5)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 6").gameObject.SetActive(true);
        }
    }

    private void SetTimeLineText()
    {
        TimeLineText.SetText("timeline " + (GameManager.instance.timeLine + 1) + " era " + (GameManager.instance.playerEra + 1));
    }

}
