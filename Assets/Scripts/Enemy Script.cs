using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private NavMeshAgent agent;
    private TowManager towManager;
    [SerializeField]
    private bool isRanged;
    private GameObject target;
    [SerializeField]
    private float speed = 0.5f;
    [SerializeField]
    private float HP = 100f;
    [SerializeField]
    private float attack = 10f;
    private float currentHp;
    [SerializeField]
    private int goldDrop;
    private bool canMove = true;
    private bool onBase;
    [SerializeField]
    private float attackCooldown = 1.5f;
    private bool canHit = true;
    private bool animationDone = false;
    private GameObject player;
    private GameObject playerBase;
    private Unit playerS;
    private BaseScript baseS;

    [SerializeField]
    private Animator weaponAnimator;

    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private GameObject arrow;


    private UnitUI UI;

    void Start()
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
        if (!isRanged && player == null && playerBase == null)
        {
            if (collision.gameObject == towManager.ClosestUnit(gameObject.transform) && collision.gameObject.CompareTag("Unit") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                
                player = collision.gameObject;
                playerS = player.GetComponent<Unit>();
                if (canMove && !onBase)
                {
                    canMove = false;
                    agent.isStopped = true;
                }
                StartCoroutine(HitWithCooldown());
            }
            else if (collision.gameObject == towManager.ClosestUnit(gameObject.transform) && collision.gameObject.CompareTag("Player Base") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
            {
                playerBase = collision.gameObject;
                baseS = playerBase.GetComponent<BaseScript>();
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
        if (!isRanged && player == null && playerBase == null)
        {
            if (collision.gameObject == towManager.ClosestUnit(gameObject.transform) && collision.gameObject.CompareTag("Unit"))
            {
                player = collision.gameObject;
                playerS = player.GetComponent<Unit>();
                if (canMove && !onBase)
                {
                    canMove = false;
                    agent.isStopped = true;
                }
            }
            else if (collision.gameObject == towManager.ClosestUnit(gameObject.transform) && collision.gameObject.CompareTag("Player Base"))
            {
                playerBase = collision.gameObject;
                baseS = playerBase.GetComponent<BaseScript>();
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
        
        if (collision.gameObject == player)
        {
            player = null;
            playerS = null;
            canMove = true;
        }
        else if (collision.gameObject == playerBase)
        {
            playerBase = null;
            baseS = null;
            canMove = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy base"))
            onBase = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        onBase = false;
        if (player != null)
            agent.isStopped = true;
    }

    private IEnumerator HitWithCooldown()
    {
        if (playerS != null)
        {
            weaponAnimator.SetBool("isHitting", true);
            animationDone = false;
            while (!animationDone)
                yield return null;
            if (playerS != null)
                playerS.DealDamage(attack);
            yield return new WaitForSeconds(attackCooldown);
            StartCoroutine(HitWithCooldown());
        }
        else if (baseS != null)
        {
            weaponAnimator.SetBool("isHitting", true);
            animationDone = false;
            while (!animationDone)
                yield return null;
            if (baseS != null)
                baseS.DealDamage(attack);
            yield return new WaitForSeconds(attackCooldown);
            StartCoroutine(HitWithCooldown());
        }

    }
    private void ManageHP()
    {
        if (currentHp <= 0)
        {
                GameManager.instance.AddGold(goldDrop);
            if (!GameManager.instance.tutorial)
            {
                GameManager.instance.enemiesDefeated++;
                GameManager.instance.ManageDaily();
            }
            gameObject.SetActive(false);
        }

    }
    private void Move()
    {
        if (canMove)
        {
            if (!GameManager.instance.gameOver || !GameManager.instance.freezeGame)
            {
                agent.isStopped = false;
                target = towManager.ClosestUnit(gameObject.transform);
                if (target != null)
                    agent.SetDestination(target.transform.position);
            }
            if (GameManager.instance.freezeGame)
            {
                agent.isStopped = true;
            }
        }
        
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
                    canHit = false;

                }

            }
        }
    }

    private void ManageFreezeStop()
    {
        if (GameManager.instance.freezeGame)
            weaponAnimator.speed = 0;
        else
            weaponAnimator.speed = 1;
    }

    private IEnumerator RangedWithCooldown(float cooldown)
    {

        yield return new WaitForSeconds(cooldown);
        canHit = true;

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
    public void StopAnimationMelee()
    {
        weaponAnimator.SetBool("isHitting", false);
        animationDone = true;
    }

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
    }

    private IEnumerator ResetArrow()
    {
        yield return new WaitForSeconds(1f);
        arrow.SetActive(true);
        StartCoroutine(RangedWithCooldown(attackCooldown));
    }
}
