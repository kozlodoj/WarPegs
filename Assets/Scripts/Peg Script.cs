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
    public bool isDome;
    [SerializeField]
    private int numberOfBounces;
    [SerializeField]
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
    [SerializeField]
    private Sprite crackedSprite;
    [SerializeField]
    private Sprite fullSprite;
    [SerializeField]
    private bool dontRespawn;

    private List<Collider2D> allColliders = new List<Collider2D>();

    void Start()
    {
        //reference ui
        pegUI = gameObject.transform.Find("Canvas").GetComponent<PegUI>();

        GetRenderer();
        //reference peg manager
        pegManager = GameObject.FindWithTag("Peg Layout").GetComponent<PegManager>();
        //set buff points
        buffPoints = GameManager.instance.buff;
        //set up border peg
        if (borderPeg)
        {
            gameObject.GetComponents<Collider2D>(allColliders);
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
            if (borderPeg)
            {
                foreach (Collider2D col in allColliders)
                    col.enabled = false;
            }
            StartCoroutine(FaderOut());
            pegUI.BuffText(buffPoints);
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void FadeIn()
    {
        if (!gameObject.activeSelf && !dontRespawn)
        {
            if (borderPeg)
            {
                foreach (Collider2D col in allColliders)
                    col.enabled = true;
            }
            gameObject.SetActive(true);
            boucesLeft = numberOfBounces;
            StartCoroutine(FaderIn());
            gameObject.GetComponent<Collider2D>().enabled = true;
        }
    }
    public void ReactivateDome()
    {
        gameObject.SetActive(true);
        boucesLeft = numberOfBounces;
        StartCoroutine(FaderIn());
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
    private void Burn()
    {
        if (borderPeg)
        {
            foreach (Collider2D col in allColliders)
                col.enabled = false;
        }
        gameObject.GetComponent<Collider2D>().enabled = false;
        StartCoroutine(FaderOut());
        pegUI.BuffText(buffPoints);
        
    }

    IEnumerator FaderOut()
    {
        for (float f = 1f; f >= 0; f -= fadeRate)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            if (borderPeg && additionalSpriteLeft != null)
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
        if (fullSprite != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = fullSprite;

        for (float f = 0.1f; f <= 1; f += fadeRate)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            if (borderPeg && additionalSpriteLeft != null)
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
        if (borderPeg && crackedSprite != null)
            gameObject.GetComponent<SpriteRenderer>().sprite = crackedSprite;
        if (!isClone)
        {
            GameManager.instance.bounces++;
            GameManager.instance.ManageDaily();
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fire"))
            Burn();
    }

    public void SetMedic()
    {
        medicPeg = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = medicSprite;
        

    }
    private void GetRenderer()
    {
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
        c.a = 1f;

    }

}

