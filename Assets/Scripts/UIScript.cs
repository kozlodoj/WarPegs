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

    private void OnEnable()
    {
        actionMap.Enable();
    }

    private void OnDisable()
    {
        actionMap.Disable();
    }
    private void Awake()
    {

        actionMap = controlsAsset.FindActionMap("Player");
        touch = actionMap.FindAction("Touch");

        

        touch.performed += context => ActivateJoystick(context);
        //touch.canceled += context => DisactivateJoystick();
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void ActivateJoystick (InputAction.CallbackContext context)
        {
        joystick.transform.position = context.ReadValue<Vector2>();
       
        }

    private void DisactivateJoystick()
    {
        joystick.gameObject.SetActive(false);
        
    }

    public void BackToMenu()
    {
        GameManager.instance.LevelSelect(0);
    }



}
