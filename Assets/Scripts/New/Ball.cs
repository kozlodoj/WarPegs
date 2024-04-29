using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private GameObject UI;
    private BallUI ballUI;

    private float chargeTime = 5f;
    public bool isCharged = false;
    public bool isShot = false;

    private float timePassed = 0f;
    private bool charging = false;

    // Start is called before the first frame update
    void Start()
    {
        ballUI = UI.GetComponent<BallUI>();
    }

    // Update is called once per frame
    void Update()
    {
        Charge();
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
}
