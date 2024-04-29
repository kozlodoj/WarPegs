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
    private BallScript ballScript;

    [SerializeField]
    private bool isFirst;
    [SerializeField]
    private bool isLast;
    [SerializeField]
    private bool isLouncher;
    public bool isOcupied;
    public bool ballCharged;
    private BallLauncher louncher;


    // Start is called before the first frame update
    void Start()
    {
        magScript = GameObject.Find("Mag").GetComponent<Mag>();
        slotScript = nextSlot.GetComponent<SlotScript>();
        if (isLouncher)
            louncher = GetComponent<BallLauncher>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ManageBall();
        ManageCharge();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOcupied)
        {
            isOcupied = true;
            theBall = collision.gameObject;
            ballScript = theBall.GetComponent<BallScript>();
            if (isLouncher)
            {
                louncher.SetBall(theBall);
            }

        }
       
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOcupied = false;
        ballCharged = false;
        theBall = null;
        ballScript = null;
        
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
            if (isFirst)
                ballScript.ActivateCharging();
            else if (slotScript.ballCharged)
                ballScript.ActivateCharging();
        }
    }
}
