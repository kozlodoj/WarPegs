using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private Image ballReadyBar;
    [SerializeField]
    private TextMeshProUGUI readyText;
    [SerializeField]
    private List<Image> ballSlots = new List<Image>();

    private bool ballReady = false;
    private float ballSpawnDelay = 5f;
    private float timeAfterLastBall = 0f;

    // Update is called once per frame
    void Update()
    {
        if (!ballReady)
        {
            ManageTime();
            BarFill(timeAfterLastBall);
        }
    }

    public void SetBallReadyTimerUI(float timeToNextBall)
    {
        ballSpawnDelay = timeToNextBall;
    }
    public void ResetBallTimer()
    {
        ballReady = false;
        ActivateReadyText(ballReady);
        timeAfterLastBall = 0f;
    }

    private void ManageTime()
    {
        timeAfterLastBall += Time.deltaTime;
        if (timeAfterLastBall >= ballSpawnDelay)

            ballReady = true;
        ActivateReadyText(ballReady);

    }
    private void BarFill(float timeLeft)
    {
        ballReadyBar.fillAmount = timeLeft / ballSpawnDelay;
    }
    private void ActivateReadyText(bool activate)
    {
        readyText.gameObject.SetActive(activate);
    }


}
