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
    private GameObject era3PlayerBase;
    [SerializeField]
    private GameObject era4PlayerBase;
    [SerializeField]
    private GameObject era5PlayerBase;
    [SerializeField]
    private GameObject era6PlayerBase;
    [SerializeField]
    private GameObject era1EnemyBase;
    [SerializeField]
    private GameObject era2EnemyBase;
    [SerializeField]
    private GameObject era3EnemyBase;
    [SerializeField]
    private GameObject era4EnemyBase;
    [SerializeField]
    private GameObject era5EnemyBase;
    [SerializeField]
    private GameObject era6EnemyBase;

    public bool isEvent;


    // Start is called before the first frame update
    void Awake()
    {
        ManageBases();
    }

    private void ManageBases()
    {
        if (!isEvent)
        {
            if (GameManager.instance.playerEra == 0)
            {
                Instantiate(era1PlayerBase, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 1)
            {
                Instantiate(era2PlayerBase, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 2)
            {
                Instantiate(era3PlayerBase, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 3)
            {
                Instantiate(era4PlayerBase, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 4)
            {
                Instantiate(era5PlayerBase, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 5)
            {
                Instantiate(era6PlayerBase, gameObject.transform);
            }
            if (GameManager.instance.enemyEra == 0)
            {
                Instantiate(era1EnemyBase, gameObject.transform);
            }
            else if (GameManager.instance.enemyEra == 1)
            {
                Instantiate(era2EnemyBase, gameObject.transform);

            }
            else if (GameManager.instance.enemyEra == 2)
            {
                Instantiate(era3EnemyBase, gameObject.transform);
            }
            else if (GameManager.instance.enemyEra == 3)
            {
                Instantiate(era4EnemyBase, gameObject.transform);
            }
            else if (GameManager.instance.enemyEra == 4)
            {
                Instantiate(era5EnemyBase, gameObject.transform);
            }
            else if (GameManager.instance.enemyEra == 5)
            {
                Instantiate(era6EnemyBase, gameObject.transform);
            }
        }
        else
        {
            if (EventManager.instance.playerEra == 0)
            {
                Instantiate(era1PlayerBase, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 1)
            {
                Instantiate(era2PlayerBase, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 2)
            {
                Instantiate(era3PlayerBase, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 3)
            {
                Instantiate(era4PlayerBase, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 4)
            {
                Instantiate(era5PlayerBase, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 5)
            {
                Instantiate(era6PlayerBase, gameObject.transform);
            }
            if (EventManager.instance.enemyEra == 0)
            {
                Instantiate(era1EnemyBase, gameObject.transform);
            }
            else if (EventManager.instance.enemyEra == 1)
            {
                Instantiate(era2EnemyBase, gameObject.transform);
            }
            else if (EventManager.instance.enemyEra == 2)
            {
                Instantiate(era3EnemyBase, gameObject.transform);
            }
            else if (EventManager.instance.enemyEra == 3)
            {
                Instantiate(era4EnemyBase, gameObject.transform);
            }
            else if (EventManager.instance.enemyEra == 4)
            {
                Instantiate(era5EnemyBase, gameObject.transform);
            }
            else if (EventManager.instance.enemyEra == 5)
            {
                Instantiate(era6EnemyBase, gameObject.transform);
            }
        }
    }
}
