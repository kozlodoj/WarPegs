using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float ballPower = 5;
    public float reloadRate = 5;
    public float buff = 2;
    public float respawn = 2;
    public float intialStat = 100f;
    public int baseHP;

    public int gold;

    public bool randomSpawn;
    public bool reactivatePegsOnSpawn;

    public bool isUnitTwoActive = false;
    public bool isUnitThreeActive = false;

    public bool gameOver = false;

    public int unitTwoCost = 1000;
    public int unitThreeCost = 5000;

    public int reloadCost;
    public int hPCost;

    public bool storyMode;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

    }

    public void LevelSelect(int levelNum)
    {
        Time.timeScale = 1;
        if (levelNum >= 5)
            storyMode = true;
        else
            storyMode = false;
        SceneManager.LoadScene(levelNum);
        gameOver = false;

    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        GameObject.Find("UI").GetComponent<UIScript>().ActivateGameOverUI();
    }
    public void AddGold(int amount)
    {
        gold += amount;
        if (SceneManager.GetActiveScene().name == "Story Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetGoldText(gold);
        }
        else
        GameObject.Find("UI").GetComponent<UIScript>().SetGold(gold);
    }
    public void BuyUnit(int num)
    {
        if (num == 2 && !isUnitTwoActive)
        {
            AddGold(-unitTwoCost);
            isUnitTwoActive = true;
        }
        else if (num == 3 && !isUnitThreeActive)
        {
            AddGold(-unitThreeCost);
            isUnitThreeActive = true;
        }
    }
    public void BuyReloadTime()
    {
        reloadRate -= 0.25f;
        AddGold(-reloadCost);
        reloadCost = (int)(reloadCost * 1.1f);
    }
    public void BuyHP()
    {
        baseHP = (int)(baseHP * 1.2f);
        AddGold(-hPCost);
        hPCost = (int)(hPCost * 1.1f);
    }
   
}
