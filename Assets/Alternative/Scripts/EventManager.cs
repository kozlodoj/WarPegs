using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static EventManager instance = null;

    public float reloadRate = 5;
    public float reloadPerSec = 0.06f;
    public int baseHP;

    public bool isUnitTwoActive = false;
    public bool isUnitThreeActive = false;
    public int unitTwoCost = 1000;
    public int unitThreeCost = 5000;

    public int reloadCost;
    public int hPCost;

    public int playerEra;
    public int playerEraCount;
    public int enemyEra;
    public int evolveCost;
    public bool canNextTimeline = false;

    public int timeLine;
    public float timeLineModifier = 1f;

    public int gold;
    public int currentGold;

    private SaveScript save;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        save = gameObject.GetComponent<SaveScript>();
        save.NewEventFile();
        save.LoadEvent();

        SetReloadTime();
    }
    public void AddGold(int amount)
    {
        SaveEvent();
        gold += amount;
        currentGold += amount;
        if (SceneManager.GetActiveScene().name == "Event Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetGoldText(gold);
        }
        else
            GameObject.Find("UI").GetComponent<UIScript>().SetCollectedGold(currentGold);
    }
    public void BuyUnit(int num)
    {
        SaveEvent();
        //buy unit 1
        if (num == 2 && !isUnitTwoActive)
        {
            AddGold(-unitTwoCost);
            isUnitTwoActive = true;
        }
        //buy unit 2
        else if (num == 3 && !isUnitThreeActive)
        {
            AddGold(-unitThreeCost);
            isUnitThreeActive = true;
        }
        //evolve
        else if (num == 4)
        {

            gold = 0;
            playerEra++;
            enemyEra = 0;
            NextEra();

        }
        else if (num == 5)
        {

            NextTimeLine();

        }
    }
    public void NextEra()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 1)
        {
            GameObject.Find("UI").GetComponent<StoryUI>().NextEra();
        }
        //deactivate unit 2 & 3
        isUnitTwoActive = false;
        isUnitThreeActive = false;
        gold = 0;
        reloadPerSec = 0.06f;
        SetReloadTime();
        //set costs
        if (playerEra == 0)
        {
            reloadCost = 9;
            hPCost = 30;
            unitTwoCost = 150;
            unitThreeCost = 400;
            evolveCost = 2000;
            baseHP = 2;

        }
        else if (playerEra == 1)
        {
            reloadCost = 230;
            hPCost = 680;
            unitTwoCost = 3500;
            unitThreeCost = 10500;
            evolveCost = 21000;
            baseHP = 15;

        }
        else if (playerEra == 2)
        {
            reloadCost = 2300;
            hPCost = 6800;
            unitTwoCost = 35000;
            unitThreeCost = 105000;
            evolveCost = 160000;
            baseHP = 40;

        }
        else if (playerEra == 3)
        {
            reloadCost = 14000;
            hPCost = 43000;
            unitTwoCost = 222000;
            unitThreeCost = 666000;
            evolveCost = 1175000;
            baseHP = 150;
        }
        else if (playerEra == 4)
        {
            reloadCost = 95000;
            hPCost = 285000;
            unitTwoCost = 1450000;
            unitThreeCost = 4300000;
            evolveCost = 8400000;
            baseHP = 450;

        }
        else if (playerEra == 5)
        {
            reloadCost = 650000;
            hPCost = 2000000;
            unitTwoCost = 10000000;
            unitThreeCost = 30000000;
            evolveCost = 93000000;
            baseHP = 1200;

        }
        SaveEvent();

    }
    public void NextTimeLine()
    {
        timeLine++;
        timeLineModifier *= 1.1f;
        playerEra = 0;
        enemyEra = 0;
        NextEra();
        canNextTimeline = false;

    }
    private void SetReloadTime()
    {
        reloadRate = 1 / reloadPerSec;
    }
    public void BuyReloadTime()
    {
        SaveEvent();
        reloadPerSec += 0.005f;
        reloadRate = 1 / reloadPerSec;
        AddGold(-reloadCost);
        reloadCost = (int)(reloadCost * 1.2f);
    }
    public void BuyHP()
    {
        SaveEvent();
        if (playerEra == 0)
        {
            baseHP = (int)(baseHP + 1);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);
        }
        else if (playerEra == 1)
        {
            baseHP = (int)(baseHP + 15);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 2)
        {
            baseHP = (int)(baseHP + 40);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 3)
        {
            baseHP = (int)(baseHP + 150);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 4)
        {
            baseHP = (int)(baseHP + 450);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
        else if (playerEra == 5)
        {
            baseHP = (int)(baseHP + 1200);
            AddGold(-hPCost);
            hPCost = (int)(hPCost * 1.2f);

        }
    }
    public void NewEvent()
    {
        save.LoadNewEvent();
    }
    public void SaveEvent()
    {
        save.SaveEvent();
    }

}
