using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegScript : MonoBehaviour
{
    private SpriteRenderer rend;

    private float fadeRate = 0.1f;
    private Color c;
    [SerializeField]
    private bool medicPeg;
    public bool borderPeg;
    [SerializeField]
    private int numberOfBounces;
    private int boucesLeft;
    public bool isClone = false;

    public float buffPoints;
    private float currentBuff;

    private PegManager pegManager;
    private PegUI pegUI;
    [SerializeField]
    private Sprite medicSprite;
    [SerializeField]
    private SpriteRenderer additionalSpriteLeft;
    [SerializeField]
    private SpriteRenderer additionalSpriteRight;

    // Start is called before the first frame update
    void Start()
    {
        pegUI = gameObject.transform.Find("Canvas").GetComponent<PegUI>();
        
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
        c.a = 1f;

        pegManager = GameObject.FindWithTag("Peg Layout").GetComponent<PegManager>();

        buffPoints = GameManager.instance.buff;
        if (borderPeg)
        {
            boucesLeft = numberOfBounces;
            currentBuff = buffPoints;
            buffPoints = 0;
            
        }
    }

    public void FadeOut()
    {
        if (borderPeg)
        {
            boucesLeft--;
        }
        if (borderPeg && boucesLeft == 1)
            buffPoints = currentBuff;
        if (!borderPeg || boucesLeft <= 0)
        {

            StartCoroutine(FaderOut());
            pegUI.BuffText(buffPoints);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void FadeIn()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            boucesLeft = numberOfBounces;
            StartCoroutine(FaderIn());
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }

    IEnumerator FaderOut()
    {

        for (float f = 1f; f >= 0; f -= fadeRate)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            if (borderPeg)
            {
                additionalSpriteLeft.material.color = c;
                additionalSpriteRight.material.color = c;
            }
            yield return new WaitForSeconds(fadeRate / 2);
        }
        pegUI.ResetScale();
        gameObject.SetActive(false);
    }

    IEnumerator FaderIn()
    {
        
        for (float f = 0.1f; f <= 1; f += fadeRate)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            if (borderPeg)
            {
                additionalSpriteLeft.material.color = c;
                additionalSpriteRight.material.color = c;
            }
            yield return new WaitForSeconds(fadeRate / 2);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (medicPeg && !isClone)
            pegManager.ReactivatePegs();
        

    }

    public void SetMedic()
    {
        medicPeg = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = medicSprite;
        

    }

}

