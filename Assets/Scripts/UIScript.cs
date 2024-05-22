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
        SetColors();
        

        touch.started += ActivateJoystick;
        touch.canceled += DeactivateJoystic;
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
            GameManager.instance.LevelSelect(5);
        else
        GameManager.instance.LevelSelect(0);
    }

    public void ActivateGameOverUI()
    {
        gameOver.SetActive(true);
        joystick.SetActive(false);
        actionMap.Disable();
    }

    public void SetGold(int amount)
    {
        goldText.SetText(amount.ToString());
    }

    private void SetColors()
    {
        filledJoy = joyImage.color;
        TransparentJoy = filledJoy;
        TransparentJoy.a = 0.05f;
        filledJoy.a = 1f;
    }


}
