using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    private float maxSpeed = 10f;
    private float speed;
    private GameObject theBall;
    private Ball ballScript;

    private Rigidbody2D ballRb;

    private bool isOcupied = false;

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

    private GameObject noBall;


    void Start()
    {
        ActivateControls();
        SetSpeed();
        trajScript = trajectory.GetComponent<Trajectory>();
        trajAnimation = trajectory.GetComponent<Animator>();
        trajLine = trajectory.GetComponent<LineRenderer>();
        noBall = transform.Find("noBall").gameObject;

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
            Quaternion theRotation = Quaternion.AngleAxis(angleDegrees - 90f, Vector3.forward);
            theBall.transform.rotation = theRotation;
            speed = maxSpeed * context.ReadValue<Vector2>().magnitude;
            fireSpeed = theBall.transform.up * speed;
            if (!isTrajActive)
            {
                isTrajActive = true;
                trajScript.EnableRenderer();
                trajScript.copyAllObstacles();
            }

            trajLine.colorGradient = newGradient(context.ReadValue<Vector2>().magnitude);
            trajLine.endWidth = 0.3f * context.ReadValue<Vector2>().magnitude;
            trajScript.predict(dummy, theBall.transform.position, fireSpeed, theRotation);
            trajAnimation.speed = speed / 2f;

        }
        
    }

    private Gradient newGradient(float speed)
    {
        float startAlpha = 1f;
        float alpha = 1f;
        Color startColor = new Color(1, 1 - speed, 1 - speed);
        Color endColor = new Color(1, 1 - speed, 1 - speed);
        Gradient newGradient = new Gradient();
        newGradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(startColor, 0.5f), new GradientColorKey(endColor, 0.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(startAlpha, 0f), new GradientAlphaKey(alpha, 1f) }
        );
        return newGradient;
    }

    public void Shoot(InputAction.CallbackContext context)
    {

        if (isOcupied)
        {
            ballScript.Shoot();
            ballRb.constraints = RigidbodyConstraints2D.None;
            ballRb.AddRelativeForce(transform.up * speed, ForceMode2D.Impulse);
            isTrajActive = false;
            trajScript.DisableRenderer();
            trajScript.killAllObstacles();
            CleanLouncher();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOcupied)
        {
            theBall = collision.gameObject;
            ballScript = theBall.GetComponent<Ball>();
            ballRb = theBall.GetComponent<Rigidbody2D>();
            if (!ballScript.isShot)
            {
                ballScript.LounchPos();
                noBall.SetActive(false);
            }
            isOcupied = true;
            
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
        noBall.SetActive(true);
        StartCoroutine(noBall.GetComponent<NoBall>().BlipOut());
    }

    private void SetSpeed()
    {
        maxSpeed = GameManager.instance.ballPower;
    }

}
