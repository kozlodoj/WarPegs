using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegManager : MonoBehaviour
{
    private List<PegScript> allPegs = new List<PegScript>();
    private List<int> usedNumbers = new List<int>();
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

        numberOfPegs = GameManager.instance.numberOfSpecialPegs;
        
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
                if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (!peg.borderPeg && !peg.medicPeg && !peg.buffPeg && !peg.speedPeg && !peg.twinPeg && !peg.bombPeg && !peg.chargePeg && !peg.feverPeg && !peg.coinPeg && !peg.freezePeg)
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
            if (peg.gameObject.activeInHierarchy)
                peg.FeverActivate();
        }
    }

    public void SetAllPegTypes()
    {
        foreach (PegScript peg in allPegs)
            peg.SetBuffPoints();
        if (!GameManager.instance.tutorial)
        {
            SetMedics();
            for (int i = 0; i < numberOfPegs; i++)
            {
                var currentStep = i;
                var randomNum = RandomPegNum();
                foreach (int num in usedNumbers)
                    if (randomNum == num)
                    {
                        i--;
                    }
                if (i == currentStep)
                    {
                        usedNumbers.Add(randomNum);
                        if (randomNum == 0)
                            SetBuffPegs();
                        else if (randomNum == 1)
                            SetSpeedPegs();
                        else if (randomNum == 2)
                            SetTwinPegs();
                        else if (randomNum == 3)
                            SetBombPegs();
                        else if (randomNum == 4)
                            SetChargePegs();
                        else if (randomNum == 5)
                            SetCoinPegs();
                        else if (randomNum == 6)
                            SetFreezePegs();
                        else if (randomNum == 7)
                            SetLightningPegs();
                    }
            }
            //SetFeverPegs();
        }
    }

    public void ResetPegs()
    {
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
        return Random.Range(0, 8);
    }
    //for tutorial
    public void ActivateMedic()
    {
        theMedic.GetComponent<PegScript>().SetMedic();
        theMedic.SetActive(true);
    }
}
