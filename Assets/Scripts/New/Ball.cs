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

    // Start is called before the first frame update
    void Start()
    {
        ballUI = UI.GetComponent<BallUI>();
        SetStats();
    }

    // Update is called once per frame
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
                peg.FadeOut();
            

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
            Destroy(gameObject);

    }

    public void ActivateCharging()
    {

        UI.SetActive(true);
        ballUI.SetCharge(timePassed / chargeTime);
        charging = true;

    }

    private void Charge()
    {
        if (charging)
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
    }

    public void SetStats()
    {
        chargeTime = GameManager.instance.reloadRate;
        buffRate = GameManager.instance.intialStat / 100f;

    }
    public float GetBuff()
    {
        return buffRate += buffPoints / 100f;
    }
}
