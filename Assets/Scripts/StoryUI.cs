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
    private Transform topUI;

    [SerializeField]
    private GameObject cardsMenu;
    [SerializeField]
    private GameObject storeMenu;
    private TOWMenu towMenu;

    public bool isEvent;
    // Start is called before the first frame update
    void Start()
    {
        topUI = gameObject.transform.Find("TopBG").transform;
        var offsetUI = topUI.localPosition + GameManager.instance.topUIoffset;
        topUI.localPosition = offsetUI;
        baseMenu = GameObject.Find("Base Menu");
        store = transform.Find("Store").gameObject;
        if (!isEvent)
        SetGoldText(GameManager.instance.gold);
        else
        SetGoldText(EventManager.instance.gold);
        SetDiamondText(GameManager.instance.diamonds);
        towMenu = GameObject.Find("TOW").GetComponent<TOWMenu>();
        ManageEra();
        
    }

    public void SetGoldText(int amount)
    {
        goldText.SetText(GameManager.instance.RoundedNum(amount));
    }
    public void SetDiamondText(int amount)
    {
        diamondText.SetText(amount.ToString());
    }
    public void Play()
    {
        GameManager.instance.LevelSelect(6);
    }
    public void EventPlay()
    {
        GameManager.instance.LevelSelect(7);
    }
    public void EventMenu()
    {
        GameManager.instance.LevelSelect(1);
    }

    public void BackToMenu()
    {
        GameManager.instance.BackToMenu();
    }
    public void BackToStory()
    {
        GameManager.instance.LevelSelect(0);
    }
    //public void ActivateStore()
    //{
    //    baseMenu.SetActive(false);
    //    store.SetActive(true);
    //}
    public void ActivateBaseMenu()
    {
        DeactivateMenus();
        towMenu.gameObject.SetActive(true);
        baseMenu.SetActive(true);
    }
    public void ActivateCardsMenu()
    {
        DeactivateMenus();
        cardsMenu.SetActive(true);
    }
    public void ActivateStoreMenu()
    {
        DeactivateMenus();
        storeMenu.SetActive(true);
    }

    public void NextEra()
    {
        SetTimeLineText();
        towMenu.SetTheScene();
        if (!isEvent)
        {
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
        else
        {
            if (EventManager.instance.playerEra == 0)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
                SetGoldText(EventManager.instance.gold);
            }
            else if (EventManager.instance.playerEra == 1)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
                SetGoldText(EventManager.instance.gold);
            }
            else if (EventManager.instance.playerEra == 2)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
                SetGoldText(EventManager.instance.gold);
            }
            else if (EventManager.instance.playerEra == 3)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
                SetGoldText(EventManager.instance.gold);
            }
            else if (EventManager.instance.playerEra == 4)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
                SetGoldText(EventManager.instance.gold);
            }
            else if (EventManager.instance.playerEra == 5)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(true);
                SetGoldText(EventManager.instance.gold);
            }
        }

    }
    private void ManageEra()
    {
        SetTimeLineText();
        towMenu.SetTheScene();
        if (!isEvent)
        {
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
        else
        {
            if (EventManager.instance.playerEra == 0)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            }
            else if (EventManager.instance.playerEra == 1)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            }
            else if (EventManager.instance.playerEra == 2)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            }
            else if (EventManager.instance.playerEra == 3)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            }
            else if (EventManager.instance.playerEra == 4)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(true);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(false);
            }
            else if (EventManager.instance.playerEra == 5)
            {
                baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 3").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 4").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 5").gameObject.SetActive(false);
                baseMenu.transform.Find("Era 6").gameObject.SetActive(true);
            }
        }
    }

    private void SetTimeLineText()
    {
        if (!isEvent)
        TimeLineText.SetText("timeline " + (GameManager.instance.timeLine + 1) + " era " + (GameManager.instance.playerEra + 1));
        else
            TimeLineText.SetText("timeline " + (EventManager.instance.timeLine + 1) + " era " + (EventManager.instance.playerEra + 1));
    }

    private void DeactivateMenus()
    {
        baseMenu.SetActive(false);
        cardsMenu.SetActive(false);
        storeMenu.SetActive(false);
        towMenu.gameObject.SetActive(false);
    }
}
