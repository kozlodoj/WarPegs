using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardSlot : MonoBehaviour
{
    public int slotNum;
    private GameObject thePegCardAttached;
    private SpecialPeg cardScript;

    public void ActivateCard(GameObject pegCard, SpecPeg data)
    {
       thePegCardAttached = Instantiate(pegCard, gameObject.transform);
        cardScript = thePegCardAttached.GetComponent<SpecialPeg>();
        cardScript.SetLvlUI(data.lvl);
    }
    public void UpdateCard(SpecPeg data)
    {
        
        cardScript.SetLvlUI(data.lvl);
    }
    
}

