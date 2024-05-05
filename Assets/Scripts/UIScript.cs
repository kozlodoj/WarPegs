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
        
        //DontDestroyOnLoad(gameObject);

    }



    private void ActivateJoystick (InputAction.CallbackContext context)
        {
        joystick.transform.position = context.ReadValue<Vector2>();
       
        }


    public void BackToMenu()
    {
        GameManager.instance.LevelSelect(0);
    }

    public void ActivateGameOverUI()
    {
        gameOver.SetActive(true);
    }



}
