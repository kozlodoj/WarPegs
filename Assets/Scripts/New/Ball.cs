using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;
    private BallUI ballUI;

    public float chargeTime = 5f;
    public bool isCharged = false;
    public bool isShot = false;

    private float timePassed = 0f;
    private bool charging = false;

    private PegScript peg;

    private float buffRate = 1f;
    private float buffPoints = 0;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private Transform fireTransform;
    public bool onFire;
    private Tutorial tut;
    private Rigidbody2D ballRb;

    private int bounces;

    
    void Start()
    {
        //reference 
        ballUI = UI.GetComponent<BallUI>();
        animator.gameObject.GetComponent<Animator>();
        ballRb = GetComponent<Rigidbody2D>();
        SetStats();
   
    }

    void Update()
    {
        Charge();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Walls"))
        {
                peg = collision.gameObject.GetComponent<PegScript>();
                peg.theBall = gameObject.GetComponent<Ball>();
            if (bounces == GameManager.instance.feverBounces - 1)
                peg.ActivateFeverMode();
                buffPoints += peg.buffPoints;
                ballUI.SetBuffText(buffPoints);
                peg.FadeOut();
            bounces++;
            
   
                if (peg.speedPeg)
                    ballRb.velocity *= peg.speedPegMultiplier;
  
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
            Destroy(gameObject);
        if (collision.gameObject.CompareTag("Peg"))
        {
            peg = collision.gameObject.GetComponent<PegScript>();
            buffPoints += peg.buffPoints;
        }
        if (collision.gameObject.CompareTag("Unit Trigger"))
        {
            ballRb.velocity = Vector2.zero;
            transform.DOMove(collision.gameObject.transform.position, 1);
            animator.SetBool("disolve", true);
            StartCoroutine(Die(1f));
        }
    }

    public void ActivateCharging()
    {

        UI.SetActive(true);
        ballUI.SetCharge(timePassed / chargeTime);
        charging = true;

    }

    private void Charge()
    {
        if (charging && !GameManager.instance.freezeGame)
        {
            timePassed += Time.deltaTime;
            ballUI.SetCharge(timePassed / chargeTime);
            if (timePassed > chargeTime)
            {

                isCharged = true;
                charging = false;

            }
        }
    }

    public void Shoot()
    {
        isShot = true;
    }

    public void LounchPos()
    {
        ballUI.DisactivateChargebar();
        transform.localScale = new Vector3(0.22f, 0.22f, 1f);
    }

    public void SetStats()
    {

        if (!GameManager.instance.isEvent)
        {
            chargeTime = GameManager.instance.reloadRate;
            buffRate = GameManager.instance.intialStat / 100f;
        }
        else
        {
            chargeTime = EventManager.instance.reloadRate;
            buffRate = GameManager.instance.intialStat / 100f;
        }


    }
    public float GetBuff()
    {
        return buffRate += buffPoints / 100f;
    }
    public void SetInitialCharge(float amount)
    {
        timePassed = chargeTime * (amount / 100);
    }
    public void FirePerk()
    {
        animator.SetBool("fire", true);
        onFire = true;
    }
    public void FullCharge()
    {
        timePassed = chargeTime;
    }
    public void AddBuffPoints(float amount)
    {
        buffPoints += amount;
        ballUI.SetBuffText(buffPoints);
    }
    public void TwinBall()
    {
        GameObject newBall = Instantiate(gameObject) as GameObject;
        var rb = newBall.GetComponent<Rigidbody2D>();
        var newVelocity = ballRb.velocity + (Vector2.right * 2f);
        rb.velocity = newVelocity;
    }
    private IEnumerator Die(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
    
}
