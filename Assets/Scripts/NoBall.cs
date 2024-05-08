using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoBall : MonoBehaviour
{
    private SpriteRenderer sprite;
    private float fadeRate = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(BlipOut());

    }
    private void OnEnable()
    {
        
    }


    public IEnumerator BlipOut()
    {
        for (float f = 1f; f >= 0; f -= fadeRate)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(fadeRate / 2);
        }
        if(gameObject.activeInHierarchy)
        StartCoroutine(BlipIn());
    }
    IEnumerator BlipIn()
    {
        for (float f = 0f; f <= 1; f += fadeRate)
        {
            Color c = sprite.material.color;
            c.a = f;
            sprite.material.color = c;
            yield return new WaitForSeconds(fadeRate / 2);
        }
        if (gameObject.activeInHierarchy)
            StartCoroutine(BlipOut());
    }


}
