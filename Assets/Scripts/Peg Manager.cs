using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegManager : MonoBehaviour
{
    
    private List<PegScript> allPegs = new List<PegScript>();
    private List<int> usedNum = new List<int>();
    private int medicPegs;
    private int buffPegs;
    private int speedPegs;
    private int twinPegs;
    private int bombPegs;
    private int chargePegs;
    private int feverPegs;
    private int coinPegs;
    private int freezePegs;
    private int lightningPegs;

    private int numberOfPegs;

    [SerializeField]
    private GameObject theMedic;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        medicPegs = (int)GameManager.instance.respawn;
        buffPegs = GameManager.instance.buffPegs;
        speedPegs = GameManager.instance.speedPegs;
        twinPegs = GameManager.instance.twinPegs;
        bombPegs = GameManager.instance.bombPegs;
        chargePegs = GameManager.instance.chargePegs;
        feverPegs = GameManager.instance.feverPegs;
        coinPegs = GameManager.instance.coinPegs;
        freezePegs = GameManager.instance.freezePegs;
        lightningPegs = GameManager.instance.lightningPegs;

     

        anim = gameObject.GetComponent<Animator>();
        GetAllPegs();
        
        SetAllPegTypes();
        
    }
 
    public void ReactivatePegs()
    {
        foreach (PegScript peg in allPegs)
            peg.FadeIn();
    }
    public IEnumerator ReactivateDome()
    {
        yield return new WaitForSeconds(2f);
        foreach (PegScript peg in allPegs)
            if (peg.isDome)
            {
                peg.ReactivateDome();
            }
    }
    private void GetAllPegs()
    {
        foreach (Transform child in gameObject.transform)
        {
            if (child.gameObject.tag == "Peg")
                allPegs.Add(child.GetComponent<PegScript>());
        }
    }
    public void SetMedics()
    {
       
            for (int i = 0; i < medicPegs; i++)
            {
                var peg = allPegs[RandomNum()];
                if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
                {
                    peg.SetMedic();
                }
                else
                    i--;
            }
   
    }
    public void SetBuffPegs()
    {
        for (int i = 0; i < buffPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetBuffPeg();
            }
            else
                i--;
        }
    }
    public void SetSpeedPegs()
    {
        for (int i = 0; i < speedPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetSpeedPeg();
            }
            else
                i--;
        }
    }
    public void SetTwinPegs()
    {
        for (int i = 0; i < twinPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetTwinPeg();
            }
            else
                i--;
        }
    }
    public void SetBombPegs()
    {
        for (int i = 0; i < bombPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetBombPeg();
            }
            else
                i--;
        }
    }
    public void SetChargePegs()
    {
        for (int i = 0; i < chargePegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetChargePeg();
            }
            else
                i--;
        }
    }
    public void SetFeverPegs()
    {
        for (int i = 0; i < feverPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetFeverPeg();
            }
            else
                i--;
        }
    }
    public void SetCoinPegs()
    {
        for (int i = 0; i < coinPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetCoinPeg();
            }
            else
                i--;
        }
    }
    public void SetFreezePegs()
    {
        for (int i = 0; i < freezePegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetFreezePeg();
            }
            else
                i--;
        }
    }
    public void SetLightningPegs()
    {
        for (int i = 0; i < lightningPegs; i++)
        {
            var peg = allPegs[RandomNum()];
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg && !peg.lightningPeg)
            {
                peg.SetLightningPeg();
            }
            else
                i--;
        }
    }

    public void ActivateFever()
    {
        foreach (PegScript peg in allPegs)
        {
                peg.FeverActivate();
            anim.SetBool("fever", true);
            StartCoroutine(FeverCountdown());
        }
    }
    private IEnumerator FeverCountdown()
    {
        yield return new WaitForSeconds(10f);
        anim.SetBool("fever", false);
    }

    public void SetAllPegTypes()
    {
        numberOfPegs = GameManager.instance.PegCardsList.Count;
        
        foreach (PegScript peg in allPegs)
            peg.SetBuffPoints();
        if (!GameManager.instance.tutorial)
        {
            SetMedics();
            if (numberOfPegs != 0)
            {
                for (int i = 0; i < numberOfPegs; i++)
                {
                    var num = GameManager.instance.PegCardsList[i].pegNumber;
                    var chance = GameManager.instance.PegCardsList[i].chance;
                    if (RandomPegNum() <= chance)
                    {
                        if (num == 0)
                            SetBombPegs();
                        else if (num == 1)
                            SetBuffPegs();
                        else if (num == 2)
                            SetChargePegs();
                        else if (num == 3)
                            SetTwinPegs();
                        else if (num == 4)
                            SetCoinPegs();
                        else if (num == 5)
                            SetFreezePegs();
                        else if (num == 6)
                            SetLightningPegs();
                        else if (num == 7)
                            SetSpeedPegs();
                    }
                }

            }
           
        }
    }

    public void ResetPegs()
    {
        anim.SetBool("fever", false);
        foreach (PegScript peg in allPegs)
        {
            peg.ResetPeg();
        }
    }

    private int RandomNum()
    {
        return Random.Range(0, allPegs.Count);
    }
    private int RandomPegNum()
    {
        return Random.Range(0, 101);
    }
    //for tutorial
    public void ActivateMedic()
    {
        theMedic.GetComponent<PegScript>().SetMedic();
        theMedic.SetActive(true);
    }
   
}
