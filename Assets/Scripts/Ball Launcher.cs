using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    private float maxSpeed = 10f;
    private float speed;
    private Quaternion theRotation;
    private float theMagnitude;
    private GameObject theBall;
    private Ball ballScript;

    private Rigidbody2D ballRb;

    public bool isOcupied = false;

    [SerializeField]
    private InputActionAsset controlsAsset;
    private InputActionMap actionMap;
    private InputAction aim;

    [SerializeField]
    private GameObject trajectory;
    private Trajectory trajScript;
    private bool isTrajActive = false;
    [SerializeField]
    private GameObject dummy;
    private Animator trajAnimation;
    private LineRenderer trajLine;
    private Vector2 fireSpeed;
    private Animator animator;

    private GameObject noBall;
    private GameObject ready;
    private GameObject ghostBall;
    private GameObject backButton;


    void Start()
    {
        ActivateControls();
        SetSpeed();
        trajScript = trajectory.GetComponent<Trajectory>();
        trajAnimation = trajectory.GetComponent<Animator>();
        trajLine = trajectory.GetComponent<LineRenderer>();
        animator = gameObject.GetComponent<Animator>();
        noBall = transform.Find("noBall").gameObject;
        ready = transform.Find("Ready").gameObject;
        ghostBall = transform.Find("GhostBall").gameObject;
        backButton = GameObject.Find("UI").transform.Find("TopBG").gameObject.transform.Find("Back").gameObject;
        if (GameManager.instance.tutorial)
            backButton.SetActive(false);

    }

    private void OnDisable()
    {
        aim.performed -= LookDirection;
        aim.canceled -= Shoot;
    }

    private void LookDirection(InputAction.CallbackContext context)
    {

        if (isOcupied)
        {
            float angleRadians = Mathf.Atan2(-context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x);
            float angleDegrees = -angleRadians * Mathf.Rad2Deg;
            theRotation = Quaternion.AngleAxis(angleDegrees - 90f, Vector3.forward);
            theBall.transform.rotation = theRotation;
            theMagnitude = context.ReadValue<Vector2>().magnitude;
            speed = maxSpeed * theMagnitude;
            fireSpeed = theBall.transform.up * speed;
            if (!isTrajActive)
            {
                isTrajActive = true;
                trajScript.EnableRenderer();
                if(!ballScript.onFire)
                trajScript.copyAllObstacles();
            }

            trajLine.colorGradient = newGradientGreen(theMagnitude);
            trajLine.endWidth = 0.3f * theMagnitude;
            trajScript.predict(dummy, theBall.transform.position, fireSpeed, theRotation);
            trajAnimation.speed = speed / 2f;

        }
        else
        {
            float angleRadians = Mathf.Atan2(-context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x);
            float angleDegrees = -angleRadians * Mathf.Rad2Deg;
            theRotation = Quaternion.AngleAxis(angleDegrees - 90f, Vector3.forward);
            ghostBall.transform.rotation = theRotation;
            theMagnitude = context.ReadValue<Vector2>().magnitude;
            speed = maxSpeed * theMagnitude;
            fireSpeed = ghostBall.transform.up * speed;
            if (!isTrajActive)
            {
                isTrajActive = true;
                trajScript.EnableRenderer();
                trajScript.copyAllObstacles();
            }
            trajLine.colorGradient = newGradient(theMagnitude);
            trajLine.endWidth = 0.3f * theMagnitude;
            trajScript.predict(dummy, ghostBall.transform.position, fireSpeed, theRotation);
            trajAnimation.speed = speed / 2f;
        }
        
    }

    private Gradient newGradient(float speed)
    {
        float startAlpha = 0.3f;
        float alpha = 0.3f;
        Color startColor = new Color(1, 1 - speed, 1 - speed);
        Color endColor = new Color(1, 1 - speed, 1 - speed);
        Gradient newGradient = new Gradient();
        newGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(startColor, 0.5f), new GradientColorKey(endColor, 0.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(startAlpha, 0f), new GradientAlphaKey(alpha, 1f) }
        );
        return newGradient;
    }
    private Gradient newGradientGreen(float speed)
    {
        float startAlpha = 1f;
        float alpha = 1f;
        Color startColor = new Color(1 - speed, 1, 1 - speed);
        Color endColor = new Color(1 - speed, 1, 1 - speed);
        Gradient newGradient = new Gradient();
        newGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(startColor, 0.5f), new GradientColorKey(endColor, 0.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(startAlpha, 0f), new GradientAlphaKey(alpha, 1f) }
        );
        return newGradient;
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        
        if (isOcupied && !GameManager.instance.joyStickActive)
        {
            ballScript.Shoot();
            ballRb.constraints = RigidbodyConstraints2D.None;
            theBall.transform.rotation = theRotation;
            ballRb.AddRelativeForce(transform.up * speed, ForceMode2D.Impulse);
            isTrajActive = false;
            trajScript.DisableRenderer();
            trajScript.killAllObstacles();
            CleanLouncher();
            GameManager.instance.ballsShot++;
            GameManager.instance.ManageDaily();
        }
        else if (!GameManager.instance.joyStickActive)
        {
            isTrajActive = false;
            trajScript.DisableRenderer();
            trajScript.killAllObstacles();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Fire"))
        {
            if (!isOcupied)
            {
                theBall = collision.gameObject;
                ballScript = theBall.GetComponent<Ball>();
                ballRb = theBall.GetComponent<Rigidbody2D>();
                if (!ballScript.isShot)
                {
                    ballScript.LounchPos();
                    theBall.transform.rotation = theRotation;
                    if (isTrajActive)
                        trajLine.colorGradient = newGradientGreen(theMagnitude);
                    //noBall.SetActive(false);
                    //ready.SetActive(true);
                    isOcupied = true;
                    animator.SetBool("isLoaded", true);
                    animator.SetBool("isCharging", false);
                    Vibration.Vibrate();
                }
                if (ballScript.isShot)
                    theBall = null;

            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == theBall)
        {
            isOcupied = false;
        }
    }

    private void ActivateControls()
    {
        actionMap = controlsAsset.FindActionMap("Player");
        aim = actionMap.FindAction("Aim");
        aim.performed += LookDirection;
        aim.canceled += Shoot;
    }
    private void CleanLouncher()
    {
        theBall = null;
        ballScript = null;
        ballRb = null;
        isOcupied = false;
        animator.SetBool("isCharging", true);
        //noBall.SetActive(true);
        //ready.SetActive(false);

    }

    private void SetSpeed()
    {
        maxSpeed = GameManager.instance.ballPower;
    }
    public void FirePerk()
    {
        if (isOcupied)
            ballScript.FirePerk();
    }
    public void StopAnimation()
    {
        animator.SetBool("isLoaded", false);
    }


}
