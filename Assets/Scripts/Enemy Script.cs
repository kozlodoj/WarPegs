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


    private float attackCooldown = 1.5f;
    private bool canHit = true;

    [SerializeField]
    private Animator weaponAnimator;


    private UnitUI UI;

    // Start is called before the first frame update
    void Start()
    {
        StartRoutine();
    }

    // Update is called once per frame
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
        if (collision.gameObject.CompareTag("Unit") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            
            //collision.gameObject.GetComponent<Unit>().DealDamage(attack);
            //canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown, collision.gameObject.GetComponent<Unit>(), null));
        }
        else if (collision.gameObject.CompareTag("Player Base") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
           
            collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
            canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown, null, collision.gameObject.GetComponent<BaseScript>()));
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (canHit && collision.gameObject.CompareTag("Unit") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {

            //collision.gameObject.GetComponent<Unit>().DealDamage(attack);
            //canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown, collision.gameObject.GetComponent<Unit>(), null));
        }
        else if (canHit && collision.gameObject.CompareTag("Player Base") && weaponAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            //collision.gameObject.GetComponent<BaseScript>().DealDamage(attack);
            //canHit = false;
            StartCoroutine(HitWithCooldown(attackCooldown, null, collision.gameObject.GetComponent<BaseScript>()));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        agent.isStopped = false;
    }

    private IEnumerator HitWithCooldown(float cooldown, Unit unitS, BaseScript baseS)
    {
        if (unitS != null)
        {
            weaponAnimator.SetFloat("speed", 1 / attackCooldown);
            weaponAnimator.SetBool("isHitting", true);
            canHit = false;
            yield return new WaitForSeconds(cooldown);
            unitS.DealDamage(attack);
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
        {
            GameManager.instance.AddGold(goldDrop);
            gameObject.SetActive(false);
        }

    }
    private void Move()
    {
        if (!GameManager.instance.gameOver)
        {
            target = towManager.ClosestUnit(gameObject.transform);
            agent.SetDestination(target.transform.position);
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
        if (isRanged && CanShoot(target.transform.position) && !GameManager.instance.gameOver)
        {
            if (canHit && target.CompareTag("Unit"))
            {
                //target.GetComponent<Unit>().DealDamage(attack);
                //canHit = false;
                StartCoroutine(HitWithCooldown(attackCooldown, target.gameObject.GetComponent<Unit>(), null));
            }
            else if (canHit && target.CompareTag("Player Base"))
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
