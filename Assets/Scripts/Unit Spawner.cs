using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;

    private TowManager towManager;

    private UIScript uiScript;

    private void Start()
    {
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newUnit = Instantiate(unitPrefab) as GameObject;
            newUnit.GetComponent<Unit>().Buff(collision.gameObject.GetComponent<BallScript>().GetBuff());
            towManager.UpdateUnitList(newUnit.transform);
        }
    }
}
