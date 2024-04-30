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
    public bool isRandom;

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

    private void UpdateStats()
    {
        power = GameManager.instance.ballPower;
        reload = GameManager.instance.reloadRate;
        buff = GameManager.instance.buff;
        respawn = GameManager.instance.respawn;
        initialStat = GameManager.instance.intialStat;
        isRandom = GameManager.instance.randomSpawn;

        powerText.SetText(power.ToString());
        reloadText.SetText(reload.ToString());
        buffText.SetText(buff.ToString());
        respawnText.SetText(respawn.ToString());
        initialStatText.SetText(initialStat.ToString());
        randomToggle.isOn = isRandom;
    }

}
