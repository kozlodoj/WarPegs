using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
 
    private GameObject ball;
    private Rigidbody2D ballRb;
    private float speed = 10f;

    [SerializeField]
    private InputActionAsset controlsAsset;
    private InputActionMap actionMap;
    private InputAction aim;
    private InputAction touch;

    private bool lounchPos = false;

    [SerializeField]
    private GameObject trajectory;
    private Trajectory trajScript;

    private bool isTrajActive = false;

    [SerializeField]
    private GameObject dummy;


    private void Start()
    {
        GetControls();
        trajScript = trajectory.GetComponent<Trajectory>();
       
    }

    public void SetBall(GameObject theBall)
    {
        ball = theBall;
        ballRb = ball.GetComponent<Rigidbody2D>();
        lounchPos = true;
        
    }

    private void GetControls()
    {
        actionMap = controlsAsset.FindActionMap("Player");
        aim = actionMap.FindAction("Aim");
        touch = actionMap.FindAction("Touch");

        aim.performed += context => LookDirection(context);
        touch.canceled += context => Shoot(speed);
    }
    private void LookDirection(InputAction.CallbackContext context)
    {
        if (lounchPos)
        {
            //UpdateStats();
            float angleRadians = Mathf.Atan2(-context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x);
            float angleDegrees = -angleRadians * Mathf.Rad2Deg;
            ball.transform.rotation = Quaternion.AngleAxis(angleDegrees - 90f, Vector3.forward);
            //speed *= Mathf.Abs(context.ReadValue<Vector2>().x);

            if (!isTrajActive)
            {
                isTrajActive = true;
                EnableLine();
                CopyObstacles();
            }
            Predict();
        }
    }
    public void Shoot(float speed)
    {
        if (lounchPos)
        {
            Debug.Log("Shot Speed " + speed);
            lounchPos = false;
            ballRb.constraints = RigidbodyConstraints2D.None;
            ballRb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            DisableLine();
            KillObstacles();


        }

    }

    private void Predict()
    {
        trajScript.predict(dummy, transform.position, transform.up * speed);

    }
    private void EnableLine()
    {
        trajScript.EnableRenderer();
    }
    private void DisableLine()
    {
        trajScript.DisableRenderer();
    }
    private void KillObstacles()
    {
        trajScript.killAllObstacles();
    }
    private void CopyObstacles()
    {
        trajScript.copyAllObstacles();
    }

}
