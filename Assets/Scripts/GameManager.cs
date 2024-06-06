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


    void Awake()
    {

        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        CameraScale();
    }

    public void LevelSelect(int levelNum)
    {
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
        Time.timeScale = 0;
        GameObject.Find("UI").GetComponent<UIScript>().ActivateGameOverUI();
    }
    public void AddGold(int amount)
    {
        gold += amount;
        currentGold += amount;
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
        reloadRate -= 0.25f;
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
        Debug.Log("height " + Screen.height + " Width " + Screen.width);
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

}
