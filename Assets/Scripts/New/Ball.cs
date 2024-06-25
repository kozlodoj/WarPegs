using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    
    void Start()
    {
        //reference 
        ballUI = UI.GetComponent<BallUI>();
        animator.gameObject.GetComponent<Animator>();
        SetStats();
        //check for tutorial
        if (GameManager.instance.tutorial)
        {
            tut = GameObject.Find("UI").transform.Find("Tutorial").GetComponent<Tutorial>();
        }
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
                buffPoints += peg.buffPoints;

                ballUI.SetBuffText(buffPoints);
            if (GameManager.instance.tutorial && tut.tutCounter == 2)
            {
                tut.BallHit(transform.position);
            }
            peg.FadeOut();
            

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
        if (GameManager.instance.tutorial)
        {
            chargeTime = 7f;
        }
        else
        {
            chargeTime = GameManager.instance.reloadRate;
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
    
}
