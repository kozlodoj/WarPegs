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
    private TextMeshProUGUI currentCoin;

    [SerializeField]
    private TextMeshProUGUI goldText;
    

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
        if(GameManager.instance.storyMode)
        currentCoin = gameOver.transform.Find("gold").gameObject.GetComponent<TextMeshProUGUI>();
        SetColors();
        

        touch.started += ActivateJoystick;
        touch.canceled += DeactivateJoystic;
        if(GameManager.instance.storyMode)
        SetGold(GameManager.instance.gold);

    }



    private void ActivateJoystick (InputAction.CallbackContext context)
        {
        if (context.ReadValue<Vector2>().y <= 1200)
        {
            joystick.transform.position = context.ReadValue<Vector2>();
            joyImage.color = filledJoy;
            joyOutline.transform.position = context.ReadValue<Vector2>();
            joyOutline.SetActive(true);
        }

    }
    private void DeactivateJoystic(InputAction.CallbackContext context)
    {
        joystick.transform.position = context.ReadValue<Vector2>();
        joyImage.color = TransparentJoy;
        joyOutline.SetActive(false);
    }


    public void BackToMenu()
    {
        if(GameManager.instance.storyMode)
            GameManager.instance.LevelSelect(0);
        else
        GameManager.instance.LevelSelect(5);
    }

    public void ActivateGameOverUI()
    {
        gameOver.SetActive(true);
        joystick.SetActive(false);
        actionMap.Disable();
    }

    public void SetGold(int amount)
    {
        if (GameManager.instance.storyMode)
        {
            goldText.SetText(amount.ToString());
            currentCoin.SetText(GameManager.instance.currentGold.ToString());
        }
    }

    private void SetColors()
    {
        filledJoy = joyImage.color;
        TransparentJoy = filledJoy;
        TransparentJoy.a = 0.05f;
        filledJoy.a = 1f;
    }


}
