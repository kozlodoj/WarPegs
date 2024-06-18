using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;
    [SerializeField]
    private int unitNum;
    [SerializeField]
    private Transform spawnPoint;

    private TowManager towManager;

    private bool reactivateOnSpawn;

    private PegManager pegs;

    private Freeze freezeScript;

    private void Start()
    {
        if (GameManager.instance.storyMode)
        {
            if (unitNum == 2 && !GameManager.instance.isUnitTwoActive)
            {
                gameObject.SetActive(false);
            }
            if (unitNum == 3 && !GameManager.instance.isUnitThreeActive)
            {
                gameObject.SetActive(false);
            }
        }
        spawnPoint = GameObject.FindWithTag("Unit Spawn Point").transform;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        reactivateOnSpawn = GameManager.instance.reactivatePegsOnSpawn;
        pegs = GameObject.FindWithTag("Peg Layout").gameObject.GetComponent<PegManager>();
        if (GameManager.instance.isPerkOneActive)
        freezeScript = GameObject.FindGameObjectWithTag("Freeze").GetComponent<Freeze>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newUnit = Instantiate(unitPrefab, spawnPoint) as GameObject;
            newUnit.GetComponent<Unit>().Buff(collision.gameObject.GetComponent<Ball>().GetBuff());
            towManager.UpdateUnitList(newUnit);
            if (collision.gameObject.GetComponent<Ball>().GetBuff() >= 2f)
            {
                GameManager.instance.buffGathered = 1;
                GameManager.instance.ManageDaily();
            }
            if (reactivateOnSpawn)
                pegs.ReactivatePegs();
            if (unitNum == 3)
                StartCoroutine(pegs.ReactivateDome());
            if (GameManager.instance.freezeGame)
            {
                GameManager.instance.UnFreezeTow();
                freezeScript.ResetFreeze();
            }
            if (unitNum == 2)
            {
                GameManager.instance.unitTwoSpawned++;
                GameManager.instance.ManageDaily();
            }
            else if (unitNum == 3)
            {
                GameManager.instance.unitThreeSpawned++;
                GameManager.instance.ManageDaily();
            }
        }
    }
}
