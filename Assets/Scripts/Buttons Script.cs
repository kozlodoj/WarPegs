using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    //public float power = 5;
    public float reload = 5f;
    public float buff = 5;
    public float respawn = 5;
    //public float initialStat = 100;
    //public float archerCost;
    //public float tankCost;
    //public float reloadCost;
    //public float hpCost;
    public float gold;
    public float diamonds;
    //public float initialBallCharge;
    //public float buffCost;
    //public float perkOneRecharge;
    //public float perkTwoRecharge;
    //public bool isRandom;
    //public bool isReactivateActive;
    public int playerEra;
    public int enemyEra;
    public int timeline;
    public int specialPegs;
    public int feverBounces;

    //[SerializeField]
    //private TextMeshProUGUI powerText;
    [SerializeField]
    private TextMeshProUGUI reloadText;
    [SerializeField]
    private TextMeshProUGUI buffText;
    [SerializeField]
    private TextMeshProUGUI respawnText;
    //[SerializeField]
    //private TextMeshProUGUI initialStatText;
    //[SerializeField]
    //private Toggle randomToggle;
    //[SerializeField]
    //private Toggle reactivateToggle;
    //[SerializeField]
    //private TextMeshProUGUI archerCostText;
    //[SerializeField]
    //private TextMeshProUGUI tankCostText;
    //[SerializeField]
    //private TextMeshProUGUI reloadCostText;
    //[SerializeField]
    //private TextMeshProUGUI hpCostText;
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI diamondsText;
    //[SerializeField]
    //private TextMeshProUGUI firstBallChargeText;
    //[SerializeField]
    //private TextMeshProUGUI buffCostText;
    //[SerializeField]
    //private TextMeshProUGUI perkOneRechargeText;
    //[SerializeField]
    //private TextMeshProUGUI perkTwoRechargeText;
    [SerializeField]
    private TextMeshProUGUI playerEraText;
    [SerializeField]
    private TextMeshProUGUI enemyEraText;
    [SerializeField]
    private TextMeshProUGUI timelineText;
    [SerializeField]
    private TextMeshProUGUI specialPegsText;
    [SerializeField]
    private TextMeshProUGUI feverBouncesText;


    public int playerEraEvent;
    public int enemyEraEvent;
    public int timelineEvent;
    public float reloadEvent;
    public float goldEvent;

    [SerializeField]
    private TextMeshProUGUI playerEraTextEvent;
    [SerializeField]
    private TextMeshProUGUI enemyEraTextEvent;
    [SerializeField]
    private TextMeshProUGUI timelineTextEvent;
    [SerializeField]
    private TextMeshProUGUI reloadTextEvent;
    [SerializeField]
    private TextMeshProUGUI goldTextEvent;


    [SerializeField]
    private GameObject storyDebug;
    [SerializeField]
    private GameObject eventDebug;
    private void Start()
    {
        UpdateStats();
    }

    public void LoadLevel(int level)
    {
        GameManager.instance.LevelSelect(level);
    }

    //public void PowerMinus()
    //{
    //    power--;
    //    powerText.SetText(power.ToString());
    //    GameManager.instance.ballPower = power;
    //}
    //public void PowerPlus()
    //{
    //    power++;
    //    powerText.SetText(power.ToString());
    //    GameManager.instance.ballPower = power;
    //}
    public void ReloadMinus()
    {
        reload -= 0.005f;
        reloadText.SetText(reload.ToString("0.000"));
        GameManager.instance.reloadPerSec = reload;
    }
    public void ReloadPlus()
    {
        reload += 0.005f;
        reloadText.SetText(reload.ToString("0.000"));
        GameManager.instance.reloadPerSec = reload;
    }
    public void ReloadEventMinus()
    {
        reloadEvent -= 0.005f;
        reloadTextEvent.SetText(reloadEvent.ToString("0.000"));
        EventManager.instance.reloadPerSec = reloadEvent;
    }
    public void ReloadEventPlus()
    {
        reloadEvent += 0.005f;
        reloadTextEvent.SetText(reloadEvent.ToString("0.000"));
        EventManager.instance.reloadPerSec = reloadEvent;
    }
    public void BuffMinus()
    {
        buff--;
        buffText.SetText(buff.ToString());
        GameManager.instance.buff = buff;
    }
    public void BuffPlus()
    {
        buff++;
        buffText.SetText(buff.ToString());
        GameManager.instance.buff = buff;
    }
    public void RespawnPegMinus()
    {
        respawn--;
        respawnText.SetText(respawn.ToString());
        GameManager.instance.respawn = respawn;
    }
    public void RespawnPegPlus()
    {
        respawn++;
        respawnText.SetText(respawn.ToString());
        GameManager.instance.respawn = respawn;
    }
    //public void ArcherCostPlus()
    //{
    //    archerCost += 50;
    //    archerCostText.SetText(archerCost.ToString());
    //    GameManager.instance.unitTwoCost = (int)archerCost;
    //}
    //public void ArcherCostMinus()
    //{
    //    archerCost -= 50;
    //    archerCostText.SetText(archerCost.ToString());
    //    GameManager.instance.unitTwoCost = (int)archerCost;
    //}
    //public void TankCostPlus()
    //{
    //    tankCost += 50;
    //    tankCostText.SetText(tankCost.ToString());
    //    GameManager.instance.unitThreeCost = (int)tankCost;
    //}
    //public void TankCostMinus()
    //{
    //    tankCost -= 50;
    //    tankCostText.SetText(tankCost.ToString());
    //    GameManager.instance.unitThreeCost = (int)tankCost;
    //}
    //public void ReloadCostPlus()
    //{
    //    reloadCost += 10;
    //    reloadCostText.SetText(reloadCost.ToString());
    //    GameManager.instance.reloadCost = (int)reloadCost;
    //}
    //public void ReloadCostMinus()
    //{
    //    reloadCost -= 10;
    //    reloadCostText.SetText(reloadCost.ToString());
    //    GameManager.instance.reloadCost = (int)reloadCost;
    //}
    //public void HPcostPlus()
    //{
    //    hpCost += 10;
    //    hpCostText.SetText(hpCost.ToString());
    //    GameManager.instance.hPCost = (int)hpCost;
    //}
    //public void HPcostMinus()
    //{
    //    hpCost -= 10;
    //    hpCostText.SetText(hpCost.ToString());
    //    GameManager.instance.hPCost = (int)hpCost;
    //}

    //public void InitialStatPlus()
    //{
    //    initialStat += 5f;
    //    initialStatText.SetText(initialStat.ToString());
    //    GameManager.instance.intialStat = initialStat;
    //}

    //public void InitialStatMinus()
    //{
    //    initialStat -= 5f;
    //    initialStatText.SetText(initialStat.ToString());
    //    GameManager.instance.intialStat = initialStat;

    //}

    public void GoldMinus()
    {
        gold -= 1000f;
        goldText.SetText(gold.ToString());
        GameManager.instance.gold = (int)gold;

    }

    public void GoldPlus()
    {
        gold += 1000f;
        goldText.SetText(gold.ToString());
        GameManager.instance.gold = (int)gold;
    }
    public void GoldEventMinus()
    {
        goldEvent -= 1000f;
        goldTextEvent.SetText(goldEvent.ToString());
        EventManager.instance.gold = (int)goldEvent;

    }

    public void GoldEventPlus()
    {
        goldEvent += 1000f;
        goldTextEvent.SetText(goldEvent.ToString());
        EventManager.instance.gold = (int)goldEvent;
    }

    //public void chargeMinus()
    //{
    //    initialBallCharge -= 10;
    //    firstBallChargeText.SetText(initialBallCharge.ToString() + "%");
    //    GameManager.instance.initialBallCharge = initialBallCharge;
    //}
    //public void chargePlus()
    //{
    //    initialBallCharge += 10;
    //    firstBallChargeText.SetText(initialBallCharge.ToString() + "%");
    //    GameManager.instance.initialBallCharge = initialBallCharge;
    //}

    //public void BuffCostMinus()
    //{
    //    buffCost -= 50;
    //    buffCostText.SetText(buffCost.ToString());
    //    GameManager.instance.buffCost = (int)buffCost;
    //}
    //public void BuffCostPlus()
    //{
    //    buffCost += 50;
    //    buffCostText.SetText(buffCost.ToString());
    //    GameManager.instance.buffCost = (int)buffCost;
    //}

    public void DiamondsMinus()
    {
        diamonds -= 50;
        diamondsText.SetText(diamonds.ToString());
        GameManager.instance.diamonds = (int)diamonds;
    }

    public void DiamondsPlus()
    {
        diamonds += 50;
        diamondsText.SetText(diamonds.ToString());
        GameManager.instance.diamonds = (int)diamonds;
    }

    //public void perkOneRechargeMinus()
    //{
    //    perkOneRecharge -= 5f;
    //    perkOneRechargeText.SetText(perkOneRecharge.ToString());
    //    GameManager.instance.perkOneRecharge = perkOneRecharge;
    //}
    //public void perkOneRechargePlus()
    //{
    //    perkOneRecharge += 5f;
    //    perkOneRechargeText.SetText(perkOneRecharge.ToString());
    //    GameManager.instance.perkOneRecharge = perkOneRecharge;
    //}
    //public void perkTwoRechargeMinus()
    //{
    //    perkTwoRecharge -= 5f;
    //    perkTwoRechargeText.SetText(perkTwoRecharge.ToString());
    //    GameManager.instance.perkTwoRecharge = perkTwoRecharge;
    //}
    //public void perkTwoRechargePlus()
    //{
    //    perkTwoRecharge += 5f;
    //    perkTwoRechargeText.SetText(perkTwoRecharge.ToString());
    //    GameManager.instance.perkTwoRecharge = perkTwoRecharge;
    //}
    public void playerEraPlus()
    {
        if (playerEra < 5)
        {
            playerEra++;
            playerEraText.SetText(playerEra.ToString());
            GameManager.instance.playerEra = playerEra;
            GameManager.instance.NextEra();
        }
    }
    public void playerEraMinus()
    {
        if (playerEra > 0)
        {
            playerEra--;
            playerEraText.SetText(playerEra.ToString());
            GameManager.instance.playerEra = playerEra;
            GameManager.instance.NextEra();
        }
    }
    public void playerEraEventPlus()
    {
        if (playerEraEvent < 5)
        {
            playerEraEvent++;
            playerEraTextEvent.SetText(playerEraEvent.ToString());
            EventManager.instance.playerEra = playerEraEvent;
            EventManager.instance.NextEra();
        }
    }
    public void playerEraEventMinus()
    {
        if (playerEraEvent > 0)
        {
            playerEraEvent--;
            playerEraTextEvent.SetText(playerEraEvent.ToString());
            EventManager.instance.playerEra = playerEraEvent;
            EventManager.instance.NextEra();
        }
    }
    public void enemyEraPlus()
    {
        if (enemyEra < 5)
        {
            enemyEra++;
            enemyEraText.SetText(enemyEra.ToString());
            GameManager.instance.enemyEra = enemyEra;
        }
    }
    public void enemyEraMinus()
    {
        if (enemyEra > 0)
        {
            enemyEra--;
            enemyEraText.SetText(enemyEra.ToString());
            GameManager.instance.enemyEra = enemyEra;
        }
    }
    public void enemyEraEventPlus()
    {
        if (enemyEraEvent < 5)
        {
            enemyEraEvent++;
            enemyEraTextEvent.SetText(enemyEraEvent.ToString());
            EventManager.instance.enemyEra = enemyEraEvent;
        }
    }
    public void enemyEraEventMinus()
    {
        if (enemyEraEvent > 0)
        {
            enemyEraEvent--;
            enemyEraTextEvent.SetText(enemyEraEvent.ToString());
            EventManager.instance.enemyEra = enemyEraEvent;
        }
    
    }
    public void timelinePlus()
    {
            timeline++;
            GameManager.instance.timeLineModifier *= 1.1f;
            timelineText.SetText(timeline.ToString());
            GameManager.instance.timeLine = timeline;
    }
    public void timelineMinus()
    {
        if (timeline > 0)
        {
            timeline--;
            GameManager.instance.timeLineModifier /= 1.1f;
            timelineText.SetText(timeline.ToString());
            GameManager.instance.timeLine = timeline;
        }
    }

    public void timelineEventPlus()
    {
        timelineEvent++;
        EventManager.instance.timeLineModifier *= 1.1f;
        timelineTextEvent.SetText(timelineEvent.ToString());
        EventManager.instance.timeLine = timelineEvent;
    }
    public void timelineEventMinus()
    {
        if (timelineEvent > 0)
        {
            timelineEvent--;
            EventManager.instance.timeLineModifier /= 1.1f;
            timelineTextEvent.SetText(timelineEvent.ToString());
            EventManager.instance.timeLine = timelineEvent;
        }
    }

    public void SpecialPegsPlus()
    {
        if (specialPegs < 8)
        {
            specialPegs++;
            GameManager.instance.numberOfSpecialPegs++;
            specialPegsText.SetText(specialPegs.ToString());
        }
    }
    public void SpecialPegsMinus()
    {
        if (specialPegs > 0)
        {
            specialPegs--;
            GameManager.instance.numberOfSpecialPegs--;
            specialPegsText.SetText(specialPegs.ToString());
        }
    }
    public void FeverBouncesPlus()
    {
        feverBounces++;
        GameManager.instance.feverBounces++;
        feverBouncesText.SetText(feverBounces.ToString());
    }
    public void FeverBouncesMinus()
    {
        if (feverBounces > 0)
        {
            feverBounces--;
            GameManager.instance.feverBounces--;
            feverBouncesText.SetText(feverBounces.ToString());
        }
    }
    private void UpdateStats()
    {
        //power = GameManager.instance.ballPower;
        reload = GameManager.instance.reloadPerSec;
        buff = GameManager.instance.buff;
        respawn = GameManager.instance.respawn;
        //initialStat = GameManager.instance.intialStat;
        //isRandom = GameManager.instance.randomSpawn;
        //isReactivateActive = GameManager.instance.reactivatePegsOnSpawn;
        //archerCost = GameManager.instance.unitTwoCost;
        //tankCost = GameManager.instance.unitThreeCost;
        //reloadCost = GameManager.instance.reloadCost;
        //hpCost = GameManager.instance.hPCost;
        gold = GameManager.instance.gold;
        diamonds = GameManager.instance.diamonds;
        //initialBallCharge = GameManager.instance.initialBallCharge;
        //buffCost = GameManager.instance.buffCost;
        //perkOneRecharge = GameManager.instance.perkOneRecharge;
        //perkTwoRecharge = GameManager.instance.perkTwoRecharge;
        playerEra = GameManager.instance.playerEra;
        enemyEra = GameManager.instance.enemyEra;
        timeline = GameManager.instance.timeLine;
        specialPegs = GameManager.instance.numberOfSpecialPegs;
        feverBounces = GameManager.instance.feverBounces;
        playerEraEvent = EventManager.instance.playerEra;
        enemyEraEvent = EventManager.instance.enemyEra;
        timelineEvent = EventManager.instance.timeLine;
        reloadEvent = EventManager.instance.reloadPerSec;
        goldEvent = EventManager.instance.gold;

        //powerText.SetText(power.ToString());
        reloadText.SetText(reload.ToString());
        buffText.SetText(buff.ToString());
        respawnText.SetText(respawn.ToString());
        //initialStatText.SetText(initialStat.ToString());
        //archerCostText.SetText(archerCost.ToString());
        //tankCostText.SetText(tankCost.ToString());
        //reloadCostText.SetText(reloadCost.ToString());
        //hpCostText.SetText(hpCost.ToString());
        goldText.SetText(gold.ToString());
        diamondsText.SetText(diamonds.ToString());
        //firstBallChargeText.SetText(initialBallCharge.ToString() + "%");
        //buffCostText.SetText(buffCost.ToString());
        //perkOneRechargeText.SetText(perkOneRecharge.ToString());
        //perkTwoRechargeText.SetText(perkTwoRecharge.ToString());
        //randomToggle.isOn = isRandom;
        //reactivateToggle.isOn = isReactivateActive;
        playerEraText.SetText(playerEra.ToString());
        enemyEraText.SetText(enemyEra.ToString());
        timelineText.SetText(timeline.ToString());
        specialPegsText.SetText(specialPegs.ToString());
        feverBouncesText.SetText(feverBounces.ToString());
        playerEraTextEvent.SetText(playerEraEvent.ToString());
        enemyEraTextEvent.SetText(enemyEraEvent.ToString());
        timelineTextEvent.SetText(timelineEvent.ToString());
        reloadTextEvent.SetText(reloadEvent.ToString());
        goldTextEvent.SetText(goldEvent.ToString());
    }

    public void RandomSpawn(bool isTrue)
    {
        GameManager.instance.randomSpawn = isTrue;
    }

    public void ReactivatePegs(bool isTrue)
    {
        GameManager.instance.reactivatePegsOnSpawn = isTrue;
    }

    public void NewGame()
    {
        GameManager.instance.NewGame();
    }
    public void DeleteSave()
    {

        GameManager.instance.DeleteSave();
    }
    public void ActivateStoryDebug()
    {
        storyDebug.SetActive(true);
        eventDebug.SetActive(false);
    }
    public void ActivateEventDebug()
    {
        storyDebug.SetActive(false);
        eventDebug.SetActive(true);
    }
}
