using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    private float speed = 10f;
    private float bounceForce = 250f;

    private float chargeTime = 5f;
    public bool isCharged = false;

    private float timePassed = 0f;
    private bool charging = false;

    private Rigidbody2D ballRb;

    private Vector2 target;
    private Vector2 bounceDirection;

    private bool lounchPos = false;
    public bool inMag = true;

    [SerializeField]
    private GameObject mag;

    private Mag magScript;

    private GameObject launcher;
    private Vector2 lastSlot;

    [SerializeField]
    private GameObject UI;
    private BallUI ballUI;

    [SerializeField]
    private InputActionAsset controlsAsset;
    private InputActionMap actionMap;
    private InputAction aim;
    private InputAction touch;
    [SerializeField]
    private GameObject trajectory;
    private Trajectory trajScript;
    [SerializeField]
    private GameObject dummy;
    [SerializeField]
    private bool isDummy;

    private PegScript peg;

    private bool isTrajActive = false;

    private float buffRate = 1f;
    private float buffPoints = 0;

    
    void Awake()
    {
        speed = GameManager.instance.ballPower;
        chargeTime = GameManager.instance.reloadRate;

        ballUI = UI.GetComponent<BallUI>();
        mag = GameObject.Find("Mag");
        launcher = GameObject.Find("Launcher");
        lastSlot = GameObject.Find("Slot02").transform.position;
        magScript = mag.GetComponent<Mag>();
        ballRb = gameObject.GetComponent<Rigidbody2D>();

        actionMap = controlsAsset.FindActionMap("Player");
        aim = actionMap.FindAction("Aim");
        touch = actionMap.FindAction("Touch");

        aim.performed += context => LookDirection(context);
        touch.canceled += context => Shoot();

        trajectory = GameObject.Find("Trajectory");
        trajScript = trajectory.GetComponent<Trajectory>();

   

    }

    
    void Update()
    {
        LounchPosition();
        
        if (charging)
        {
            timePassed += Time.deltaTime;
            ballUI.SetCharge(timePassed / chargeTime);
            if (timePassed > chargeTime)
            {
                
                isCharged = true;
                charging = false;
                
            }
        }


    }

    private void LookDirection(InputAction.CallbackContext context)
    {
        if (lounchPos)
        {
            float angleRadians = Mathf.Atan2(-context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x);
            float angleDegrees = -angleRadians * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angleDegrees - 90f, Vector3.forward);
            if (!isTrajActive)
            {
                isTrajActive = true;
                EnableLine();
                CopyObstacles();
            }
            Predict();
        }
    }

    public void Shoot()
    {
        if (lounchPos)
        {
            lounchPos = false;
            ballRb.constraints = RigidbodyConstraints2D.None;
            ballRb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            magScript.cocked = false;
            DisableLine();
            KillObstacles();

         
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (!collision.gameObject.CompareTag("Walls"))
        {
            if (!collision.gameObject.CompareTag("Walls") && !collision.gameObject.CompareTag("Player") && !isDummy)
            {
                peg = collision.gameObject.GetComponent<PegScript>();
                buffPoints += peg.buffPoints;

                ballUI.SetBuffText(buffPoints);
                peg.FadeOut();
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom") && !isDummy)
            ResetBall();

    }

    private void ResetBall()
    {
        
        Destroy(gameObject);

    }

    public void ActivateCharging()
    {
        UI.SetActive(true);
        ballUI.SetCharge(timePassed / chargeTime);
        charging = true;

    }
    private void LounchPosition()
    {
        if (gameObject.transform.position == launcher.transform.position)
        {
            lounchPos = true;
            ballUI.DisactivateChargebar();
        }
        else
            lounchPos = false;
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
    public float GetBuff()
    {
        return buffRate += buffPoints / 100f;
    }
}
