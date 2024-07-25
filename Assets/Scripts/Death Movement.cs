using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float lifeTime;

    private void Start()
    {
        StartCoroutine(DeathTimer());
    }
    void Update()
    {
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}
