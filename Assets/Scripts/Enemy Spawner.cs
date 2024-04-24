using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    private TowManager towManager;

    private float minSpawnTime = 2f;
    private float maxSpawnTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        StartCoroutine(SpawnNextEnemy(RandomTime()));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private float RandomTime()
    {
        return Random.Range(minSpawnTime, maxSpawnTime);
    }

    private int RandomEnemy()
    {
        return Random.Range(0, enemies.Count);
    }

    private IEnumerator SpawnNextEnemy(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
       towManager.UpdateEnemiesList(Instantiate(enemies[RandomEnemy()],gameObject.transform).transform);
        StartCoroutine(SpawnNextEnemy(RandomTime()));
    }
}
