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
   

    // Start is called before the first frame update
    void Start()
    {
        UpdateEnemiesList(enemyBase);
        UpdateUnitList(playerBase);
    }

    public void UpdateEnemiesList(Transform enemy)
    {
        enemies.Add(enemy);
        
    }

    public void UpdateUnitList(Transform unit)
    {
        units.Add(unit);
        foreach (Transform u in units)
        {
            Debug.Log(u);
        }
    }

    public Vector3 ClosestEnemy(Transform position)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = position.position;
        foreach (Transform potentialTarget in enemies)
        {
            if (potentialTarget.gameObject.activeInHierarchy)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;

                }
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
            if (potentialTarget.gameObject.activeInHierarchy)
            {
                Vector3 directionToTarget = potentialTarget.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;

                }
            }
        }
        
        return bestTarget.position;

    }
}
