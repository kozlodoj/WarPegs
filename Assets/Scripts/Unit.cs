using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private bool isRanged;

    [SerializeField]
    private float speed = 0.5f;

    private GameObject target;
    private NavMeshAgent agent;

    private TowManager towManager;

    [SerializeField]
    private float HP = 100f;
    [SerializeField]
    private float attack = 10f;
    private float attackCooldown = 1.5f;
    private float currentHp;
    private bool canHit = true;

    private UnitUI UI;

    [SerializeField]
    private Animator weaponAnimator;

    private void OnEnable()
    {
        StartRoutine();

    }

    void Update()
    {

        Move();
        RangedAttack();
        ManageHP();
    }


    public void DealDamage(float amount)
    {
        currentHp -= amount;
        UI.UpdateHP(HP, currentHp);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isRanged)
        {
            if (collision.gameObject.CompareTag("Enemy") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                //collision.gameObject.GetComponent<EnemyScript>().DealDamage(attack);
                //weaponAnimator.SetBool("isHitting", true);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, collision.gameObject.GetComponent<EnemyScript>(), null));
            }
            else if (collision.gameObject.CompareTag("Enemy base"))
            {

                //collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
                //weaponAnimator.SetBool("isHitting", true);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, null, collision.gameObject.GetComponent<BaseScript>()));
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isRanged)
        {
            if (canHit && collision.gameObject.CompareTag("Enemy") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                //collision.gameObject.GetComponent<EnemyScript>().DealDamage(attack);
                //weaponAnimator.SetBool("isHitting", true);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, collision.gameObject.GetComponent<EnemyScript>(), null));
            }
            else if (canHit && collision.gameObject.CompareTag("Enemy base"))
            {
                //collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
                //weaponAnimator.SetBool("isHitting", true);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, null, collision.gameObject.GetComponent<BaseScript>()));
            }
        }
    }

    private IEnumerator HitWithCooldown(float cooldown, EnemyScript enemyS, BaseScript baseS)
    {
        if (enemyS != null)
        {
            weaponAnimator.SetFloat("speed", 1 / attackCooldown);
            weaponAnimator.SetBool("isHitting", true);
            canHit = false;
            yield return new WaitForSeconds(cooldown);
            enemyS.DealDamage(attack);
            weaponAnimator.SetBool("isHitting", false);
            canHit = true;
        }
        else if (baseS != null)
        {
            weaponAnimator.SetFloat("speed", 1 / attackCooldown);
            weaponAnimator.SetBool("isHitting", true);
            canHit = false;
            yield return new WaitForSeconds(cooldown);
            weaponAnimator.SetBool("isHitting", false);
            baseS.DealDamage(attack);
            canHit = true;
        }

    }

    private void ManageHP()
    {
        if (currentHp <= 0)
            gameObject.SetActive(false);

    }
    private void Move()
    {
        if (!GameManager.instance.gameOver)
        {
            target = towManager.ClosestEnemy(gameObject.transform);
            agent.SetDestination(target.transform.position);
        }
    }

    public void Buff(float amount)
    {
        HP *= amount;
        currentHp = HP;
        agent.speed *= amount;
        attack *= amount;
        UI.BufText(amount);

    }

    private void StartRoutine()
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

    private void RangedAttack()
    {
        if (isRanged && CanShoot(target.transform.position) && !GameManager.instance.gameOver)
        {
            if (canHit && target.CompareTag("Enemy"))
            {
                //target.GetComponent<EnemyScript>().DealDamage(attack);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, target.gameObject.GetComponent<EnemyScript>(), null));
            }
            else if (canHit && target.CompareTag("Enemy base"))
            {
                //target.GetComponent<BaseScript>().DealDamage(attack);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, null, target.gameObject.GetComponent<BaseScript>()));
            }

        }
    }

    private bool CanShoot(Vector3 position)
    {
        
        Vector2 currentPosition = transform.position;
        Vector2 directionToTarget = (Vector2)position - currentPosition;
        float distance = directionToTarget.magnitude;
        if (distance <= agent.stoppingDistance)
            return true;
        else
            return false;
    }

}
