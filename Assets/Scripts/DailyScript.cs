using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DailyScript : MonoBehaviour
{

    private Animator dailyAnimator;
    private UIScript ui;

    // Start is called before the first frame update
    void Start()
    {
        dailyAnimator = gameObject.GetComponent<Animator>();
        ui = GameObject.Find("UI").GetComponent<UIScript>();
    }

    public void DailyDoneAnimate()
    {
        dailyAnimator.SetBool("dailyDone", true);
    }
    public void StopAnimation()
    {
        dailyAnimator.SetBool("dailyDone", false);
        ui.DailyDelay();
    }
}
