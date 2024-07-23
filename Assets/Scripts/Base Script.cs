using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    [SerializeField]
    private float HP = 100f;
    private float currentHp;
    [SerializeField]
    private bool isEnemy;
    [SerializeField]
    private int goldDrop;

    private UnitUI UI;
    private HitGlowScript hitGlowScript;

    // Start is called before the first frame update
    void Start()
    {
        hitGlowScript = gameObject.GetComponent<HitGlowScript>();
        UI = transform.Find("Canvas").GetComponent<UnitUI>();
        if (!isEnemy)
            HP = GameManager.instance.baseHP;
        currentHp = HP;
        UI.UpdateHP(HP, currentHp);
    }

    // Update is called once per frame
    void Update()
    {
        ManageHP();
    }

    public void DealDamage(float amount)
    {
        hitGlowScript.gotHit = true;
        if (GameManager.instance.allEnemiesKilled)
            amount *= 3;
        if (isEnemy && !GameManager.instance.tutorial)
        {
            if (amount < currentHp)
                GameManager.instance.AddGold(goldDrop * (int)amount);
            else if (amount >= currentHp)
            {
                amount = currentHp;
                GameManager.instance.AddGold(goldDrop * (int)amount);
            }
        }
        currentHp -= amount;
        UI.UpdateHP(HP, currentHp);
    }

    private void ManageHP()
    {
        if (currentHp <= 0)
        {
            gameObject.SetActive(false);
            if (isEnemy && GameManager.instance.enemyEra != 5)
            {
                GameManager.instance.enemyEra++;
                if (GameManager.instance.enemyEra == 5 || GameManager.instance.enemyEra > GameManager.instance.playerEra)
                {
                    GameManager.instance.evolveCost = 0;
                }
            }
            else if (GameManager.instance.enemyEra == GameManager.instance.playerEra && isEnemy)
                GameManager.instance.evolveCost = 0;
            if (isEnemy && GameManager.instance.enemyEra == 5)
                GameManager.instance.canNextTimeline = true;

            GameManager.instance.GameOver();
        }

    }
}
