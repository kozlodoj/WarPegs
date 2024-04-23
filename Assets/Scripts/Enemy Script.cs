using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private TowManager towManager;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(towManager.ClosestUnit(gameObject.transform));
        agent.SetDestination(towManager.ClosestUnit(gameObject.transform));
    }
}
