using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    

    // Start is called before the first frame update
    void Start()
    {
        ballUI = UI.GetComponent<BallUI>();
        mag = GameObject.Find("Mag");
        launcher = GameObject.Find("Launcher");
        lastSlot = GameObject.Find("Slot02").transform.position;
        magScript = mag.GetComponent<Mag>();
        ballRb = gameObject.GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        LounchPosition();
        Aim();
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

    private void Aim()
    {
        if (lounchPos)
        {
            target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 difference = target - (Vector2)gameObject.transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            gameObject.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ + 90f);

            if (Input.GetMouseButtonDown(0))
                Shoot(difference.normalized);
        }
    }

    private void Shoot(Vector2 direction)
    {
        lounchPos = false;
        ballRb.constraints = RigidbodyConstraints2D.None;
        ballRb.AddForce(direction * speed, ForceMode2D.Impulse);
        magScript.cocked = false;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceDirection = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y).normalized;
        ballRb.AddForce(bounceDirection * bounceForce);
        if (!collision.gameObject.CompareTag("Walls") && !collision.gameObject.CompareTag("Player"))
            collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
            ResetBall();

    }

    private void ResetBall()
    {
        isCharged = false;
        charging = false;
        timePassed = 0;
        ballRb.constraints = RigidbodyConstraints2D.FreezeAll;
        transform.position = lastSlot;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);


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
