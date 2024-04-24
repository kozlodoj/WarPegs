using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private TowManager towManager;

    private float HP = 1000f;
    private float attack = 10f;
    private float currentHp;

    private float attackCooldown = 0.5f;
    private bool canHit = true;
    private bool canMove = true;

    private UnitUI UI;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        towManager = GameObject.Find("TOW").transform.Find("TOW Manager").GetComponent<TowManager>();
        UI = transform.Find("Canvas").GetComponent<UnitUI>();
        currentHp = HP;
        UI.UpdateHP(HP, currentHp);
    }

    // Update is called once per frame
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
        if (collision.gameObject.CompareTag("Unit"))
        {
            agent.isStopped = true;
            collision.gameObject.GetComponent<Unit>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
        else if (collision.gameObject.CompareTag("Player Base"))
        {
           
            collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canHit && collision.gameObject.CompareTag("Unit"))
        {

            collision.gameObject.GetComponent<Unit>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
        else if (canHit && collision.gameObject.CompareTag("Player Base"))
        {
            collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        agent.isStopped = false;
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
        agent.SetDestination(towManager.ClosestUnit(gameObject.transform));
    }
}
