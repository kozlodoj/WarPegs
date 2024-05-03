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

    private bool randomSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawn = GameManager.instance.randomSpawn;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        if (randomSpawn)
            StartCoroutine(SpawnNextEnemy(RandomTime()));
        else
            SpawnPattern01();
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
       towManager.UpdateEnemiesList(Instantiate(enemies[RandomEnemy()],gameObject.transform));
        StartCoroutine(SpawnNextEnemy(RandomTime()));
    }

    private void SpawnPattern01()
    {
        StartCoroutine(SpawnFirst(3));
        StartCoroutine(SpawnFirst(8));
        StartCoroutine(SpawnFirst(22));
        StartCoroutine(SpawnFirst(23));
        StartCoroutine(SpawnSecond(37));
        StartCoroutine(SpawnSecond(40));
        StartCoroutine(Spawnthird(43));
        StartCoroutine(Spawnthird(45));
        StartCoroutine(Spawnthird(48));
        StartCoroutine(SpawnFirst(55));
        StartCoroutine(SpawnFirst(56));
        StartCoroutine(SpawnFirst(57));
        StartCoroutine(SpawnFirst(58));
        StartCoroutine(SpawnFirst(68));
        StartCoroutine(Spawnthird(70));
        StartCoroutine(Spawnthird(75));
        StartCoroutine(SpawnSecond(90));
        StartCoroutine(SpawnSecond(91));
        StartCoroutine(SpawnSecond(93));
        StartCoroutine(restartSpawn(95));

    }

    private IEnumerator SpawnFirst(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        towManager.UpdateEnemiesList(Instantiate(enemies[0], gameObject.transform));
    }
    private IEnumerator SpawnSecond(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        towManager.UpdateEnemiesList(Instantiate(enemies[1], gameObject.transform));
    }
    private IEnumerator Spawnthird(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        towManager.UpdateEnemiesList(Instantiate(enemies[2], gameObject.transform));
    }
    private IEnumerator restartSpawn(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        SpawnPattern01();
    }    
}
