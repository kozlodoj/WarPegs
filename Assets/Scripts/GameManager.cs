using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public float ballPower = 5;
    public float reloadRate = 5;
    public float reloadPerSec = 0.06f;
    public float buff = 2;
    public float respawn = 2;
    public float intialStat = 100f;
    public int baseHP;
    public float initialBallCharge;

    public int gold;
    public int diamonds;
    public int currentGold;

    public bool randomSpawn;
    public bool reactivatePegsOnSpawn;

    public bool isUnitTwoActive = false;
    public bool isUnitThreeActive = false;

    public bool isPerkOneActive = false;
    public bool isPerkTwoActive = false;

    public float perkOneRecharge;
    public float perkTwoRecharge;

    public bool gameOver = false;

    public int unitTwoCost = 1000;
    public int unitThreeCost = 5000;

    public int perkOneCost = 300;
    public int perkTwoCost = 500;

    public int reloadCost;
    public int hPCost;
    public int buffCost;

    public bool storyMode;

    public float cameraScale;

    public bool joyStickActive;

    public bool freezeGame = false;

    public bool tutorial = true;

    public int playerEra;
    public int enemyEra;
    public int evolveCost;

    public int bounces;
    public int ballsShot;
    public int enemiesDefeated;
    public int unitTwoSpawned;
    public int unitThreeSpawned;
    public int goldCollected;
    public float buffGathered;

    public int dailyNum = 1;


    void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        CameraScale();
        SetReloadTime();
    }

    public void LevelSelect(int levelNum)
    {
        SetReloadTime();
        currentGold = 0;
        Time.timeScale = 1;
        if (levelNum > 5)
            storyMode = true;
        else
            storyMode = false;
        SceneManager.LoadScene(levelNum);
        gameOver = false;

    }

    public void BackToMenu()
    {
        currentGold = 0;
        SceneManager.LoadScene(5);
        gameOver = false;
    }

    public void GameOver()
    {
        gameOver = true;
        //tutorial = false;
        Time.timeScale = 0;
        UIScript UI = GameObject.Find("UI").GetComponent<UIScript>();
        UI.ActivateGameOverUI();
        UI.KillOutline();
    }
    public void AddGold(int amount)
    {
        gold += amount;
        currentGold += amount;
        if (SceneManager.GetActiveScene().name != "Story Menu" && !gameOver)
            goldCollected += amount;
        ManageDaily();
        if (SceneManager.GetActiveScene().name == "Story Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetGoldText(gold);
        }
        else
        GameObject.Find("UI").GetComponent<UIScript>().SetGold(gold);
    }

    public void AddDiamond(int amount)
    {
        diamonds += amount;
       
        if (SceneManager.GetActiveScene().name == "Story Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetDiamondText(diamonds);
        }
        else
            GameObject.Find("UI").GetComponent<UIScript>().SetDiamonds(diamonds);
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
        else if (num == 4)
        {
            AddGold(-evolveCost);
            playerEra++;
            enemyEra = 0;
            NextEra();
        }
    }
    public void BuyPerk(int num)
    {
        if (num == 1 && !isPerkOneActive)
        {
            AddDiamond(-perkOneCost);
            isPerkOneActive = true;
        }
        if (num == 2 && !isPerkTwoActive)
        {
            AddDiamond(-perkTwoCost);
            isPerkTwoActive = true;
        }

    }

    public void BuyReloadTime()
    {
        reloadPerSec += 0.005f;
        reloadRate = 1 / reloadPerSec;
        AddGold(-reloadCost);
        reloadCost = (int)(reloadCost * 1.2f);
    }
    public void BuyHP()
    {
        baseHP = (int)(baseHP + 1);
        AddGold(-hPCost);
        hPCost = (int)(hPCost * 1.2f);
    }
    public void BuyBuff()
    {
        buff++;
        AddGold(-buffCost);
        buffCost = (int)(buffCost * 2f);
    }


    private void CameraScale()
    {
        if ((float)Screen.height / (float)Screen.width >= 2f)
        {
            GameObject camera = GameObject.Find("Main Camera");
            cameraScale = ((float)Screen.height / (float)Screen.width) * 5f;
            camera.GetComponent<Camera>().orthographicSize = cameraScale;
        }
        else
        {
            GameObject camera = GameObject.Find("Main Camera");
            cameraScale = 10;
            camera.GetComponent<Camera>().orthographicSize = cameraScale;
        }

    }
    public void FreezeTow()
    {
        if (!freezeGame)
            freezeGame = true;
       
    }
    public void UnFreezeTow()
    {
        if (freezeGame)
            freezeGame = false;
    }
    private void SetReloadTime()
    {
        reloadRate = 1 / reloadPerSec;
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    private void NextEra()
    {
        GameObject.Find("UI").GetComponent<StoryUI>().NextEra();
        isUnitTwoActive = false;
        isUnitThreeActive = false;

        unitThreeCost *= 3;
        unitTwoCost *= 3;
        evolveCost *= 3;

        reloadPerSec = 0.06f;
        SetReloadTime();
        baseHP = 2;
        reloadCost = 27;
        hPCost = 90;
        buffCost = 3000;
        buff = 1;
    }



    public void ManageDaily()
    {
        if (SceneManager.GetActiveScene().name != "Story Menu")
        {
            if (dailyNum == 1)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (goldCollected >= 100)
                {
                    AddDiamond(40);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 2)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (bounces >= 150)
                {
                    AddDiamond(50);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
             else if (dailyNum == 3)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (ballsShot >= 15)
                {
                    AddDiamond(40);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 4)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (unitTwoSpawned >= 15)
                {
                    AddDiamond(50);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 5)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (enemiesDefeated >= 20)
                {
                    AddDiamond(50);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 6)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (unitThreeSpawned >= 7)
                {
                    AddDiamond(70);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
            else if (dailyNum == 7)
            {
                GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(false);
                if (buffGathered >= 1)
                {
                    AddDiamond(100);
                    GameObject.Find("UI").GetComponent<UIScript>().ManageDaily(true);
                    ResetDailyProgress();
                }
            }
        }
    }
    public void ResetDailyProgress()
    {
        bounces = 0;
        goldCollected = 0;
        ballsShot = 0;
        enemiesDefeated = 0;
        unitTwoSpawned = 0;
        unitThreeSpawned = 0;
        buffGathered = 0;
    }
}
