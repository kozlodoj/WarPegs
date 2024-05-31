using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirePerk : MonoBehaviour
{
    public float reloadTime;
    private float timePassed;
    private bool charged;
    private bool canFreeze;
    private Image fill;
    private BallLauncher louncher;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.storyMode && !GameManager.instance.isPerkTwoActive)
            gameObject.SetActive(false);
        reloadTime = GameManager.instance.perkTwoRecharge;
        fill = transform.Find("Fill").gameObject.GetComponent<Image>();
        louncher = GameObject.FindGameObjectWithTag("Louncher").GetComponent<BallLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        ManageFill();
    }
    public void ActivateFire()
    {
        if (canFreeze)
        {
            louncher.FirePerk();
            ResetFreeze();
            canFreeze = false;
        }
    }
    public void ResetFreeze()
    {
        if (charged)
        {
            charged = false;
            timePassed = 0;
        }
    }

    private void ManageFill()
    {
        if (!charged)
        {
            timePassed += Time.deltaTime;

            if (timePassed <= reloadTime)
                fill.fillAmount = 1 - (timePassed / reloadTime);
            else
            {
                charged = true;
                canFreeze = true;
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
    }

}
