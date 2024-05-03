using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowManager : MonoBehaviour
{
    
    private List<GameObject> enemies = new List<GameObject>();
    
    private List<GameObject> units = new List<GameObject>();

    [SerializeField]
    private GameObject enemyBase;
    [SerializeField]
    private GameObject playerBase;
   

    // Start is called before the first frame update
    void Start()
    {
        UpdateEnemiesList(enemyBase);
        UpdateUnitList(playerBase);
    }

    public void UpdateEnemiesList(GameObject enemy)
    {
        enemies.Add(enemy);
        
    }

    public void UpdateUnitList(GameObject unit)
    {
        units.Add(unit);
       
    }

    public GameObject ClosestEnemy(Transform position)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = position.position;
        foreach (GameObject potentialTarget in enemies)
        {
            if (potentialTarget.gameObject.activeInHierarchy)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;

                }
            }
        }

  
        return bestTarget;

    }

    public GameObject ClosestUnit(Transform position)
    {
        GameObject bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = position.position;
        foreach (GameObject potentialTarget in units)
        {
            if (potentialTarget.gameObject.activeInHierarchy)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    bestTarget = potentialTarget;

                }
            }
        }
        
        return bestTarget;

    }
}
