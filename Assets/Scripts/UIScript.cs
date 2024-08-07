using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.InputSystem;
using UnityEditor;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    private GameObject joystick;
    private Image joyImage;
    [SerializeField]
    private GameObject joyOutline;
    private Image outlineImage;

    private Color filledJoy;
    private Color TransparentJoy;

    [SerializeField]
    private InputActionAsset controlsAsset;
    private InputActionMap actionMap;
    private InputAction touch;

    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameObject pauseMenu;
    [SerializeField]
    private GameObject pauseButton;
    private GameObject doubleButton;
    private TextMeshProUGUI currentCoin;
    private TextMeshProUGUI currentCoinPause;

    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI goldCollectedText;
    [SerializeField]
    private TextMeshProUGUI diamondText;
    [SerializeField]
    private GameObject tutorial;
    private Tutorial tutScript;
    [SerializeField]
    private GameObject daily;
    private TextMeshProUGUI dailyText;
    private TextMeshProUGUI rewardText;
    private bool animationPlaying = false;
    [SerializeField]
    private BallLauncher louncher;

    private float joyStickLine;
    private Transform topUI;

    public Vector3 counterPosition;
    public GameObject coin;

    public bool isEvent;

    private void OnEnable()
    {
        actionMap.Enable();
    }

    private void OnDisable()
    {
        actionMap.Disable();
        touch.started -= ActivateJoystick;
        touch.canceled -= DeactivateJoystic;
        Destroy(gameObject);
        
    }
    private void Awake()
    {

        actionMap = controlsAsset.FindActionMap("Player");
        touch = actionMap.FindAction("Touch");
        joyImage = joystick.GetComponent<Image>();
        outlineImage = joyOutline.GetComponent<Image>();
        topUI = gameObject.transform.Find("TopBG").transform;
        var offsetUI = topUI.localPosition + GameManager.instance.topUIoffset;
        topUI.localPosition = offsetUI;
        joyStickLine = Screen.height / 1.6f;
        counterPosition = Camera.main.ScreenToWorldPoint(topUI.transform.Find("Gold collected").gameObject.transform.position);
        counterPosition.z = 0;
        if (GameManager.instance.storyMode)
        {
            currentCoin = gameOver.transform.Find("gold").gameObject.GetComponent<TextMeshProUGUI>();
            doubleButton = gameOver.transform.Find("X2").gameObject;
            currentCoinPause = pauseMenu.transform.Find("gold").gameObject.GetComponent<TextMeshProUGUI>();
            if (GameManager.instance.dailyNum != 69 && !isEvent)
            {
                dailyText = daily.transform.Find("Daily text").GetComponent<TextMeshProUGUI>();
                rewardText = daily.transform.Find("Reward text").GetComponent<TextMeshProUGUI>();
            }
            else
                daily.SetActive(false);
        }
        //SetColors();
        if (!GameManager.instance.tutorial && !isEvent)
            ManageDaily(false);
        else
            daily.SetActive(false);

        touch.started += ActivateJoystick;
        touch.canceled += DeactivateJoystic;
        if (GameManager.instance.storyMode && !isEvent)
        {
            SetGold(GameManager.instance.gold);
            SetCollectedGold(GameManager.instance.currentGold);
            SetDiamonds(GameManager.instance.diamonds);
            if (GameManager.instance.tutorial)
            {
                StartCoroutine(StartTutorial());
            }
        }
        else
        {
            SetGold(EventManager.instance.gold);
            SetCollectedGold(EventManager.instance.currentGold);
            SetDiamonds(GameManager.instance.diamonds);
        }

    }



    private void ActivateJoystick (InputAction.CallbackContext context)
        {
       
            if (context.ReadValue<Vector2>().y <= joyStickLine)
            {
            if (GameManager.instance.tutorial)
                tutorial.SetActive(false);
                GameManager.instance.joyStickActive = true;
                joystick.transform.position = context.ReadValue<Vector2>();
                //joyImage.color = filledJoy;
                //joyOutline.transform.position = context.ReadValue<Vector2>();
                //joyOutline.SetActive(true);
            }

    }
    private void DeactivateJoystic(InputAction.CallbackContext context)
    {
        GameManager.instance.joyStickActive = false;
        joystick.transform.position = context.ReadValue<Vector2>();
        //joyImage.color = TransparentJoy;
        //joyOutline.SetActive(false);
    }


    public void BackToMenu()
    {
        if (GameManager.instance.storyMode && !isEvent)
            GameManager.instance.LevelSelect(0);
        else if (isEvent)
        {
            GameManager.instance.LevelSelect(1);
        }
    }

    public void ActivateGameOverUI()
    {
        
        gameOver.SetActive(true);
        joystick.SetActive(false);
        pauseButton.SetActive(false);
        if (!isEvent)
        {
            if (GameManager.instance.currentGold == 0)
            {
                GameManager.instance.currentGold += 9;
                GameManager.instance.gold += 9;
                currentCoin.SetText(GameManager.instance.RoundedNum(GameManager.instance.currentGold));
            }
        }
        else
        {
            if (EventManager.instance.currentGold == 0)
            {
                EventManager.instance.currentGold += 9;
                EventManager.instance.gold += 9;
                currentCoin.SetText(GameManager.instance.RoundedNum(EventManager.instance.currentGold));
            }
        }
        if (GameManager.instance.tutorial)
        {
            doubleButton.SetActive(false);
        }
        GameManager.instance.tutorial = false;
        actionMap.Disable();
    }
    public void PauseGame()
    {
        GameManager.instance.PauseGame();
        if(!isEvent)
        currentCoinPause.SetText(GameManager.instance.RoundedNum(GameManager.instance.currentGold));
        else
            currentCoinPause.SetText(GameManager.instance.RoundedNum(EventManager.instance.currentGold));
        pauseMenu.SetActive(true);
        KillOutline();
        actionMap.Disable();
        joystick.SetActive(false);
    }
    public void ResumeGame()
    {
        GameManager.instance.ResumeGame();
        pauseMenu.SetActive(false);
        joystick.SetActive(true);
        actionMap.Enable();
    }

    public void SetGold(int amount)
    {
        if (GameManager.instance.storyMode && !isEvent)
        {
            goldText.SetText(GameManager.instance.RoundedNum(amount));
            currentCoin.SetText(GameManager.instance.RoundedNum(GameManager.instance.currentGold));
        }
        else
        {
            goldText.SetText(GameManager.instance.RoundedNum(amount));
            currentCoin.SetText(GameManager.instance.RoundedNum(EventManager.instance.currentGold));
        }
    }
    public void SetCollectedGold(int amount)
    {
        if (!isEvent)
            currentCoin.SetText(GameManager.instance.RoundedNum(GameManager.instance.currentGold));
        else
            currentCoin.SetText(GameManager.instance.RoundedNum(EventManager.instance.currentGold));
        if (amount == 0)
                goldCollectedText.SetText(amount.ToString());
            else
                StartCoroutine(CollectedTextUpdate(amount));
   
   
    }
    private IEnumerator CollectedTextUpdate(int amount)
    {
        yield return new WaitForSeconds(coin.GetComponent<Coin>().speed * 1.3f);
        goldCollectedText.SetText(GameManager.instance.RoundedNum(amount));
        
    }
    public void SetDiamonds(int amount)
    {
        if (GameManager.instance.storyMode)
        {
            diamondText.SetText(GameManager.instance.RoundedNum(amount));
        }
    }

    private void SetColors()
    {
        filledJoy = joyImage.color;
        TransparentJoy = filledJoy;
        TransparentJoy.a = 0.05f;
        filledJoy.a = 1f;
    }

    private IEnumerator StartTutorial()
    {
        while (!louncher.isOcupied)
        yield return null;
        tutorial.SetActive(true);
        GameManager.instance.FreezeTow();
        GameManager.instance.freezeGame = true;
        while (louncher.isOcupied)
            yield return null;
        GameManager.instance.UnFreezeTow();
        GameManager.instance.freezeGame = false;

    }
    public void KillOutline()
    {
        joyOutline.SetActive(false);
    }

    public void DoubleGold()
    {
        if(!isEvent)
        GameManager.instance.AddGold(GameManager.instance.currentGold);
        else
            EventManager.instance.AddGold(EventManager.instance.currentGold);
        BackToMenu();
    }
    public void ManageDaily(bool isDone)
    {
        if (!isEvent)
        {
            if (GameManager.instance.dailyNum != 69 && !GameManager.instance.tutorial)
            {
                if (GameManager.instance.dailyNum == 1 && !animationPlaying)
                {
                    dailyText.SetText("Gold collected " + GameManager.instance.goldCollected + "/100");
                    rewardText.SetText("40");
                    if (isDone)
                    {
                        dailyText.SetText("Gold collected 100/100");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;

                    }
                }
                else if (GameManager.instance.dailyNum == 2 && !animationPlaying)
                {
                    dailyText.SetText("Ball bounces " + GameManager.instance.bounces + "/150");
                    rewardText.SetText("50");
                    if (isDone)
                    {
                        dailyText.SetText("Ball bounces 150/150");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;

                    }
                }
                else if (GameManager.instance.dailyNum == 3 && !animationPlaying)
                {
                    dailyText.SetText("Balls shot " + GameManager.instance.ballsShot + "/15");
                    rewardText.SetText("40");
                    if (isDone)
                    {
                        dailyText.SetText("Balls shot 10/10");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;

                    }
                }
                else if (GameManager.instance.dailyNum == 4 && !animationPlaying)
                {
                    dailyText.SetText("Archer spawned " + GameManager.instance.unitTwoSpawned + "/15");
                    rewardText.SetText("50");
                    if (isDone)
                    {
                        dailyText.SetText("Archer spawned 15/15");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;

                    }
                }
                else if (GameManager.instance.dailyNum == 5 && !animationPlaying)
                {
                    dailyText.SetText("Enemies defeated " + GameManager.instance.enemiesDefeated + "/20");
                    rewardText.SetText("50");
                    if (isDone)
                    {
                        dailyText.SetText("Enemies defeated 20/20");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;

                    }
                }
                else if (GameManager.instance.dailyNum == 6 && !animationPlaying)
                {
                    dailyText.SetText("Heavy spawned " + GameManager.instance.unitThreeSpawned + "/7");
                    rewardText.SetText("70");
                    if (isDone)
                    {
                        dailyText.SetText("Enemies defeated 7/7");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;

                    }
                }
                else if (GameManager.instance.dailyNum == 7 && !animationPlaying)
                {
                    dailyText.SetText("X2 buff gained " + GameManager.instance.buffGathered + "/1");
                    rewardText.SetText("100");
                    if (isDone)
                    {
                        dailyText.SetText("X2 buff gained 1/1");
                        daily.GetComponent<DailyScript>().DailyDoneAnimate();
                        animationPlaying = true;
                        DailyDone();

                    }
                }
            }
        }
    }

    public void DailyDelay()
    {
        
            GameManager.instance.dailyNum++;
            animationPlaying = false;
            if (GameManager.instance.dailyNum > 7)
                daily.SetActive(false);
            ManageDaily(false);
    }

    public void DailyDone()
    {
        daily.SetActive(false);
        GameManager.instance.dailyNum = 69;
    }


}
