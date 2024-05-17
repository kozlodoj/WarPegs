using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Arrow : MonoBehaviour
{
    private float theDamage;
    private Transform target;
    private GameObject theTarget;

    [SerializeField]
    private bool isEnemy = false;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       Move();
    }

    public void SetTarget(GameObject targetObj, float damage)
    {
        theDamage = damage;
        target = targetObj.transform;
        theTarget = targetObj;
        theDamage = damage;        
    }
    private void Move()
    {
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, Time.deltaTime * 2f);
        if (!target.gameObject.activeInHierarchy)
            Destroy(gameObject);
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEnemy)
        {
            if (collision.gameObject == theTarget && collision.gameObject.CompareTag("Enemy"))
            {
                theTarget.GetComponent<EnemyScript>().DealDamage(theDamage);
                Destroy(gameObject);
            }
            else if ((collision.gameObject == theTarget && collision.gameObject.CompareTag("Enemy base")))
            {
                theTarget.GetComponent<BaseScript>().DealDamage(theDamage);
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject == theTarget && collision.gameObject.CompareTag("Unit"))
            {
                theTarget.GetComponent<Unit>().DealDamage(theDamage);
                Destroy(gameObject);
            }
            else if ((collision.gameObject == theTarget && collision.gameObject.CompareTag("Player base")))
            {
                theTarget.GetComponent<BaseScript>().DealDamage(theDamage);
                Destroy(gameObject);
            }
        }
    }
}
