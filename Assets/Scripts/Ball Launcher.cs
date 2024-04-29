using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallLauncher : MonoBehaviour
{
    private float speed = 10f;
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

    // Start is called before the first frame update
    void Start()
    {
        ActivateControls();
        trajScript = trajectory.GetComponent<Trajectory>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void LookDirection(InputAction.CallbackContext context)
    {

        if (isOcupied)
        {
            float angleRadians = Mathf.Atan2(-context.ReadValue<Vector2>().y, context.ReadValue<Vector2>().x);
            float angleDegrees = -angleRadians * Mathf.Rad2Deg;
            Quaternion theRotation = Quaternion.AngleAxis(angleDegrees - 90f, Vector3.forward);
            theBall.transform.rotation = theRotation;
            if (!isTrajActive)
            {
                isTrajActive = true;
                trajScript.EnableRenderer();
                trajScript.copyAllObstacles();
            }
            trajScript.predict(dummy, transform.position, transform.up * speed, theRotation);
        }
        
    }
    public void Shoot()
    {
       
            
            ballRb.constraints = RigidbodyConstraints2D.None;
            ballRb.AddRelativeForce(transform.up * speed, ForceMode2D.Impulse);
            //DisableLine();
            //KillObstacles();


        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isOcupied)
        {
            theBall = collision.gameObject;
            ballScript = theBall.GetComponent<Ball>();
            ballRb = theBall.GetComponent<Rigidbody2D>();
            if (!ballScript.isShot)
                ballScript.LounchPos();
            isOcupied = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == theBall)
            isOcupied = false;
    }

    private void ActivateControls()
    {
        actionMap = controlsAsset.FindActionMap("Player");
        aim = actionMap.FindAction("Aim");
        aim.performed += context => LookDirection(context);
        aim.canceled += context => Shoot();
    }

}
