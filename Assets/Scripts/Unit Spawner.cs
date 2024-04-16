using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject unitPrefab;

    private UIScript uiScript;

    private void Start()
    {
        uiScript = GameObject.Find("UI").GetComponent<UIScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            Instantiate(unitPrefab);
        uiScript.ResetBallTimer();

    }
}
