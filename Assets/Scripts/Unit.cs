using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.5f;

    [SerializeField]
    private Transform target;
    private NavMeshAgent agent;

    private TowManager towManager;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
    }

    void Update()
    {
        //transform.Translate(Vector2.right * Time.deltaTime * speed);
        agent.SetDestination(towManager.ClosestEnemy(gameObject.transform));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.CompareTag("Enemy base"))
        //    Destroy(gameObject);
    }
}
