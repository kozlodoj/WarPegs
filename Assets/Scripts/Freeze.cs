using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Freeze : MonoBehaviour
{
    public float reloadTime;
    private float timePassed;
    private bool charged;
    private bool canCharge = true;
    private bool canFreeze;
    private Image fill;
    private BallLauncher louncher;

    // Start is called before the first frame update
    void Start()
    {
        if (!GameManager.instance.isPerkOneActive)
            gameObject.SetActive(false);
        fill = transform.Find("Fill").gameObject.GetComponent<Image>();
        louncher = GameObject.FindGameObjectWithTag("Louncher").GetComponent<BallLauncher>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageFill();
    }

    public void ActivateFreeze()
    {
        if (canFreeze)
        {
            GameManager.instance.FreezeTow();
            canCharge = false;
            canFreeze = false;
        }
    }
    public void ResetFreeze()
    {
        if (charged && !canCharge)
        {
            charged = false;
            canCharge = true;
        }
    }

    private void ManageFill()
    {
        if (!charged && canCharge)
        {
            timePassed += Time.deltaTime;

            if (timePassed <= reloadTime && canCharge)
                fill.fillAmount = 1 - (timePassed / reloadTime);
            else
            {
                charged = true;
                canFreeze = true;
                timePassed = 0;
            }
        }

        if (charged && louncher.isOcupied)
        {
            fill.fillAmount = 0;
            canFreeze = true;
        }
        else if (charged && !louncher.isOcupied)
        {
            fill.fillAmount = 1;
            canFreeze = false;
        }
        if (!canCharge && !charged)
        {
            fill.fillAmount = 1;
            
        }
    }
}
