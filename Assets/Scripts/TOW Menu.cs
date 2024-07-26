using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOWMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject eraOneSurface;
    [SerializeField]
    private GameObject eraOnePlayerBase;
    [SerializeField]
    private GameObject eraOneEnemyBase;
    [SerializeField]
    private GameObject eraTwoPlayerBase;
    [SerializeField]
    private GameObject eraTwoEnemyBase;
    [SerializeField]
    private GameObject eraThreePlayerBase;
    [SerializeField]
    private GameObject eraThreeEnemyBase;
    [SerializeField]
    private GameObject eraFourPlayerBase;
    [SerializeField]
    private GameObject eraFourEnemyBase;
    [SerializeField]
    private GameObject eraFivePlayerBase;
    [SerializeField]
    private GameObject eraFiveEnemyBase;
    [SerializeField]
    private GameObject eraSixPlayerBase;
    [SerializeField]
    private GameObject eraSixEnemyBase;

    private int playerEra;
    private int enemyEra;
 
    public void SetTheScene()
    {
        playerEra = GameManager.instance.playerEra;
        enemyEra = GameManager.instance.enemyEra;
        var playerBase = GameObject.FindWithTag("Player Base");
        if (playerBase != null)
            Destroy(playerBase);
        SetPlayerBase();
        var enemyBase = GameObject.FindWithTag("Enemy base");
        if (enemyBase != null)
            Destroy(enemyBase);
        SetEnemyBase();
        
    }
    private void SetPlayerBase()
    {
        if (playerEra == 0)
        {
            Instantiate(eraOnePlayerBase, gameObject.transform);
            Instantiate(eraOneSurface, gameObject.transform);
        }
        else if (playerEra == 1)
        {
            Instantiate(eraTwoPlayerBase, gameObject.transform);
            Instantiate(eraOneSurface, gameObject.transform);
        }
        else if (playerEra == 2)
        {
            Instantiate(eraThreePlayerBase, gameObject.transform);
            Instantiate(eraOneSurface, gameObject.transform);
        }
        else if (playerEra == 3)
        {
            Instantiate(eraFourPlayerBase, gameObject.transform);
            Instantiate(eraOneSurface, gameObject.transform);
        }
        else if (playerEra == 4)
        {
            Instantiate(eraFivePlayerBase, gameObject.transform);
            Instantiate(eraOneSurface, gameObject.transform);
        }
        else if (playerEra == 5)
        {
            Instantiate(eraSixPlayerBase, gameObject.transform);
            Instantiate(eraOneSurface, gameObject.transform);
        }

    }
    private void SetEnemyBase()
    {
        if (enemyEra == 0)
        {
            Instantiate(eraOneEnemyBase, gameObject.transform);
        }
        else if (enemyEra == 1)
        {
            Instantiate(eraTwoEnemyBase, gameObject.transform);
        }
        else if (enemyEra == 2)
        {
            Instantiate(eraThreeEnemyBase, gameObject.transform);
        }
        else if (enemyEra == 3)
        {
            Instantiate(eraFourEnemyBase, gameObject.transform);
        }
        else if (enemyEra == 4)
        {
            Instantiate(eraFiveEnemyBase, gameObject.transform);
        }
        else if (enemyEra == 5)
        {
            Instantiate(eraSixEnemyBase, gameObject.transform);
        }
    }
}
