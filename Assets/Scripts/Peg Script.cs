using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PegScript : MonoBehaviour
{
    private SpriteRenderer rend;

    //private float fadeRate = 0.1f;
    private Color c;
    public bool medicPeg;
    public bool borderPeg;
    public bool isDome;
    public bool buffPeg;
    public bool speedPeg;
    public bool twinPeg;
    public bool bombPeg;
    public bool chargePeg;
    public bool feverPeg;
    public bool feverMode;
    public bool coinPeg;
    public bool freezePeg;
    public bool lightningPeg;
    [SerializeField]
    private GameObject lightningRadius;
    [SerializeField]
    private float freeazeTime;
    private bool bombTriggered;
    [SerializeField]
    private int numberOfBounces;
    [SerializeField]
    private int boucesLeft;
    public bool isClone = false;
    [SerializeField]
    private float buffMultiplier;
    private LineRenderer line;
    public Ball theBall;

    public float buffPoints;
    private float currentBuff;

    private int coinDrop;

    private PegManager pegManager;
    private PegUI pegUI;
    private Mag magScript;
    [SerializeField]
    private Sprite regularSprite;
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
    private Sprite coinPegSprite;
    [SerializeField]
    private bool dontRespawn;
    [SerializeField]
    private Color buffColor;
    [SerializeField]
    private Color speedColor;
    [SerializeField]
    private Color twinColor;
    [SerializeField]
    private Color bombColor;
    [SerializeField]
    private Color chargeColor;
    [SerializeField]
    private Color feverColor;
    [SerializeField]
    private Color freezeColor;
    [SerializeField]
    private Color lightningColor;
    private Color currentColor;

    private Animator anim;

    private List<Collider2D> allColliders = new List<Collider2D>();

    void Start()
    {
        //reference ui
        pegUI = gameObject.transform.Find("Canvas").GetComponent<PegUI>();

        GetRenderer();
        //reference peg manager
        pegManager = GameObject.FindWithTag("Peg Layout").GetComponent<PegManager>();
        //reference animator
        anim = gameObject.GetComponent<Animator>();
        //reference lightning
        if (!isDome)
        lightningRadius = gameObject.transform.Find("lightningRadius").gameObject;
        //get linerenderer
        line = gameObject.GetComponent<LineRenderer>();
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
        if (feverMode)
        {
            
            Vibration.VibratePop();
            anim.SetBool("fadeOut", true);
            anim.SetBool("fadeIn", false);
            pegUI.BuffText(buffPoints);
        }
        else
        {
            if (bombTriggered)
            {
                Vibration.Vibrate();
                anim.SetBool("blowUp", true);
                anim.SetBool("fadeIn", false);
                bombTriggered = false;
            }
            else
            {
                if (buffPeg)
                {
                    Vibration.Vibrate();
                    anim.SetBool("fadeOutBuff", true);
                    anim.SetBool("fadeIn", false);
                    pegUI.BuffText(buffPoints);
                }
                else if (bombPeg)
                {
                    Vibration.VibrateNope();
                    anim.SetBool("isBomb", true);
                    anim.SetBool("blowUp", false);
                    anim.SetBool("fadeIn", false);
                    bombTriggered = true;

                }
                else if (chargePeg)
                {
                    Vibration.VibrateNope();
                    anim.SetBool("fadeOut", true);
                    anim.SetBool("fadeIn", false);
                    magScript.ChargeOneBall();
                }
                else if (feverPeg)
                {
                    Vibration.VibrateNope();
                    pegManager.ActivateFever();
                    anim.SetBool("fadeOut", true);
                    anim.SetBool("fadeIn", false);
                }
                else if (coinPeg)
                {
                    Vibration.VibratePeek();
                    GameManager.instance.AddGold(coinDrop);
                    anim.SetBool("fadeOut", true);
                    anim.SetBool("fadeIn", false);
                    pegUI.BuffText(coinDrop);
                }
                else if (freezePeg)
                {
                    Vibration.VibratePeek();
                    anim.SetBool("fadeOut", true);
                    anim.SetBool("fadeIn", false);
                    GameManager.instance.FreezeTow();
                    StartCoroutine(FreezeTimer());
                }
                else if (lightningPeg)
                {
                    Vibration.VibratePop();
                    StartCoroutine(LightningNextPeg(theBall));
                }
                else if (!isDome)
                {
                    
                    Vibration.VibratePop();
                    anim.SetBool("fadeOut", true);
                    anim.SetBool("fadeIn", false);
                    pegUI.BuffText(buffPoints);
                }
                
                else {
                    Vibration.VibratePop();
                    boucesLeft--;
                    if (boucesLeft == 0)
                    {
                        anim.SetBool("fadeOut", true);
                    }
                    else
                    gameObject.GetComponent<SpriteRenderer>().sprite = crackedSprite;
                }

            }
        }
    }

    public void FadeIn()
    {
        anim.SetBool("fadeIn", true);
        anim.SetBool("fadeOut", false);
        if (!isDome)
        {
            anim.SetBool("fadeOutBuff", false);
            anim.SetBool("isBomb", false);
        }
        pegUI.BuffText(0);
        if (isDome)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = fullSprite;
            boucesLeft = numberOfBounces;
        }
    }
    public void ReactivateDome()
    {
        gameObject.SetActive(true);
        boucesLeft = numberOfBounces;
        FadeIn();
        gameObject.GetComponent<Collider2D>().enabled = true;
    }
    private void Burn()
    {
        if (borderPeg)
        {
            foreach (Collider2D col in allColliders)
                col.enabled = false;
        }
        FadeOut();
        pegUI.BuffText(buffPoints);
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (medicPeg && !isClone && !feverMode)
        {
            pegManager.ResetPegs();
            pegManager.SetAllPegTypes();
            pegManager.ReactivatePegs();
        }
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
    public void SetBuffPeg()
    {
        buffPeg = true;
        gameObject.GetComponent<SpriteRenderer>().color = buffColor;
        buffPoints *= buffMultiplier;
    }
    public void SetSpeedPeg()
    {
        speedPeg = true;
        gameObject.GetComponent<SpriteRenderer>().color = speedColor;
    }
    public void SetTwinPeg()
    {
        twinPeg = true;
        gameObject.GetComponent<SpriteRenderer>().color = twinColor;
    }
    public void SetBombPeg()
    {
        bombPeg = true;
        buffPoints = 0;
        gameObject.GetComponent<SpriteRenderer>().color = bombColor;

    }
    public void SetChargePeg()
    {
        chargePeg = true;
        magScript = GameObject.Find("Mag").GetComponent<Mag>();
        buffPoints = 0;
        gameObject.GetComponent<SpriteRenderer>().color = chargeColor;
    }
    public void SetFeverPeg()
    {
        feverPeg = true;
        gameObject.GetComponent<SpriteRenderer>().color = feverColor;
        buffPoints = 0;
    }
    public void SetCoinPeg()
    {
        coinPeg = true;
        gameObject.GetComponent<SpriteRenderer>().sprite = coinPegSprite;
        buffPoints = 0;
        var era = GameManager.instance.enemyEra;
        if (era == 0)
            coinDrop = 20;
        else if (era == 1)
            coinDrop = 92;
        else if (era == 2)
            coinDrop = 340;
        else if (era == 3)
            coinDrop = 1160;
        else if (era == 4)
            coinDrop = 3480;
        else if (era == 5)
            coinDrop = 9000;

    }
    public void SetFreezePeg()
    {
        freezePeg = true;
        gameObject.GetComponent<SpriteRenderer>().color = freezeColor;
        buffPoints = 0;
    }
    public void SetLightningPeg()
    {
        lightningPeg = true;
        gameObject.GetComponent<SpriteRenderer>().color = lightningColor;
        buffPoints = 0;
    }

    public void ResetPeg()
    {
        medicPeg = false;
        buffPeg = false;
        speedPeg = false;
        twinPeg = false;
        bombPeg = false;
        chargePeg = false;
        feverPeg = false;
        coinPeg = false;
        freezePeg = false;
        lightningPeg = false;
        if (lightningRadius != null)
        {
            lightningRadius.SetActive(false);
        }
        ResetAnimations();
        SetBuffPoints();
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        gameObject.GetComponent<SpriteRenderer>().sprite = regularSprite;

    }
    public void SetBuffPoints()
    {
        buffPoints = GameManager.instance.buff;
    }
    private void GetRenderer()
    {
        rend = GetComponent<SpriteRenderer>();
        c = rend.material.color;
        c.a = 1f;

    }
    public void StopFadeInAnim()
    {
        anim.SetBool("fadeIn", false);
    }
    public void StopFadeOutAnim()
    {
        if(buffPeg)
            anim.SetBool("fadeOutBuff", false);
        else
            anim.SetBool("fadeOut", false);
    }
    public void BlowUp()
    {
        anim.SetBool("blowUp", false);
    
    }
    public void StopDomeAnimation()
    {
        anim.SetBool("fadeOut", false);
        anim.SetBool("fadeIn", false);
    }
    private void ResetAnimations()
    {
        anim.SetBool("fadeIn", false);
        anim.SetBool("fadeOut", false);
        if (!isDome)
        {
            anim.SetBool("fadeOutBuff", false);
            anim.SetBool("blowUp", false);
            anim.SetBool("isBomb", false);
        }
    }

    public void FeverActivate()
    {
        if (!isDome)
        {
            feverMode = true;
            currentBuff = buffPoints;
            buffPoints = GameManager.instance.buff * 2;
            currentColor = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = feverColor;
            anim.SetBool("fever", true);
            StartCoroutine(FeverTimer());
        }
    }
    public IEnumerator LightningNextPeg(Ball theball)
    {
        if (!isDome)
        {
            lightningRadius.SetActive(true);
            yield return new WaitForSeconds(0.05f);
            anim.SetBool("fadeOut", true);
            anim.SetBool("fadeIn", false);
            theball.AddBuffPoints(buffPoints);
            pegUI.BuffText(buffPoints);
            var nextPeg = lightningRadius.GetComponent<lightningscript>().ClosestPeg();
            if (nextPeg != null)
            {
                StartCoroutine(nextPeg.LightningNextPeg(theball));
                line.SetPosition(0, transform.position);
                line.SetPosition(1, nextPeg.transform.position);
                line.enabled = true;
                yield return new WaitForSeconds(0.5f);
                line.enabled = false;
            }
        }
    }

    private IEnumerator FeverTimer()
    {
        yield return new WaitForSeconds(10f);
        Vibration.VibrateNope();
        anim.SetBool("fever", false);
        gameObject.GetComponent<SpriteRenderer>().color = currentColor;
        buffPoints = currentBuff;
        feverMode = false;
        
    }
    private IEnumerator FreezeTimer()
    {
        yield return new WaitForSeconds(freeazeTime);
        Vibration.VibrateNope();
        GameManager.instance.UnFreezeTow();
    }

}

