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
            if (reactivateOnSpawn)
                pegs.ReactivatePegs();
            if (GameManager.instance.freezeGame)
            {
                GameManager.instance.UnFreezeTow();
                freezeScript.ResetFreeze();
            }
        }
    }
}
