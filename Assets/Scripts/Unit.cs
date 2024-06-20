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
    [SerializeField]
    private float attackCooldown = 1.5f;
    private float currentHp;
    private bool canHit = true;
    private bool animationDone = false;
    private bool canMove = true;
    private bool onBase;
    private UnitUI UI;
    private GameObject enemy;
    private GameObject enemyBase;
    private EnemyScript enemyS;
    private BaseScript baseS;

    [SerializeField]
    private Animator weaponAnimator;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject arrow;

    private void OnEnable()
    {
        StartRoutine();

    }

    void Update()
    {
        
            Move();
            RangedAttack();
            ManageHP();
            ManageFreezeStop();
        
    }


    public void DealDamage(float amount)
    {
        currentHp -= amount;
        UI.UpdateHP(HP, currentHp);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isRanged && enemy == null && enemyBase == null)
        {
            if (collision.gameObject == towManager.ClosestEnemy(gameObject.transform) && collision.gameObject.CompareTag("Enemy") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                enemy = collision.gameObject;
                enemyS = enemy.GetComponent<EnemyScript>();
                if (canMove && !onBase)
                {
                    canMove = false;
                    agent.isStopped = true;
                }
                StartCoroutine(HitWithCooldown());
            }
            else if (collision.gameObject == towManager.ClosestEnemy(gameObject.transform) && collision.gameObject.CompareTag("Enemy base") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                enemyBase = collision.gameObject;
                baseS = enemyBase.GetComponent<BaseScript>();
                if (canMove && !onBase)
                {
                    canMove = false;
                    agent.isStopped = true;
                }
                StartCoroutine(HitWithCooldown());
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!isRanged && enemy == null && enemyBase == null)
        {
            if (collision.gameObject == towManager.ClosestEnemy(gameObject.transform) && collision.gameObject.CompareTag("Enemy"))
            {
                enemy = collision.gameObject;
                enemyS = enemy.GetComponent<EnemyScript>();
                if (canMove && !onBase)
                {
                    canMove = false;
                    agent.isStopped = true;
                }
            }
            
            else if (collision.gameObject == towManager.ClosestEnemy(gameObject.transform) && collision.gameObject.CompareTag("Enemy base"))
            {
                enemyBase = collision.gameObject;
                baseS = enemyBase.GetComponent<BaseScript>();
                if (canMove && !onBase)
                {
                    canMove = false;
                    agent.isStopped = true;
                }
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == enemy)
        {
            enemy = null;
            enemyS = null;
            canMove = true;
        }
        else if (collision.gameObject == enemyBase)
        {
            enemyBase = null;
            baseS = null;
            canMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player Base"))
            onBase = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onBase = false;
    }

    private IEnumerator HitWithCooldown()
    {
        if (enemyS != null)
        {
            weaponAnimator.SetFloat("speed", 1 / attackCooldown);
            weaponAnimator.SetBool("isHitting", true);
            canHit = false;
            animationDone = false;
            while (!animationDone)
                yield return null;
            if(enemyS != null)
            enemyS.DealDamage(attack);
            yield return new WaitForSeconds(attackCooldown);
            canHit = true;
            StartCoroutine(HitWithCooldown());
        }
        else if (baseS != null)
        {
            weaponAnimator.SetFloat("speed", 1 / attackCooldown);
            weaponAnimator.SetBool("isHitting", true);
            canHit = false;
            animationDone = false;
            while (!animationDone)
                yield return null;
            if(baseS != null)
            baseS.DealDamage(attack);
            yield return new WaitForSeconds(attackCooldown);
            canHit = true;
            StartCoroutine(HitWithCooldown());
        }

    }

    private void ManageFreezeStop()
    {
        if (GameManager.instance.freezeGame)
            weaponAnimator.speed = 0;
        else
            weaponAnimator.speed = 1;
    }

    private void ManageHP()
    {
        if (currentHp <= 0)
            gameObject.SetActive(false);

    }
    private void Move()
    {
        if (canMove)
        {
            if (!GameManager.instance.gameOver || !GameManager.instance.freezeGame)
            {
                agent.isStopped = false;
                target = towManager.ClosestEnemy(gameObject.transform);
                if (target != null)
                    agent.SetDestination(target.transform.position);
            }
            if (GameManager.instance.freezeGame)
            {
                agent.isStopped = true;
            }
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
        if (target != null)
        {
            if (isRanged && CanShoot(target.transform.position) && !GameManager.instance.gameOver)
            {

                if (canHit)
                {
                    weaponAnimator.SetBool("isHitting", true);

                }

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

    private IEnumerator RangedWithCooldown(float cooldown)
    {

        yield return new WaitForSeconds(cooldown);
        canHit = true;

    }
    public void StopAnimationRanged()
    {
        weaponAnimator.SetBool("isHitting", false);
        canHit = false;
        arrow.SetActive(false);
            GameObject newArrow = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            newArrow.GetComponent<Arrow>().SetTarget(target, attack);
        StartCoroutine(ResetArrow());
    }

    private IEnumerator ResetArrow()
    {
        yield return new WaitForSeconds(1f);
        arrow.SetActive(true);
        StartCoroutine(RangedWithCooldown(attackCooldown));
    }

    public void StopAnimationMelee()
    {
        weaponAnimator.SetBool("isHitting", false);
        animationDone = true;
    }


}
