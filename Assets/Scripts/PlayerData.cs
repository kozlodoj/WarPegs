using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
 
        public float ballPower;
        public float reloadRate;
        public float reloadPerSec;
        public float buff;
        public float respawn;
        public float intialStat;
        public int baseHP;
        public float initialBallCharge;
        public int gold;
        public int diamonds;
        public bool isUnitTwoActive = false;
        public bool isUnitThreeActive = false;
        public bool isPerkOneActive = false;
        public bool isPerkTwoActive = false;
        public int unitTwoCost;
        public int unitThreeCost;
        public int reloadCost;
        public int hPCost;
        public int buffCost;
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
        public int dailyNum;
        public bool tutorial;
        public int timeLine;
        public float timeLineModifier;
        public int numberOfSpecialPegs;
        public int feverBounces;

        public float reloadRateEvent = 5;
        public float reloadPerSecEvent = 0.06f;
        public int baseHPEvent;
        public bool isUnitTwoActiveEvent;
        public bool isUnitThreeActiveEvent;
        public int unitTwoCostEvent;
        public int unitThreeCostEvent;

        public int reloadCostEvent;
        public int hPCostEvent;

        public int playerEraEvent;
        public int enemyEraEvent;
        public int evolveCostEvent;
        public bool canNextTimelineEvent;

        public int timeLineEvent;
        public float timeLineModifierEvent;

        public int goldEvent;

}
