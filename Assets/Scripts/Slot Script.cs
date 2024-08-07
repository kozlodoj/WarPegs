using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    private GameObject nextSlot;
    private SlotScript slotScript;

    private Mag magScript;

    private GameObject theBall;
    private Ball ballScript;

    [SerializeField]
    private bool isFirst;
    [SerializeField]
    private bool isLast;
    public bool isOcupied;
    public bool ballCharged;
    private bool firstBall = true;


    // Start is called before the first frame update
    void Start()
    {
        magScript = GameObject.Find("Mag").GetComponent<Mag>();
        slotScript = nextSlot.GetComponent<SlotScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageBall();
        ManageCharge();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Fire"))
        {
            if (!isOcupied)
            {
                theBall = collision.gameObject;
                ballScript = theBall.GetComponent<Ball>();
                if (!ballScript.isShot)
                    isOcupied = true;
            }
        }
        
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == theBall)
        {
            isOcupied = false;
            ballCharged = false;
            theBall = null;
            ballScript = null;
        }
        
    }

    private void ManageBall()
    {
        if (!slotScript.isOcupied && isOcupied)
        {
            if (isFirst && ballScript.isCharged)
            {
                theBall.transform.position = nextSlot.transform.position;
            }
            else if (!isFirst)
                theBall.transform.position = nextSlot.transform.position;
        }
        if (isLast && !isOcupied)
        {
            magScript.NewBall();
        }


    }
    private void ManageCharge()
    {
        if (ballScript != null)
        {
            ballCharged = ballScript.isCharged;
            if (isFirst && firstBall)
            {
                if (GameManager.instance.tutorial)
                {
                    ballScript.SetInitialCharge(50f);
                    firstBall = false;
                }
                else
                {
                    ballScript.SetInitialCharge(GameManager.instance.initialBallCharge);
                    firstBall = false;
                }
            }
            if (isFirst)
            {
                ballScript.ActivateCharging();
            }
            else if (slotScript.ballCharged)
                ballScript.ActivateCharging();
        }
    }

    public void ChargeTheBall()
    {
        ballScript.FullCharge();
    }
}
