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

    [SerializeField]
    private float HP = 100f;
    [SerializeField]
    private float attack = 10f;
    private float attackCooldown = 1f;
    private float currentHp;
    private bool canHit = true;

    private UnitUI UI;

    private void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.speed = speed;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        UI = transform.Find("Canvas").GetComponent<UnitUI>();
        currentHp = HP;
        UI.UpdateHP(HP, currentHp);

    }

    void Update()
    {

        Move();
        ManageHP();
    }


    public void DealDamage(float amount)
    {
        currentHp -= amount;
        UI.UpdateHP(HP, currentHp);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
        else if (collision.gameObject.CompareTag("Enemy base"))
        {

            collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canHit && collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
        else if (canHit && collision.gameObject.CompareTag("Enemy base"))
        {
            collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
    }

    private IEnumerator HitWithCooldown(float cooldown)
    {
        yield return new WaitForSeconds(cooldown);
        canHit = true;

    }

    private void ManageHP()
    {
        if (currentHp <= 0)
            gameObject.SetActive(false);

    }
    private void Move()
    {
            agent.SetDestination(towManager.ClosestEnemy(gameObject.transform));
        

    }

    public void Buff(float amount)
    {
        HP *= amount;
        agent.speed *= amount;
        attack *= amount;
        UI.BufText(amount);

    }
  


}
