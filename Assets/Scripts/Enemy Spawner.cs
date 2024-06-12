using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public struct spawnUnit
    {
        public int unitNum;
        public float spawnTime;
        public bool stopSection;
    }
    [SerializeField]
    private List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    private List<spawnUnit> spawnPattern = new List<spawnUnit>();

    private TowManager towManager;

    private float minSpawnTime = 2f;
    private float maxSpawnTime = 10f;

    private bool randomSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        randomSpawn = GameManager.instance.randomSpawn;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        if (GameManager.instance.tutorial)
            TutorialPattern();
        else
        {
            if (randomSpawn)
                StartCoroutine(SpawnNextEnemy(RandomTime()));
            else
                StartCoroutine(SpawnPattern());
        }
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
    private void TutorialPattern()
    {
       
        StartCoroutine(SpawnFirst(10));
        StartCoroutine(SpawnFirst(15));
        StartCoroutine(SpawnFirst(16));
        StartCoroutine(SpawnFirst(21));
        StartCoroutine(SpawnFirst(22));
        StartCoroutine(SpawnSecond(28));
        StartCoroutine(Spawnthird(38));
        StartCoroutine(Spawnthird(39));


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

    private IEnumerator SpawnPattern()
    {
       
        yield return new WaitForSeconds(spawnPattern[0].spawnTime);
        for (int i = 0; i < spawnPattern.Count; i++)
        {
            if (i == 0)
            {
                yield return new WaitUntil(() => !GameManager.instance.freezeGame);
                towManager.UpdateEnemiesList(Instantiate(enemies[spawnPattern[i].unitNum], gameObject.transform));
                if (spawnPattern[i].stopSection && i + 1 != spawnPattern.Count)
                    yield return new WaitForSeconds(spawnPattern[i + 1].spawnTime);
            }

            else if (i != 0)
            {
                yield return new WaitUntil(() => !GameManager.instance.freezeGame);
                towManager.UpdateEnemiesList(Instantiate(enemies[spawnPattern[i].unitNum], gameObject.transform));
                if (spawnPattern[i].stopSection && i + 1 != spawnPattern.Count)
                    yield return new WaitForSeconds(spawnPattern[i + 1].spawnTime);

            }
            yield return new WaitForSeconds(0.5f);
        }
        StartCoroutine(SpawnPattern());
    }

}
