using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    private GameObject nextSlot;
    private SlotScript slotScript;

    private GameObject theBall;
    private BallScript ballScript;

    [SerializeField]
    private bool isFirst;
    public bool isOcupied;
    public bool ballCharged;

    // Start is called before the first frame update
    void Start()
    {
        slotScript = nextSlot.GetComponent<SlotScript>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageBall();
        ManageCharge();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOcupied = true;
        theBall = collision.gameObject;
        ballScript = theBall.GetComponent<BallScript>();
       
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
