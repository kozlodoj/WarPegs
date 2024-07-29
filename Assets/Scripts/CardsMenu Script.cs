using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsMenuScript : MonoBehaviour
{
    List<int> pegCards = new List<int>();
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
    }

    public void GachaOneRoll()
    {
        pegCards.Clear();
        int roll = RandomNum();
        Debug.Log(roll);

        if (roll < oneBorder)
        {
            pegCards.Add(1);
            Debug.Log("One");
        }
        else if (roll > oneBorder && roll < twoBorder)
        {
            pegCards.Add(2);
            Debug.Log("Two");
        }
        else if (roll > twoBorder && roll < threeBorder)
        {
            pegCards.Add(3);
            Debug.Log("Three");
        }
        else if (roll > threeBorder && roll < fourBorder)
        {
            pegCards.Add(4);
            Debug.Log("Four");
        }
        else if (roll > fourBorder && roll < fiveBorder)
        {
            pegCards.Add(5);
            Debug.Log("Five");
        }
        else if (roll > fiveBorder && roll < sixBorder)
        {
            pegCards.Add(6);
            Debug.Log("Six");
        }
        else if (roll > sixBorder && roll < sevenBorder)
        {
            pegCards.Add(7);
            Debug.Log("Seven");
        }
        else if (roll > sevenBorder)
        {
            pegCards.Add(18);
            Debug.Log("Eight");
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
        for (int i = 0; i < pegCards.Count; i++)
        {
            int pegNum = pegCards[i];
            switch (pegNum)
            {
                case 1:
                    pegOne.SetActive(true);
                    break;
                case 2:
                    pegTwo.SetActive(true);
                    break;
                case 3:
                    pegThree.SetActive(true);
                    break;
                case 4:
                    pegFour.SetActive(true);
                    break;
                case 5:
                    pegFive.SetActive(true);
                    break;
                case 6:
                    pegSix.SetActive(true);
                    break;
                case 7:
                    pegSeven.SetActive(true);
                    break;
                case 8:
                    pegEight.SetActive(true);
                    break;
            }

        }

    }
}
