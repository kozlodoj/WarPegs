using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PegManager : MonoBehaviour
{
    private List<PegScript> allPegs = new List<PegScript>();
    private int medicPegs;
    [SerializeField]
    private GameObject theMedic;

    // Start is called before the first frame update
    void Start()
    {
        medicPegs = (int)GameManager.instance.respawn;
        GetAllPegs();
        SetMedics();
        
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
                peg.FadeIn();
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
    private void SetMedics()
    {
        if (!GameManager.instance.tutorial)
        {
            for (int i = 0; i < medicPegs; i++)
            {
                var peg = allPegs[RandomNum()];
                if (!peg.borderPeg)
                {
                    peg.SetMedic();
                }
                else
                    i--;
            }
        }
    }

    private int RandomNum()
    {
        return Random.Range(0, allPegs.Count);
    }
    public void ActivateMedic()
    {
        theMedic.GetComponent<PegScript>().SetMedic();
        theMedic.SetActive(true);
    }
}
