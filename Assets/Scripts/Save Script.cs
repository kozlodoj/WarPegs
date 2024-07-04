using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    private string saveFilePath;
    private PlayerData saveData;

    public void SaveGame()
    {
       
        saveFilePath = Application.persistentDataPath + "/SaveData.json";
        saveData = new PlayerData();

        saveData.ballPower = GameManager.instance.ballPower;
        saveData.reloadRate = GameManager.instance.reloadRate;
        saveData.reloadPerSec = GameManager.instance.reloadPerSec;
        saveData.buff = GameManager.instance.buff;
        saveData.respawn = GameManager.instance.respawn;
        saveData.intialStat = GameManager.instance.intialStat;
        saveData.baseHP = GameManager.instance.baseHP;
        saveData.initialBallCharge = GameManager.instance.initialBallCharge;
        saveData.gold = GameManager.instance.gold;
        saveData.diamonds = GameManager.instance.diamonds;
        saveData.isUnitTwoActive = GameManager.instance.isUnitTwoActive;
        saveData.isUnitThreeActive = GameManager.instance.isUnitThreeActive;
        saveData.isPerkOneActive = GameManager.instance.isPerkOneActive;
        saveData.isPerkTwoActive = GameManager.instance.isPerkTwoActive;
        saveData.unitTwoCost = GameManager.instance.unitTwoCost;
        saveData.unitThreeCost = GameManager.instance.unitThreeCost;
        saveData.reloadCost = GameManager.instance.reloadCost;
        saveData.hPCost = GameManager.instance.hPCost;
        saveData.buffCost = GameManager.instance.buffCost;
        saveData.playerEra = GameManager.instance.playerEra;
        saveData.enemyEra = GameManager.instance.enemyEra;
        saveData.evolveCost = GameManager.instance.evolveCost;
        saveData.bounces = GameManager.instance.bounces;
        saveData.ballsShot = GameManager.instance.ballsShot;
        saveData.enemiesDefeated = GameManager.instance.enemiesDefeated;
        saveData.unitTwoSpawned = GameManager.instance.unitTwoSpawned;
        saveData.unitThreeSpawned = GameManager.instance.unitThreeSpawned;
        saveData.goldCollected = GameManager.instance.goldCollected;
        saveData.dailyNum = GameManager.instance.dailyNum;
        saveData.tutorial = GameManager.instance.tutorial;
        saveData.timeLine = GameManager.instance.timeLine;
        saveData.timeLineModifier = GameManager.instance.timeLineModifier;

        string savePlayerData = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, savePlayerData);
       
    }

    public void LoadGame()
    {
        saveFilePath = Application.persistentDataPath + "/SaveData.json";
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
            if (saveData.timeLineModifier == 0)
            {
                File.Delete(saveFilePath);
            }
            else
            {
                
                GameManager.instance.ballPower = saveData.ballPower;
                GameManager.instance.reloadRate = saveData.reloadRate;
                GameManager.instance.reloadPerSec = saveData.reloadPerSec;
                GameManager.instance.buff = saveData.buff;
                GameManager.instance.respawn = saveData.respawn;
                GameManager.instance.intialStat = saveData.intialStat;
                GameManager.instance.baseHP = saveData.baseHP;
                GameManager.instance.initialBallCharge = saveData.initialBallCharge;
                GameManager.instance.gold = saveData.gold;
                GameManager.instance.diamonds = saveData.diamonds;
                GameManager.instance.isUnitTwoActive = saveData.isUnitTwoActive;
                GameManager.instance.isUnitThreeActive = saveData.isUnitThreeActive;
                GameManager.instance.isPerkOneActive = saveData.isPerkOneActive;
                GameManager.instance.isPerkTwoActive = saveData.isPerkTwoActive;
                GameManager.instance.unitTwoCost = saveData.unitTwoCost;
                GameManager.instance.unitThreeCost = saveData.unitThreeCost;
                GameManager.instance.reloadCost = saveData.reloadCost;
                GameManager.instance.hPCost = saveData.hPCost;
                GameManager.instance.buffCost = saveData.buffCost;
                GameManager.instance.playerEra = saveData.playerEra;
                GameManager.instance.enemyEra = saveData.enemyEra;
                GameManager.instance.evolveCost = saveData.evolveCost;
                GameManager.instance.bounces = saveData.bounces;
                GameManager.instance.ballsShot = saveData.ballsShot;
                GameManager.instance.enemiesDefeated = saveData.enemiesDefeated;
                GameManager.instance.unitTwoSpawned = saveData.unitTwoSpawned;
                GameManager.instance.unitThreeSpawned = saveData.unitThreeSpawned;
                GameManager.instance.goldCollected = saveData.goldCollected;
                GameManager.instance.dailyNum = saveData.dailyNum;
                GameManager.instance.tutorial = saveData.tutorial;
                GameManager.instance.timeLine = saveData.timeLine;
                GameManager.instance.timeLineModifier = saveData.timeLineModifier;
            }
        }

    }

    public void NewGameFile()
    {
        
        saveFilePath = Application.persistentDataPath + "/NewGame.json";
        if (!File.Exists(saveFilePath))
        {
            saveData = new PlayerData();

            saveData.ballPower = GameManager.instance.ballPower;
            saveData.reloadRate = GameManager.instance.reloadRate;
            saveData.reloadPerSec = GameManager.instance.reloadPerSec;
            saveData.buff = GameManager.instance.buff;
            saveData.respawn = GameManager.instance.respawn;
            saveData.intialStat = GameManager.instance.intialStat;
            saveData.baseHP = GameManager.instance.baseHP;
            saveData.initialBallCharge = GameManager.instance.initialBallCharge;
            saveData.gold = GameManager.instance.gold;
            saveData.diamonds = GameManager.instance.diamonds;
            saveData.isUnitTwoActive = GameManager.instance.isUnitTwoActive;
            saveData.isUnitThreeActive = GameManager.instance.isUnitThreeActive;
            saveData.isPerkOneActive = GameManager.instance.isPerkOneActive;
            saveData.isPerkTwoActive = GameManager.instance.isPerkTwoActive;
            saveData.unitTwoCost = GameManager.instance.unitTwoCost;
            saveData.unitThreeCost = GameManager.instance.unitThreeCost;
            saveData.reloadCost = GameManager.instance.reloadCost;
            saveData.hPCost = GameManager.instance.hPCost;
            saveData.buffCost = GameManager.instance.buffCost;
            saveData.playerEra = GameManager.instance.playerEra;
            saveData.enemyEra = GameManager.instance.enemyEra;
            saveData.evolveCost = GameManager.instance.evolveCost;
            saveData.bounces = GameManager.instance.bounces;
            saveData.ballsShot = GameManager.instance.ballsShot;
            saveData.enemiesDefeated = GameManager.instance.enemiesDefeated;
            saveData.unitTwoSpawned = GameManager.instance.unitTwoSpawned;
            saveData.unitThreeSpawned = GameManager.instance.unitThreeSpawned;
            saveData.goldCollected = GameManager.instance.goldCollected;
            saveData.dailyNum = GameManager.instance.dailyNum;
            saveData.tutorial = GameManager.instance.tutorial;
            saveData.timeLine = GameManager.instance.timeLine;
            saveData.timeLineModifier = GameManager.instance.timeLineModifier;

            string savePlayerData = JsonUtility.ToJson(saveData);
            File.WriteAllText(saveFilePath, savePlayerData);
        }
    }

    public void LoadNewGame()
    {
        saveFilePath = Application.persistentDataPath + "/NewGame.json";
        if (File.Exists(saveFilePath))
        {

            string loadPlayerData = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
            if (saveData.timeLineModifier == 0)
            {
                File.Delete(saveFilePath);
            }
            else
            {
                GameManager.instance.ballPower = saveData.ballPower;
                GameManager.instance.reloadRate = saveData.reloadRate;
                GameManager.instance.reloadPerSec = saveData.reloadPerSec;
                GameManager.instance.buff = saveData.buff;
                GameManager.instance.respawn = saveData.respawn;
                GameManager.instance.intialStat = saveData.intialStat;
                GameManager.instance.baseHP = saveData.baseHP;
                GameManager.instance.initialBallCharge = saveData.initialBallCharge;
                GameManager.instance.gold = saveData.gold;
                GameManager.instance.diamonds = saveData.diamonds;
                GameManager.instance.isUnitTwoActive = saveData.isUnitTwoActive;
                GameManager.instance.isUnitThreeActive = saveData.isUnitThreeActive;
                GameManager.instance.isPerkOneActive = saveData.isPerkOneActive;
                GameManager.instance.isPerkTwoActive = saveData.isPerkTwoActive;
                GameManager.instance.unitTwoCost = saveData.unitTwoCost;
                GameManager.instance.unitThreeCost = saveData.unitThreeCost;
                GameManager.instance.reloadCost = saveData.reloadCost;
                GameManager.instance.hPCost = saveData.hPCost;
                GameManager.instance.buffCost = saveData.buffCost;
                GameManager.instance.playerEra = saveData.playerEra;
                GameManager.instance.enemyEra = saveData.enemyEra;
                GameManager.instance.evolveCost = saveData.evolveCost;
                GameManager.instance.bounces = saveData.bounces;
                GameManager.instance.ballsShot = saveData.ballsShot;
                GameManager.instance.enemiesDefeated = saveData.enemiesDefeated;
                GameManager.instance.unitTwoSpawned = saveData.unitTwoSpawned;
                GameManager.instance.unitThreeSpawned = saveData.unitThreeSpawned;
                GameManager.instance.goldCollected = saveData.goldCollected;
                GameManager.instance.dailyNum = saveData.dailyNum;
                GameManager.instance.tutorial = saveData.tutorial;
                GameManager.instance.timeLine = saveData.timeLine;
                GameManager.instance.timeLineModifier = saveData.timeLineModifier;
            }

        }

    }
    public void DeleteSaveFiles()
    {
        saveFilePath = Application.persistentDataPath + "/NewGame.json";
        File.Delete(saveFilePath);
        saveFilePath = Application.persistentDataPath + "/SaveData.json";
        File.Delete(saveFilePath);

    }
}
