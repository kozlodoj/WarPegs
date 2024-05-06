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
        touch.performed -= ActivateJoystick;
        Destroy(gameObject);
        
    }
    private void Awake()
    {

        actionMap = controlsAsset.FindActionMap("Player");
        touch = actionMap.FindAction("Touch");

        touch.performed += ActivateJoystick;
        SetGold(GameManager.instance.gold);

    }



    private void ActivateJoystick (InputAction.CallbackContext context)
        {
        joystick.transform.position = context.ReadValue<Vector2>();
       
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
    }

    public void SetGold(int amount)
    {
        goldText.SetText("Gold: " + amount);
    }



}
