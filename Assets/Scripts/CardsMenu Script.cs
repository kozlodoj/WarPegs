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
    

    [SerializeField]
    private int initialDropChance;
    [SerializeField]
    private int lvlUpDropChance;

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
        PegCardsFromGM();
        
        
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
                        GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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
                            GameManager.instance.PegCardsList[i].chance += lvlUpDropChance;
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

        save.SaveSpecPegCard(GameManager.instance.PegCardsList);

    }
    private void PegCardsFromGM()
    {
        if (GameManager.instance.PegCardsList.Count > 0)
        {
            for (int i = 0; i < GameManager.instance.PegCardsList.Count; i++)
            {
                var cardNum = GameManager.instance.PegCardsList[i].pegNumber;
                var pegCard = GameManager.instance.PegCardsList[i];
                slots[i].GetComponent<CardSlot>().ActivateCard(cards[cardNum], pegCard);
            }
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
    
}
