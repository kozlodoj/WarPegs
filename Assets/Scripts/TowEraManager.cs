using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowEraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject era1PlayerBase;
    [SerializeField]
    private GameObject era2PlayerBase;
    [SerializeField]
    private GameObject era1EnemyBase;
    [SerializeField]
    private GameObject era2EnemyBase;

    // Start is called before the first frame update
    void Awake()
    {
        ManageBases();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ManageBases()
    {
        if (GameManager.instance.playerEra == 0)
        {
            Instantiate(era1PlayerBase, gameObject.transform);
        }
        else if (GameManager.instance.playerEra == 1)
        {
            Instantiate(era2PlayerBase, gameObject.transform);
        }
        if (GameManager.instance.enemyEra == 0)
        {
            Instantiate(era1EnemyBase, gameObject.transform);
        }
        else if (GameManager.instance.enemyEra == 1)
        {
            Instantiate(era2EnemyBase, gameObject.transform);
        }
    }
}
