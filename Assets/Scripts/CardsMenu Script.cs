using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsMenuScript : MonoBehaviour
{
    private List<GameObject> slots = new List<GameObject>();
    [SerializeField]
    private int pegOneChanse;
    [SerializeField]
    private int pegTwoChanse;
    [SerializeField]
    private int pegThreeChanse;
    [SerializeField]
    private int pegFourChanse;
    [SerializeField]
    private int pegFiveChanse;
    [SerializeField]
    private int pegSixChanse;
    [SerializeField]
    private int pegSevenChanse;
    [SerializeField]
    private int pegEightChanse;

    [SerializeField]
    private GameObject pegOne;
    [SerializeField]
    private GameObject pegTwo;
    [SerializeField]
    private GameObject pegThree;
    [SerializeField]
    private GameObject pegFour;
    [SerializeField]
    private GameObject pegFive;
    [SerializeField]
    private GameObject pegSix;
    [SerializeField]
    private GameObject pegSeven;
    [SerializeField]
    private GameObject pegEight;

    [SerializeField]
    private GameObject slot00;
    [SerializeField]
    private GameObject slot01;
    [SerializeField]
    private GameObject slot02;
    [SerializeField]
    private GameObject slot03;
    [SerializeField]
    private GameObject slot04;
    [SerializeField]
    private GameObject slot05;
    [SerializeField]
    private GameObject slot06;
    [SerializeField]
    private GameObject slot07;
    private int slotsOqupied = 0;

    private int totalChanse;
    private int oneBorder;
    private int twoBorder;
    private int threeBorder;
    private int fourBorder;
    private int fiveBorder;
    private int sixBorder;
    private int sevenBorder;
    
    // Start is called before the first frame update
    void Start()
    {
        TotalChanse();
        AddSlotsToList();
        LoadPegCards();
    }

    public void GachaOneRoll()
    {

        int roll = RandomNum();

        if (roll <= oneBorder)
        {
            GameManager.instance.pegCards.Add(0);
            
        }
        else if (roll > oneBorder && roll <= twoBorder)
        {
            GameManager.instance.pegCards.Add(1);
            
            
        }
        else if (roll > twoBorder && roll <= threeBorder)
        {
            GameManager.instance.pegCards.Add(2);
            
            
        }
        else if (roll > threeBorder && roll <= fourBorder)
        {
            GameManager.instance.pegCards.Add(3);
            
            
        }
        else if (roll > fourBorder && roll <= fiveBorder)
        {
            GameManager.instance.pegCards.Add(4);
            
            
        }
        else if (roll > fiveBorder && roll <= sixBorder)
        {
            GameManager.instance.pegCards.Add(5);
            
            
        }
        else if (roll > sixBorder && roll <= sevenBorder)
        {
            GameManager.instance.pegCards.Add(6);
           
            
        }
        else if (roll > sevenBorder)
        {
            GameManager.instance.pegCards.Add(7);
            
            
        }
        ActivatePeg();

    }
    private int RandomNum()
    {
        return Random.Range(0, totalChanse);
    }
    private void TotalChanse()
    {
        totalChanse = pegOneChanse + pegTwoChanse + pegThreeChanse + pegFourChanse + pegFiveChanse + pegSixChanse + pegSevenChanse + pegEightChanse;
        oneBorder = pegOneChanse;
        twoBorder = pegOneChanse + pegTwoChanse;
        threeBorder = twoBorder + pegThreeChanse;
        fourBorder = threeBorder + pegFourChanse;
        fiveBorder = fourBorder + pegFiveChanse;
        sixBorder = fiveBorder + pegSixChanse;
        sevenBorder = sixBorder + pegSevenChanse;
    }
    private void ActivatePeg()
    {
        
        int pegNum = GameManager.instance.pegCards[GameManager.instance.pegCards.Count - 1];
    
        bool hasDropped = false;
        for (int i = 0; i < GameManager.instance.pegCards.Count - 1; i++)
        {
            if (pegNum == GameManager.instance.pegCards[i])
            {
                hasDropped = true;
                i = GameManager.instance.pegCards.Count;
            }
        }
        if (!hasDropped)
        {
            InstantiatPegCards(pegNum, false);
        }
        else
            UpdateCards(pegNum);

        

    }
    private void LoadPegCards()
    {
        for (int i = 0; i < GameManager.instance.specPegsList.Count; i++)
        {
            InstantiatPegCards(GameManager.instance.specPegsList[i].pegNumber, true);
        }
    }
    private GameObject nextSlot()
    {
        if (slotsOqupied == 0)
        {
            slotsOqupied++;
            return slot00;
        }
        else if (slotsOqupied == 1)
        {
            slotsOqupied++;
            return slot01;
        }
        else if (slotsOqupied == 2)
        {
            slotsOqupied++;
            return slot02;
        }
        else if (slotsOqupied == 3)
        {
            slotsOqupied++;
            return slot03;
        }
        else if (slotsOqupied == 4)
        {
            slotsOqupied++;
            return slot04;
        }
        else if (slotsOqupied == 5)
        {
            slotsOqupied++;
            return slot05;
        }
        else if (slotsOqupied == 6)
        {
            slotsOqupied++;
            return slot06;
        }
        else
        {
            slotsOqupied++;
            return slot07;
        }
    }
    private void AddSlotsToList()
    {
        slots.Add(slot00);
        slots.Add(slot01);
        slots.Add(slot02);
        slots.Add(slot03);
        slots.Add(slot04);
        slots.Add(slot05);
        slots.Add(slot06);
        slots.Add(slot07);
    }
    public void UpdateCards(int peg)
    {
        for (int i = 0; i < GameManager.instance.specPegsList.Count; i++)
        {
            var pegCard = slots[i].gameObject.transform.GetComponentInChildren<SpecialPeg>();
            var pegCard2 = GameManager.instance.specPegsList[i];
            var pegNum2 = pegCard.pegNumber;
            var pegNum = pegCard.pegNumber;
            if (pegNum == peg)
            {
                pegCard.SetLvl();
                pegCard.Save(i);
            }
            if (pegNum2 == peg)
                pegCard2.SetLvl();

        }
    }
    private void InstantiatPegCards(int pegNum, bool isStart)
    {
        switch (pegNum)
        {
            case 0:
                var nextslot = nextSlot();
                int slotNum = nextslot.GetComponent<CardSlot>().slotNum;
                GameObject newPegCard = Instantiate(pegOne, nextslot.transform) as GameObject;
                newPegCard.GetComponent<SpecialPeg>().slot = slotNum;
                newPegCard.GetComponent<SpecialPeg>().Save(slotNum);
                if(!isStart)
                GameManager.instance.specPegsList.Add(pegOne.GetComponent<SpecialPeg>());
                break;
            case 1:
                var nextslot1 = nextSlot();
                var slotNum1 = nextslot1.GetComponent<CardSlot>().slotNum;
                Debug.Log(slotNum1);
                GameObject newPegCard1 = Instantiate(pegTwo, nextslot1.transform) as GameObject;
                newPegCard1.GetComponent<SpecialPeg>().Save(slotNum1);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegTwo.GetComponent<SpecialPeg>());
                break;
            case 2:

                var nextslot2 = nextSlot();
                var slotNum2 = nextslot2.GetComponent<CardSlot>().slotNum;
                Debug.Log(slotNum2);
                GameObject newPegCard2 = Instantiate(pegThree, nextslot2.transform) as GameObject;
                newPegCard2.GetComponent<SpecialPeg>().Save(slotNum2);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegThree.GetComponent<SpecialPeg>());
                break;
            case 3:

                var nextslot3 = nextSlot();
                var slotNum3 = nextslot3.GetComponent<CardSlot>().slotNum;
                Debug.Log(slotNum3);
                GameObject newPegCard3 = Instantiate(pegFour, nextslot3.transform) as GameObject;
                newPegCard3.GetComponent<SpecialPeg>().Save(slotNum3);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegFour.GetComponent<SpecialPeg>());
                break;
            case 4:

                var nextslot4 = nextSlot();
                var slotNum4 = nextslot4.GetComponent<CardSlot>().slotNum;
                Debug.Log(slotNum4);
                GameObject newPegCard4 = Instantiate(pegFive, nextslot4.transform) as GameObject;
                newPegCard4.GetComponent<SpecialPeg>().Save(slotNum4);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegFive.GetComponent<SpecialPeg>());
                break;
            case 5:

                var nextslot5 = nextSlot();
                var slotNum5 = nextslot5.GetComponent<CardSlot>().slotNum;
                GameObject newPegCard5 = Instantiate(pegSix, nextslot5.transform) as GameObject;
                newPegCard5.GetComponent<SpecialPeg>().Save(slotNum5);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegSix.GetComponent<SpecialPeg>());
                break;
            case 6:

                var nextslot6 = nextSlot();
                var slotNum6 = nextslot6.GetComponent<CardSlot>().slotNum;
                GameObject newPegCard6 = Instantiate(pegSeven, nextslot6.transform) as GameObject;
                newPegCard6.GetComponent<SpecialPeg>().Save(slotNum6);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegSeven.GetComponent<SpecialPeg>());
                break;
            case 7:

                var nextslot7 = nextSlot();
                var slotNum7 = nextslot7.GetComponent<CardSlot>().slotNum;
                GameObject newPegCard7 = Instantiate(pegEight, nextslot7.transform) as GameObject;
                newPegCard7.GetComponent<SpecialPeg>().Save(slotNum7);
                if (!isStart)
                    GameManager.instance.specPegsList.Add(pegEight.GetComponent<SpecialPeg>());

                break;
        }
    }
}
