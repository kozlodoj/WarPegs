using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private GameObject firstScreen;
    [SerializeField]
    private GameObject secondScreen;
    [SerializeField]
    private GameObject thirdScreen;
    [SerializeField]
    private GameObject fourthScreen;
    private GameObject thirdBG;
    public bool canUseJoy = false;
    private LayoutManager pegManager;
    [SerializeField]
    private GameObject bLouncher;
    private BallLauncher louncher;
    public int tutCounter = 0;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        pegManager = GameObject.Find("Peggle").GetComponent<LayoutManager>();
        louncher = bLouncher.GetComponent<BallLauncher>();
        thirdBG = thirdScreen.transform.Find("BG").gameObject;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        GameManager.instance.PauseGame();
  
    }


    public void Next()
    {
        if (tutCounter == 0)
        {
            firstScreen.SetActive(false);
            GameManager.instance.ResumeGame();
            canUseJoy = true;
            tutCounter++;
            StartCoroutine(WaitUntilCharged());
        }
        else if (tutCounter == 1)
        {
            secondScreen.SetActive(false);
            GameManager.instance.ResumeGame();
            canUseJoy = true;
            tutCounter++;
        }
        else if (tutCounter == 2)
        {
            thirdScreen.SetActive(false);
            GameManager.instance.ResumeGame();
            canUseJoy = true;
            tutCounter++;
            StartCoroutine(WaitUntilCharged());
        }
        else if (tutCounter == 3)
        {
            fourthScreen.SetActive(false);
            GameManager.instance.ResumeGame();
            canUseJoy = true;
            tutCounter++;
        }

    }

    private IEnumerator WaitUntilCharged()
    {
        while (!louncher.isOcupied)
            yield return null;
        if (tutCounter == 1)
        {
            secondScreen.SetActive(true);
            GameManager.instance.PauseGame();
            canUseJoy = false;
        }
        else if (tutCounter == 3)
        {
            fourthScreen.SetActive(true);
            GameManager.instance.PauseGame();
            pegManager.UpdateLaout();
            canUseJoy = false;
        }
    }

    public void BallHit(Vector2 pos)
    {
        thirdScreen.SetActive(true);
        GameManager.instance.PauseGame();
        canUseJoy = false;
        var newPos = new Vector2(cam.WorldToScreenPoint(pos).x, cam.WorldToScreenPoint(pos).y);
        thirdBG.transform.position = newPos;
    }
}
