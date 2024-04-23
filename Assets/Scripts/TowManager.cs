using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowManager : MonoBehaviour
{
    
    private List<Transform> enemies = new List<Transform>();
    
    private List<Transform> units = new List<Transform>();

    [SerializeField]
    private Transform enemyBase;
    [SerializeField]
    private Transform playerBase;
    [SerializeField]
    private Transform enemy;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform enemy2;
    [SerializeField]
    private Transform player2;

    // Start is called before the first frame update
    void Start()
    {
        UpdateEnemiesList(enemyBase);
        UpdateUnitList(playerBase);
        UpdateEnemiesList(enemy);
        UpdateUnitList(player);
        UpdateEnemiesList(enemy2);
        UpdateUnitList(player2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateEnemiesList(Transform enemy)
    {
        enemies.Add(enemy);
    }

    public void UpdateUnitList(Transform unit)
    {
        units.Add(unit);
    }

    public Vector3 ClosestEnemy(Transform position)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = position.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
         
            }
        }

        return bestTarget.position;

    }

    public Vector3 ClosestUnit(Transform position)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = position.position;
        foreach (Transform potentialTarget in units)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;

            }
        }

        return bestTarget.position;

    }
}
