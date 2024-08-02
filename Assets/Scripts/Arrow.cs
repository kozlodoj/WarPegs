using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class Arrow : MonoBehaviour
{
    private float theDamage;
    private Transform target;
    private GameObject theTarget;
    [SerializeField]
    private float speed = 2f;
    [SerializeField]
    private bool isEnemy = false;

    private float angle;
    private int id;
    // Start is called before the first frame update
    void Start()
    {
        id = DOTween.TotalPlayingTweens() + Random.Range(0, 1000);
        transform.DOMove(target.position, 1.2f / speed).SetId(id);
        
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
        if (!GameManager.instance.freezeGame)
        {
          
                var dir = target.position - transform.position;
            if (isEnemy)
                angle = Mathf.Atan2(dir.y, -dir.x) * Mathf.Rad2Deg;
            else
                angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), Time.deltaTime * 0.5f);
            if (!target.gameObject.activeInHierarchy)
            {
                DOTween.Kill(id);
                Destroy(gameObject);
            }
        }
        
    }
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEnemy)
        {
            if (collision.gameObject == theTarget && collision.gameObject.CompareTag("Enemy"))
            {
                DOTween.Kill(id);
                theTarget.GetComponent<EnemyScript>().DealDamage(theDamage);
                Destroy(gameObject);
            }
            else if (collision.gameObject == theTarget && collision.gameObject.CompareTag("Enemy base"))
            {
                DOTween.Kill(id);
                theTarget.GetComponent<BaseScript>().DealDamage(theDamage);
                Destroy(gameObject);
            }
        }
        else
        {
           
            if (collision.gameObject == theTarget && collision.gameObject.CompareTag("Unit"))
            {
                DOTween.Kill(id);
                theTarget.GetComponent<Unit>().DealDamage(theDamage);
                Destroy(gameObject);
            }
            else if (collision.gameObject == theTarget && collision.gameObject.CompareTag("Player Base"))
            {
                DOTween.Kill(id);
                theTarget.GetComponent<BaseScript>().DealDamage(theDamage);
                Destroy(gameObject);
            }
        }
    }
}
