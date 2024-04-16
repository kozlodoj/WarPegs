using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private float speed = 10f;
    private float bounceForce = 250f;

    private Rigidbody2D ballRb;

    private Vector2 target;
    private Vector2 bounceDirection;
    private Vector2 startPosition;

    private bool lounchPos = true;

    [SerializeField]
    private GameObject mag;

    private Mag magScript;

    // Start is called before the first frame update
    void Start()
    {
        magScript = mag.GetComponent<Mag>();
        ballRb = gameObject.GetComponent<Rigidbody2D>();
        startPosition = (Vector2)transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
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

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        bounceDirection = new Vector2(transform.position.x - collision.transform.position.x, transform.position.y - collision.transform.position.y).normalized;
        ballRb.AddForce(bounceDirection * bounceForce);
        if (!collision.gameObject.CompareTag("Walls"))
            collision.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bottom"))
            ResetBall(startPosition);

    }

    private void ResetBall(Vector2 startingPosition)
    {
        lounchPos = true;
        ballRb.constraints = RigidbodyConstraints2D.FreezePosition;
        transform.position = startingPosition;
        magScript.AddBall(gameObject);
        gameObject.SetActive(false);
    }
}
