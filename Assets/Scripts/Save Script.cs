using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveScript : MonoBehaviour
{

    private string saveFilePath;
    private string saveFilePath2;
    private PlayerData saveData;
    private EventData eventData;

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
        saveData.numberOfSpecialPegs = GameManager.instance.numberOfSpecialPegs;
        saveData.feverBounces = GameManager.instance.feverBounces;

        string savePlayerData = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, savePlayerData);
       
    }
    public void SaveEvent()
    {

        saveFilePath2 = Application.persistentDataPath + "/EventData.json";
        eventData = new EventData();


        eventData.reloadRateEvent = EventManager.instance.reloadRate;
        eventData.reloadPerSecEvent = EventManager.instance.reloadPerSec;
        eventData.baseHPEvent = EventManager.instance.baseHP;
        eventData.isUnitTwoActiveEvent = EventManager.instance.isUnitTwoActive;
        eventData.isUnitThreeActiveEvent = EventManager.instance.isUnitThreeActive;
        eventData.unitTwoCostEvent = EventManager.instance.unitTwoCost;
        eventData.unitThreeCostEvent = EventManager.instance.unitThreeCost;
        eventData.reloadCostEvent = EventManager.instance.reloadCost;
        eventData.hPCostEvent = EventManager.instance.hPCost;
        eventData.playerEraEvent = EventManager.instance.playerEra;
        eventData.enemyEraEvent = EventManager.instance.enemyEra;
        eventData.evolveCostEvent = EventManager.instance.evolveCost;
        eventData.canNextTimelineEvent = EventManager.instance.canNextTimeline;
        eventData.timeLineEvent = EventManager.instance.timeLine;
        eventData.timeLineModifierEvent = EventManager.instance.timeLineModifier;
        eventData.goldEvent = EventManager.instance.gold;

        string savePlayerData = JsonUtility.ToJson(eventData);
        File.WriteAllText(saveFilePath2, savePlayerData);

    }

    public void LoadGame()
    {
        saveFilePath = Application.persistentDataPath + "/SaveData.json";
        if (File.Exists(saveFilePath))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
            
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
                GameManager.instance.numberOfSpecialPegs = saveData.numberOfSpecialPegs;
                GameManager.instance.feverBounces = saveData.feverBounces;
        }

    }
    public void LoadEvent()
    {
        saveFilePath2 = Application.persistentDataPath + "/EventData.json";
        if (File.Exists(saveFilePath2))
        {
            string loadPlayerData = File.ReadAllText(saveFilePath2);
            eventData = JsonUtility.FromJson<EventData>(loadPlayerData);

            EventManager.instance.reloadRate = eventData.reloadRateEvent;
            EventManager.instance.reloadPerSec = eventData.reloadPerSecEvent;
            EventManager.instance.baseHP = eventData.baseHPEvent;
            EventManager.instance.isUnitTwoActive = eventData.isUnitTwoActiveEvent;
            EventManager.instance.isUnitThreeActive = eventData.isUnitThreeActiveEvent;
            EventManager.instance.unitTwoCost = eventData.unitTwoCostEvent;
            EventManager.instance.unitThreeCost = eventData.unitThreeCostEvent;
            EventManager.instance.reloadCost = eventData.reloadCostEvent;
            EventManager.instance.hPCost = eventData.hPCostEvent;
            EventManager.instance.playerEra = eventData.playerEraEvent;
            EventManager.instance.enemyEra = eventData.enemyEraEvent;
            EventManager.instance.evolveCost = eventData.evolveCostEvent;
            EventManager.instance.canNextTimeline = eventData.canNextTimelineEvent;
            EventManager.instance.timeLine = eventData.timeLineEvent;
            EventManager.instance.timeLineModifier = eventData.timeLineModifierEvent;
            EventManager.instance.gold = eventData.goldEvent;

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
            saveData.numberOfSpecialPegs = GameManager.instance.numberOfSpecialPegs;
            saveData.feverBounces = GameManager.instance.feverBounces;

            string savePlayerData = JsonUtility.ToJson(saveData);
            File.WriteAllText(saveFilePath, savePlayerData);
        }
    }
    public void NewEventFile()
    {

        saveFilePath2 = Application.persistentDataPath + "/NewEvent.json";
        if (!File.Exists(saveFilePath2))
        {
            eventData = new EventData();

            eventData.reloadRateEvent = EventManager.instance.reloadRate;
            eventData.reloadPerSecEvent = EventManager.instance.reloadPerSec;
            eventData.baseHPEvent = EventManager.instance.baseHP;
            eventData.isUnitTwoActiveEvent = EventManager.instance.isUnitTwoActive;
            eventData.isUnitThreeActiveEvent = EventManager.instance.isUnitThreeActive;
            eventData.unitTwoCostEvent = EventManager.instance.unitTwoCost;
            eventData.unitThreeCostEvent = EventManager.instance.unitThreeCost;
            eventData.reloadCostEvent = EventManager.instance.reloadCost;
            eventData.hPCostEvent = EventManager.instance.hPCost;
            eventData.playerEraEvent = EventManager.instance.playerEra;
            eventData.enemyEraEvent = EventManager.instance.enemyEra;
            eventData.evolveCostEvent = EventManager.instance.evolveCost;
            eventData.canNextTimelineEvent = EventManager.instance.canNextTimeline;
            eventData.timeLineEvent = EventManager.instance.timeLine;
            eventData.timeLineModifierEvent = EventManager.instance.timeLineModifier;
            eventData.goldEvent = EventManager.instance.gold;

            string savePlayerData = JsonUtility.ToJson(eventData);
            File.WriteAllText(saveFilePath2, savePlayerData);
        }
    }

    public void LoadNewGame()
    {
        saveFilePath = Application.persistentDataPath + "/NewGame.json";
        if (File.Exists(saveFilePath))
        {

            string loadPlayerData = File.ReadAllText(saveFilePath);
            saveData = JsonUtility.FromJson<PlayerData>(loadPlayerData);
           
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
                GameManager.instance.numberOfSpecialPegs = saveData.numberOfSpecialPegs;
                GameManager.instance.feverBounces = saveData.feverBounces;

        }

    }
    public void LoadNewEvent()
    {
        saveFilePath2 = Application.persistentDataPath + "/NewEvent.json";
        if (File.Exists(saveFilePath2))
        {
            var saveFilePath = Application.persistentDataPath + "/EventData.json";
            File.Delete(saveFilePath);

            string loadPlayerData = File.ReadAllText(saveFilePath2);
            eventData = JsonUtility.FromJson<EventData>(loadPlayerData);

            EventManager.instance.reloadRate = eventData.reloadRateEvent;
            EventManager.instance.reloadPerSec = eventData.reloadPerSecEvent;
            EventManager.instance.baseHP = eventData.baseHPEvent;
            EventManager.instance.isUnitTwoActive = eventData.isUnitTwoActiveEvent;
            EventManager.instance.isUnitThreeActive = eventData.isUnitThreeActiveEvent;
            EventManager.instance.unitTwoCost = eventData.unitTwoCostEvent;
            EventManager.instance.unitThreeCost = eventData.unitThreeCostEvent;
            EventManager.instance.reloadCost = eventData.reloadCostEvent;
            EventManager.instance.hPCost = eventData.hPCostEvent;
            EventManager.instance.playerEra = eventData.playerEraEvent;
            EventManager.instance.enemyEra = eventData.enemyEraEvent;
            EventManager.instance.evolveCost = eventData.evolveCostEvent;
            EventManager.instance.canNextTimeline = eventData.canNextTimelineEvent;
            EventManager.instance.timeLine = eventData.timeLineEvent;
            EventManager.instance.timeLineModifier = eventData.timeLineModifierEvent;
            EventManager.instance.gold = eventData.goldEvent;


        }

    }
    public void DeleteSaveFiles()
    {
        
        var saveFilePath = Application.persistentDataPath + "/SaveData.json";
        File.Delete(saveFilePath);
        DeleteNewGame();
        
    }
    private void DeleteNewGame()
    {
        var saveFilePath = Application.persistentDataPath + "/NewGame.json";
        File.Delete(saveFilePath);
        DeleteEventFileNew();
        
    }
    private void DeleteEventFileNew()
    {
        var saveFilePath2 = Application.persistentDataPath + "/NewEvent.json";
        File.Delete(saveFilePath2);
        DeleteEventFile();
    }
    private void DeleteEventFile()
    {
        var saveFilePath2 = Application.persistentDataPath + "/EventData.json";
        File.Delete(saveFilePath2);
    }
    public void CheckForSave()
    {
        var saveFilePath = Application.persistentDataPath + "/CheckFile.json";
        if (!File.Exists(saveFilePath))
        {
            DeleteSaveFiles();
            File.Create(saveFilePath);
        }
    }
}
