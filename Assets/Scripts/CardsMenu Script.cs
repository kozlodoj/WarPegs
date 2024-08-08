using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsMenuScript : MonoBehaviour
{
    private List<GameObject> slots = new List<GameObject>();
    private List<GameObject> cards = new List<GameObject>();
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

    [SerializeField]
    private int initialDropChance;

    private int totalChanse;
    private int oneBorder;
    private int twoBorder;
    private int threeBorder;
    private int fourBorder;
    private int fiveBorder;
    private int sixBorder;
    private int sevenBorder;

    private SaveScript save;
    // Start is called before the first frame update
    void Start()
    {
        save = gameObject.GetComponent<SaveScript>();
        TotalChanse();
        AddSlotsToList();
        AddCardsToList();
        //LoadPegCards();
    }

    public void GachaOneRoll()
    {

        int roll = RandomNum();
        bool hasDropped = false;
        SpecPeg newPegCard = new SpecPeg();
        if (roll <= oneBorder)
        {
            
            newPegCard.pegNumber = 0;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
                
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                        GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
 
                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }
            
        }
        else if (roll > oneBorder && roll <= twoBorder)
        {
            
            newPegCard.pegNumber = 1;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
               
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
                    

                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }
        }
        else if (roll > twoBorder && roll <= threeBorder)
        {
            
            newPegCard.pegNumber = 2;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
               
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
              
                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }

        }
        else if (roll > threeBorder && roll <= fourBorder)
        {
            
            newPegCard.pegNumber = 3;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
               
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
              
                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }

        }
        else if (roll > fourBorder && roll <= fiveBorder)
        {
            
            newPegCard.pegNumber = 4;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
                
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
                
                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }
        }
        else if (roll > fiveBorder && roll <= sixBorder)
        {
           
            newPegCard.pegNumber = 5;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
                
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
              
                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }
        }
        else if (roll > sixBorder && roll <= sevenBorder)
        {
            
            newPegCard.pegNumber = 6;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
               
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];
                    }
                  

                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);

            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }
        }
        else if (roll > sevenBorder)
        {
            
            newPegCard.pegNumber = 7;
            newPegCard.lvl = 0;
            newPegCard.chance = initialDropChance;
            if (GameManager.instance.PegCardsList.Count != 0)
            {
                
                for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
                {
                    if (newPegCard.pegNumber == GameManager.instance.PegCardsList[i].pegNumber)
                    {
                        GameManager.instance.PegCardsList[i].lvl += 0.25f;
                        if (GameManager.instance.PegCardsList[i].lvl % 1 == 0)
                            GameManager.instance.PegCardsList[i].chance += initialDropChance;
                        hasDropped = true;
                        newPegCard = GameManager.instance.PegCardsList[i];

                    }
            

                }
                if (!hasDropped)
                    GameManager.instance.PegCardsList.Add(newPegCard);
            }
            else
            {
                GameManager.instance.PegCardsList.Add(newPegCard);
            }
        }

        ActivatePeg(newPegCard, hasDropped);
    }
    //public void GachaOneRoll()
    //{

    //    int roll = RandomNum();

    //    if (roll <= oneBorder)
    //    {
    //        GameManager.instance.pegCards.Add(0);

    //    }
    //    else if (roll > oneBorder && roll <= twoBorder)
    //    {
    //        GameManager.instance.pegCards.Add(1);


    //    }
    //    else if (roll > twoBorder && roll <= threeBorder)
    //    {
    //        GameManager.instance.pegCards.Add(2);


    //    }
    //    else if (roll > threeBorder && roll <= fourBorder)
    //    {
    //        GameManager.instance.pegCards.Add(3);


    //    }
    //    else if (roll > fourBorder && roll <= fiveBorder)
    //    {
    //        GameManager.instance.pegCards.Add(4);


    //    }
    //    else if (roll > fiveBorder && roll <= sixBorder)
    //    {
    //        GameManager.instance.pegCards.Add(5);


    //    }
    //    else if (roll > sixBorder && roll <= sevenBorder)
    //    {
    //        GameManager.instance.pegCards.Add(6);


    //    }
    //    else if (roll > sevenBorder)
    //    {
    //        GameManager.instance.pegCards.Add(7);


    //    }
    //    ActivatePeg();

    //}
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
    private void ActivatePeg(SpecPeg pegCard, bool hasDropped)
    {
        var cardNum = pegCard.pegNumber;
        if (!hasDropped)
        {
            var slotNum = GameManager.instance.PegCardsList.Count - 1;
            slots[slotNum].GetComponent<CardSlot>().ActivateCard(cards[cardNum], pegCard);
            pegCard.slot = slotNum;
        }
        else
        {
            var slotNum = pegCard.slot;
            
            slots[slotNum].GetComponent<CardSlot>().UpdateCard(pegCard);
        }

        

    }
    //private void ActivatePeg()
    //{
    //    //check if its new
    //    int pegNum = GameManager.instance.pegCards[GameManager.instance.pegCards.Count - 1];

    //    bool hasDropped = false;
    //    for (int i = 0; i < GameManager.instance.pegCards.Count - 1; i++)
    //    {
    //        if (pegNum == GameManager.instance.pegCards[i])
    //        {
    //            //not new
    //            hasDropped = true;
    //            i = GameManager.instance.pegCards.Count;
    //        }
    //    }
    //    if (!hasDropped)
    //    {
    //        //new peg card management
    //        InstantiatPegCards(pegNum, null, false);
    //    }
    //    else
    //        UpdateCards(pegNum);



    //}
    //private void LoadPegCards()
    //{
    //    if (GameManager.instance.specPegsList.Count == 0)
    //    {
    //        LoadPegsFromSave();
    //    }
    //    else
    //    {
    //        for (int i = 0; i < GameManager.instance.specPegsList.Count; i++)
    //        {
    //            InstantiatPegCards(0, GameManager.instance.specPegsList[i].data, true);
    //        }
    //    }
    //}
    //private void LoadPegsFromSave()
    //{
    //    save.LoadSpecPegs();
    //}
    //public void ActivateLoadedPegCards(int slot, SpecPeg data)
    //{

    //    InstantiatPegCards(0, data, false);
    //}
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
    private void AddCardsToList()
    {
        cards.Add(pegOne);
        cards.Add(pegTwo);
        cards.Add(pegThree);
        cards.Add(pegFour);
        cards.Add(pegFive);
        cards.Add(pegSix);
        cards.Add(pegSeven);
        cards.Add(pegEight);
    }
    //public void UpdateCards(int peg)
    //{
    //    for (int i = 0; i < GameManager.instance.specPegsList.Count; i++)
    //    {
    //        var pegCard = slots[i].gameObject.transform.GetComponentInChildren<SpecialPeg>();
    //        var pegCard2 = GameManager.instance.specPegsList[i];
    //        var pegNum2 = pegCard.pegNumber;
    //        var pegNum = pegCard.pegNumber;
    //        if (pegNum == peg)
    //        {
    //            pegCard.SetLvl();
    //            save.SaveSpecPegCard(pegCard.data, i);
    //        }
    //        if (pegNum2 == peg)
    //            pegCard2.SetLvl();

    //    }
    //}
    //private void InstantiatPegCards(int pegNum, SpecPeg data, bool isStart)
    //{
    //    int num;
    //    if (data == null)
    //        num = pegNum;
    //    else
    //        num = data.pegNumber;

    //    switch (num)
    //    {
    //        case 0:
    //            var nextslot = nextSlot();
    //            int slotNum = nextslot.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard = Instantiate(pegOne, nextslot.transform) as GameObject;
    //            var newPegCardScript = newPegCard.GetComponent<SpecialPeg>();
    //            newPegCardScript.slot = slotNum;
    //            if(data != null)
    //            newPegCardScript.data = data;
    //            var pegCardData = newPegCardScript.data;
    //            newPegCardScript.LoadData();
    //            save.SaveSpecPegCard(pegCardData, slotNum);
    //            if(!isStart)
    //            GameManager.instance.specPegsList.Add(pegOne.GetComponent<SpecialPeg>());
    //            break;
    //        case 1:
    //            var nextslot1 = nextSlot();
    //            var slotNum1 = nextslot1.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard1 = Instantiate(pegTwo, nextslot1.transform) as GameObject;
    //            var newPegCardScript1 = newPegCard1.GetComponent<SpecialPeg>();
    //            newPegCardScript1.slot = slotNum1;
    //            if (data != null)
    //                newPegCardScript1.data = data;
    //            var pegCardData1 = newPegCardScript1.data;
    //            newPegCardScript1.LoadData();
    //            save.SaveSpecPegCard(pegCardData1, slotNum1);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegTwo.GetComponent<SpecialPeg>());
    //            break;
    //        case 2:

    //            var nextslot2 = nextSlot();
    //            var slotNum2 = nextslot2.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard2 = Instantiate(pegThree, nextslot2.transform) as GameObject;
    //            var newPegCardScript2 = newPegCard2.GetComponent<SpecialPeg>();
    //            newPegCardScript2.slot = slotNum2;
    //            if (data != null)
    //                newPegCardScript2.data = data;
    //            var pegCardData2 = newPegCardScript2.data;
    //            newPegCardScript2.LoadData();
    //            save.SaveSpecPegCard(pegCardData2, slotNum2);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegThree.GetComponent<SpecialPeg>());
    //            break;
    //        case 3:

    //            var nextslot3 = nextSlot();
    //            var slotNum3 = nextslot3.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard3 = Instantiate(pegFour, nextslot3.transform) as GameObject;
    //            var newPegCardScript3 = newPegCard3.GetComponent<SpecialPeg>();
    //            newPegCardScript3.slot = slotNum3;
    //            if (data != null)
    //                newPegCardScript3.data = data;
    //            var pegCardData3 = newPegCardScript3.data;
    //            newPegCardScript3.LoadData();
    //            save.SaveSpecPegCard(pegCardData3, slotNum3);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegFour.GetComponent<SpecialPeg>());
    //            break;
    //        case 4:

    //            var nextslot4 = nextSlot();
    //            var slotNum4 = nextslot4.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard4 = Instantiate(pegFive, nextslot4.transform) as GameObject;
    //            var newPegCardScript4 = newPegCard4.GetComponent<SpecialPeg>();
    //            newPegCardScript4.slot = slotNum4;
    //            if (data != null)
    //                newPegCardScript4.data = data;
    //            var pegCardData4 = newPegCardScript4.data;
    //            newPegCardScript4.LoadData();
    //            save.SaveSpecPegCard(pegCardData4, slotNum4);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegFive.GetComponent<SpecialPeg>());
    //            break;
    //        case 5:

    //            var nextslot5 = nextSlot();
    //            var slotNum5 = nextslot5.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard5 = Instantiate(pegSix, nextslot5.transform) as GameObject;
    //            var newPegCardScript5 = newPegCard5.GetComponent<SpecialPeg>();
    //            newPegCardScript5.slot = slotNum5;
    //            if (data != null)
    //                newPegCardScript5.data = data;
    //            var pegCardData5 = newPegCardScript5.data;
    //            newPegCardScript5.LoadData();
    //            save.SaveSpecPegCard(pegCardData5, slotNum5);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegSix.GetComponent<SpecialPeg>());
    //            break;
    //        case 6:

    //            var nextslot6 = nextSlot();
    //            var slotNum6 = nextslot6.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard6 = Instantiate(pegSeven, nextslot6.transform) as GameObject;
    //            var newPegCardScript6 = newPegCard6.GetComponent<SpecialPeg>();
    //            newPegCardScript6.slot = slotNum6;
    //            if (data != null)
    //                newPegCardScript6.data = data;
    //            var pegCardData6 = newPegCardScript6.data;
    //            newPegCardScript6.LoadData();
    //            save.SaveSpecPegCard(pegCardData6, slotNum6);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegSeven.GetComponent<SpecialPeg>());
    //            break;
    //        case 7:

    //            var nextslot7 = nextSlot();
    //            var slotNum7 = nextslot7.GetComponent<CardSlot>().slotNum;
    //            GameObject newPegCard7 = Instantiate(pegEight, nextslot7.transform) as GameObject;
    //            var newPegCardScript7 = newPegCard7.GetComponent<SpecialPeg>();
    //            newPegCardScript7.slot = slotNum7;
    //            if (data != null)
    //                newPegCardScript7.data = data;
    //            var pegCardData7 = newPegCardScript7.data;
    //            newPegCardScript7.LoadData();
    //            save.SaveSpecPegCard(pegCardData7, slotNum7);
    //            if (!isStart)
    //                GameManager.instance.specPegsList.Add(pegEight.GetComponent<SpecialPeg>());

    //            break;
    //    }
    //}
}
