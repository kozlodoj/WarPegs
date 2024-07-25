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
    private float initialStoppingDistance;
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
    [SerializeField]
    private GameObject iceCube;
    [SerializeField]
    private GameObject deathDummy;

    private HitGlowScript hitGlowScript;
    private void OnEnable()
    {
        StartRoutine();
        

    }

    void Update()
    {
        
            Move();
            ManageHP();
            ManageFreezeStop();
            
    }


    public void DealDamage(float amount)
    {
        hitGlowScript.gotHit = true;
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
        {
            onBase = true;
            if (isRanged)
            agent.stoppingDistance = 0.2f;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onBase = false;
        if (isRanged)
        agent.stoppingDistance = initialStoppingDistance;
        if (enemy != null)
        {
            canMove = false;
            agent.isStopped = true;
        }
    }

    private IEnumerator HitWithCooldown()
    {
        while (!canHit)
            yield return null;
        if (enemyS != null)
        {
            weaponAnimator.SetBool("isHitting", true);
            animationDone = false;
            while (!animationDone)
                yield return null;
            if(enemyS != null)
            enemyS.DealDamage(attack);
            StartCoroutine(AttackCoolDown());
            StartCoroutine(HitWithCooldown());
        }
        else if (baseS != null)
        {
            weaponAnimator.SetBool("isHitting", true);
            animationDone = false;
            while (!animationDone)
                yield return null;
            if(baseS != null)
            baseS.DealDamage(attack);
            StartCoroutine(AttackCoolDown());
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
        {
            hitGlowScript.gotHit = true;
            StartCoroutine(Die());
        }

    }

    private IEnumerator Die()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
        Instantiate(deathDummy, gameObject.transform.position, gameObject.transform.rotation);
    }
    private void Move()
    {
        if (canMove)
        {
            if (!GameManager.instance.gameOver || !GameManager.instance.freezeGame)
            {
                if (iceCube != null)
                iceCube.SetActive(false);
                agent.isStopped = false;
                target = towManager.ClosestEnemy(gameObject.transform);
                if (target != null)
                    agent.SetDestination(target.transform.position);
            }
            if (GameManager.instance.freezeGame)
            {
                agent.isStopped = true;
                if (iceCube != null)
                    iceCube.SetActive(true);
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
        initialStoppingDistance = agent.stoppingDistance;
        hitGlowScript = gameObject.GetComponent<HitGlowScript>();
        if (isRanged)
            StartCoroutine(RangedAttack());
    }

    private IEnumerator RangedAttack()
    {
        while (target == null)
            yield return null;
        while (!canHit)
            yield return null;
        while (!CanShoot(target.transform.position))
            yield return null;
        if (!GameManager.instance.gameOver)
                {
                    weaponAnimator.SetBool("isHitting", true);
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

    //private IEnumerator RangedWithCooldown(float cooldown)
    //{

    //    yield return new WaitForSeconds(cooldown);
    //    canHit = true;

    //}
    public void StopAnimationRanged()
    {
        weaponAnimator.SetBool("isHitting", false);
        arrow.SetActive(false);
        if (CanShoot(target.transform.position))
        {
            GameObject newArrow = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            newArrow.GetComponent<Arrow>().SetTarget(target, attack);
        }
        StartCoroutine(ResetArrow());
        StartCoroutine(AttackCoolDown());
    }

    private IEnumerator ResetArrow()
    {
        yield return new WaitForSeconds(1f);
        arrow.SetActive(true);
        StartCoroutine(RangedAttack());
    }

    public void StopAnimationMelee()
    {
        weaponAnimator.SetBool("isHitting", false);
        animationDone = true;
    }
    private IEnumerator AttackCoolDown()
    {
        canHit = false;
        yield return new WaitForSeconds(attackCooldown);
        canHit = true;
    }


}
