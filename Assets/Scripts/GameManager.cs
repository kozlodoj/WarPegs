using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
    public int buffPegs;
    public int speedPegs;
    public int twinPegs;
    public int bombPegs;
    public int chargePegs;
    public int feverPegs;
    public int coinPegs;
    public int freezePegs;
    public int lightningPegs;
    public int numberOfSpecialPegs;
    public int feverBounces;

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
    public int playerEraCount;
    public int enemyEra;
    public int evolveCost;
    public bool canNextTimeline = false;
    public bool allEnemiesKilled = false;

    public int timeLine;
    public float timeLineModifier = 1f;

    public int bounces;
    public int ballsShot;
    public int enemiesDefeated;
    public int unitTwoSpawned;
    public int unitThreeSpawned;
    public int goldCollected;
    public float buffGathered;

    public int dailyNum = 1;

    private SaveScript save;

    public Vector3 cameraYoffset;
    public Vector3 topUIoffset;

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        save = gameObject.GetComponent<SaveScript>();
        MakeNewGameData();
        CameraScale();
        LoadGame();
        SetReloadTime();
        Vibration.Init();
        DOTween.Init().SetCapacity(500, 50);


    }
    private void OnEnable()
    {
        if (tutorial)
        {
            LevelSelect(6);
        }
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
        SaveGame();
        SceneManager.LoadScene(levelNum);
        gameOver = false;

    }

    public void BackToMenu()
    {
        currentGold = 0;
        SaveGame();
        SceneManager.LoadScene(5);
        gameOver = false;
        tutorial = false;
    }

    public void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        UIScript UI = GameObject.Find("UI").GetComponent<UIScript>();
        UI.ActivateGameOverUI();
        UI.KillOutline();
    }
    public void AddGold(int amount)
    {
        gold += amount;
        currentGold += amount;
        if (SceneManager.GetActiveScene().name != "Story Menu" && !gameOver && !tutorial)
            goldCollected += amount;
        ManageDaily();
        if (SceneManager.GetActiveScene().name == "Story Menu")
        {
            GameObject.Find("UI").GetComponent<StoryUI>().SetGoldText(gold);
        }
        else
        GameObject.Find("UI").GetComponent<UIScript>().SetCollectedGold(currentGold);
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
        SaveGame();
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
    public void BuyPerk(int num)
    {
        SaveGame();
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
        SaveGame();
        reloadPerSec += 0.005f;
        reloadRate = 1 / reloadPerSec;
        AddGold(-reloadCost);
        reloadCost = (int)(reloadCost * 1.2f);
    }
    public void BuyHP()
    {
        SaveGame();
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
    public void BuyBuff()
    {
        SaveGame();
        buff++;
        AddDiamond(-buffCost);
        buffCost = (int)(buffCost * 2f);
    }

    private void CameraScale()
    {
        topUIoffset = new Vector3(0, -(Screen.height - Screen.safeArea.height - (Screen.safeArea.y * 1.5f)), 0);
        if ((float)Screen.height / (float)Screen.width >= 2f)
        {
            GameObject camera = GameObject.Find("Main Camera");
            cameraScale = ((float)Screen.height / (float)Screen.width) * 5.64f;
            camera.GetComponent<Camera>().orthographicSize = cameraScale;
            cameraYoffset = new Vector3(0, cameraScale - 10f, -10f);
            camera.transform.position = cameraYoffset;
        }
        else
        {
            GameObject camera = GameObject.Find("Main Camera");
            cameraScale = 10;
            camera.GetComponent<Camera>().orthographicSize = cameraScale;
            cameraYoffset = new Vector3(0, 0, -10f);
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

    public void NextEra()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
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
        SaveGame();

    }

    public void ManageDaily()
    {
        if (SceneManager.GetActiveScene().name != "Story Menu" && !tutorial)
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

    public void LoadGame()
    {
        save.LoadGame();
    }
    public void SaveGame()
    {
        save.SaveGame();
    }
    public void MakeNewGameData()
    {
        save.NewGameFile();
    }
    public void NewGame()
    {
        save.LoadNewGame();
    }
    public void DeleteSave()
    {
        save.DeleteSaveFiles();
    }
    public void NextTimeLine()
    {
        timeLine++;
        timeLineModifier *= 1.1f;
        playerEra = 0;
        enemyEra = 0;
        //set gold and stats
        gold = 0;
        reloadPerSec = 0.06f;
        SetReloadTime();
        baseHP = 2;
        //deactivate unit 2 & 3
        isUnitTwoActive = false;
        isUnitThreeActive = false;
        //change the cost of units and evolution
        unitThreeCost = 1200;
        unitTwoCost = 400;
        evolveCost = 2000;
        canNextTimeline = false;
        GameObject.Find("UI").GetComponent<StoryUI>().NextEra();
       
       

    }

    public string RoundedNum(float amount)
    {
        string result = amount.ToString();

        if (amount < 1000)
            result = amount.ToString("0");
        else if (amount < 10000)
        {
            //if (amount % 1 == 0)
            //    result = ((float)amount / 1000).ToString("0k");
            //else
                result = ((float)amount / 1000).ToString("0.00k");
        }
        else if (amount < 1000000)
        {
            //if (amount % 1 == 0)
            //    result = ((float)amount / 1000).ToString("0k");
            //else
                result = ((float)amount / 1000).ToString("0.0k");
        }
        else if (amount >= 1000000)
        {
            //var am = (float)amount / 1000000;
            //if (am % 1 == 0)
                result = ((float)amount / 1000000).ToString("0.0m");
            //else
            //    result = am.ToString("0.0m");
        }
        return result;

    }
}
