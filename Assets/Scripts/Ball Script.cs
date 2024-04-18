using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallScript : MonoBehaviour
{
    private float speed = 10f;
    private float bounceForce = 250f;

    public float chargeTime = 2f;
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


    // Start is called before the first frame update
    void Awake()
    {
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
    }

    // Update is called once per frame
    void Update()
    {
        LounchPosition();
        
        if (charging)
        {
            timePassed += Time.deltaTime;
            ballUI.SetCharge(timePassed / chargeTime);
            if (timePassed > chargeTime)
            {
                UI.SetActive(false);
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
        }
    }

    private void Shoot()
    {
        if (lounchPos)
        {
            lounchPos = false;
            ballRb.constraints = RigidbodyConstraints2D.None;
            ballRb.AddForce(transform.up * speed, ForceMode2D.Impulse);
            magScript.cocked = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceDirection = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y).normalized;
        ballRb.AddForce(bounceDirection * bounceForce);
        if (!collision.gameObject.CompareTag("Walls") && !collision.gameObject.CompareTag("Player"))
            collision.gameObject.GetComponent<PegScript>().FadeOut();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
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
            lounchPos = true;
        else
            lounchPos = false;
    }
}
