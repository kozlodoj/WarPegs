using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> oneUnits = new List<GameObject>();
    [SerializeField]
    private List<GameObject> twoUnits = new List<GameObject>();
    [SerializeField]
    private List<GameObject> threeUnits = new List<GameObject>();
    [SerializeField]
    private GameObject tutorialLayout;
    private PegManager tutPegs;
    private GameObject tut;

    public bool isEvent;
    // Start is called before the first frame update
    void Awake()
    {
        RandomLayout();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void RandomLayout()
    {
        if (!isEvent)
        {
            if (GameManager.instance.tutorial)
            {
                tut = Instantiate(tutorialLayout, gameObject.transform) as GameObject;
                tutPegs = tut.GetComponent<PegManager>();
            }

            else
            {
                if (!GameManager.instance.isUnitTwoActive && !GameManager.instance.isUnitThreeActive)
                    Instantiate(oneUnits[Random.Range(0, oneUnits.Count)], gameObject.transform);
                if (GameManager.instance.isUnitTwoActive && !GameManager.instance.isUnitThreeActive)
                    Instantiate(twoUnits[Random.Range(0, twoUnits.Count)], gameObject.transform);
                if (!GameManager.instance.isUnitTwoActive && GameManager.instance.isUnitThreeActive)
                    Instantiate(twoUnits[Random.Range(0, twoUnits.Count)], gameObject.transform);
                if (GameManager.instance.isUnitTwoActive && GameManager.instance.isUnitThreeActive)
                    Instantiate(threeUnits[Random.Range(0, threeUnits.Count)], gameObject.transform);
            }
        }
        else
        {
            if (!EventManager.instance.isUnitTwoActive && !EventManager.instance.isUnitThreeActive)
                Instantiate(oneUnits[Random.Range(0, oneUnits.Count)], gameObject.transform);
            if (EventManager.instance.isUnitTwoActive && !EventManager.instance.isUnitThreeActive)
                Instantiate(twoUnits[Random.Range(0, twoUnits.Count)], gameObject.transform);
            if (!EventManager.instance.isUnitTwoActive && EventManager.instance.isUnitThreeActive)
                Instantiate(twoUnits[Random.Range(0, twoUnits.Count)], gameObject.transform);
            if (EventManager.instance.isUnitTwoActive && EventManager.instance.isUnitThreeActive)
                Instantiate(threeUnits[Random.Range(0, threeUnits.Count)], gameObject.transform);
        }
    }

    public void UpdateLaout()
    {
        tutPegs.ActivateMedic();
    }
    
}
