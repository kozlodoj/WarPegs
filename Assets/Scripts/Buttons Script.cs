using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonsScript : MonoBehaviour
{
    public float power = 5;
    public float reload = 5f;
    public float buff = 5;
    public float respawn = 5;
    public float initialStat = 100;
    public float archerCost;
    public float tankCost;
    public float reloadCost;
    public float hpCost;
    public float gold;
    public bool isRandom;
    public bool isReactivateActive;

    [SerializeField]
    private TextMeshProUGUI powerText;
    [SerializeField]
    private TextMeshProUGUI reloadText;
    [SerializeField]
    private TextMeshProUGUI buffText;
    [SerializeField]
    private TextMeshProUGUI respawnText;
    [SerializeField]
    private TextMeshProUGUI initialStatText;
    [SerializeField]
    private Toggle randomToggle;
    [SerializeField]
    private Toggle reactivateToggle;
    [SerializeField]
    private TextMeshProUGUI archerCostText;
    [SerializeField]
    private TextMeshProUGUI tankCostText;
    [SerializeField]
    private TextMeshProUGUI reloadCostText;
    [SerializeField]
    private TextMeshProUGUI hpCostText;
    [SerializeField]
    private TextMeshProUGUI goldText;

    private void Start()
    {
        UpdateStats();
    }

    public void LoadLevel(int level)
    {
        GameManager.instance.LevelSelect(level);
    }

    public void PowerMinus()
    {
        power--;
        powerText.SetText(power.ToString());
        GameManager.instance.ballPower = power;
    }
    public void PowerPlus()
    {
        power++;
        powerText.SetText(power.ToString());
        GameManager.instance.ballPower = power;
    }
    public void ReloadMinus()
    {
        reload -= 0.5f;
        reloadText.SetText(reload.ToString());
        GameManager.instance.reloadRate = reload;
    }
    public void ReloadPlus()
    {
        reload += 0.5f;
        reloadText.SetText(reload.ToString());
        GameManager.instance.reloadRate = reload;
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
    public void ArcherCostPlus()
    {
        archerCost += 50;
        archerCostText.SetText(archerCost.ToString());
        GameManager.instance.unitTwoCost = (int)archerCost;
    }
    public void ArcherCostMinus()
    {
        archerCost -= 50;
        archerCostText.SetText(archerCost.ToString());
        GameManager.instance.unitTwoCost = (int)archerCost;
    }
    public void TankCostPlus()
    {
        tankCost += 50;
        tankCostText.SetText(tankCost.ToString());
        GameManager.instance.unitThreeCost = (int)tankCost;
    }
    public void TankCostMinus()
    {
        tankCost -= 50;
        tankCostText.SetText(tankCost.ToString());
        GameManager.instance.unitThreeCost = (int)tankCost;
    }
    public void ReloadCostPlus()
    {
        reloadCost += 10;
        reloadCostText.SetText(reloadCost.ToString());
        GameManager.instance.reloadCost = (int)reloadCost;
    }
    public void ReloadCostMinus()
    {
        reloadCost -= 10;
        reloadCostText.SetText(reloadCost.ToString());
        GameManager.instance.reloadCost = (int)reloadCost;
    }
    public void HPcostPlus()
    {
        hpCost += 10;
        hpCostText.SetText(hpCost.ToString());
        GameManager.instance.hPCost = (int)hpCost;
    }
    public void HPcostMinus()
    {
        hpCost -= 10;
        hpCostText.SetText(hpCost.ToString());
        GameManager.instance.hPCost = (int)hpCost;
    }

    public void InitialStatPlus()
    {
        initialStat += 5f;
        initialStatText.SetText(initialStat.ToString());
        GameManager.instance.intialStat = initialStat;
    }

    public void InitialStatMinus()
    {
        initialStat -= 5f;
        initialStatText.SetText(initialStat.ToString());
        GameManager.instance.intialStat = initialStat;

    }

    public void GoldMinus()
    {
        gold -= 100f;
        goldText.SetText(gold.ToString());
        GameManager.instance.gold = (int)gold;

    }

    public void GoldPlus()
    {
        gold += 100f;
        goldText.SetText(gold.ToString());
        GameManager.instance.gold = (int)gold;
    }

    private void UpdateStats()
    {
        power = GameManager.instance.ballPower;
        reload = GameManager.instance.reloadRate;
        buff = GameManager.instance.buff;
        respawn = GameManager.instance.respawn;
        initialStat = GameManager.instance.intialStat;
        isRandom = GameManager.instance.randomSpawn;
        isReactivateActive = GameManager.instance.reactivatePegsOnSpawn;
        archerCost = GameManager.instance.unitTwoCost;
        tankCost = GameManager.instance.unitThreeCost;
        reloadCost = GameManager.instance.reloadCost;
        hpCost = GameManager.instance.hPCost;
        gold = GameManager.instance.gold;

        powerText.SetText(power.ToString());
        reloadText.SetText(reload.ToString());
        buffText.SetText(buff.ToString());
        respawnText.SetText(respawn.ToString());
        initialStatText.SetText(initialStat.ToString());
        archerCostText.SetText(archerCost.ToString());
        tankCostText.SetText(tankCost.ToString());
        reloadCostText.SetText(reloadCost.ToString());
        hpCostText.SetText(hpCost.ToString());
        goldText.SetText(gold.ToString());
        randomToggle.isOn = isRandom;
        reactivateToggle.isOn = isReactivateActive;
    }

    public void RandomSpawn(bool isTrue)
    {
        GameManager.instance.randomSpawn = isTrue;
    }

    public void ReactivatePegs(bool isTrue)
    {
        GameManager.instance.reactivatePegsOnSpawn = isTrue;
    }
}
