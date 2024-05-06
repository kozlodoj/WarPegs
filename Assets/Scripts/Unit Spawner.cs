using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;
    [SerializeField]
    private int unitNum;

    private TowManager towManager;

    private bool reactivateOnSpawn;

    private PegManager pegs;

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
        pegs = GameObject.Find("Peggle").transform.Find("Pegs").gameObject.GetComponent<PegManager>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newUnit = Instantiate(unitPrefab) as GameObject;
            newUnit.GetComponent<Unit>().Buff(collision.gameObject.GetComponent<Ball>().GetBuff());
            towManager.UpdateUnitList(newUnit);
            if (reactivateOnSpawn)
                pegs.ReactivatePegs();
        }
    }
}
