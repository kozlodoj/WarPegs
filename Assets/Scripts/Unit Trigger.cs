using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject wall01;
    [SerializeField]
    private GameObject wall02;
    [SerializeField]
    private GameObject firstSpawner;
    private BoxCollider2D firstCollider;
    [SerializeField]
    private GameObject secondSpawner;
    private BoxCollider2D secondCollider;
    [SerializeField]
    private GameObject thirdSpawner;
    private BoxCollider2D thirdCollider;


    // Start is called before the first frame update
    void Start()
    {
        firstCollider = firstSpawner.GetComponent<BoxCollider2D>();
        secondCollider = secondSpawner.GetComponent<BoxCollider2D>();
        thirdCollider = thirdSpawner.GetComponent<BoxCollider2D>();
        if (GameManager.instance.storyMode)
            ManageSpawners();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ManageSpawners()
    {
        if (!GameManager.instance.isUnitTwoActive && !GameManager.instance.isUnitThreeActive)
        {
            wall01.SetActive(false);
            wall02.SetActive(false);
            secondSpawner.SetActive(false);
            thirdSpawner.SetActive(false);
            firstSpawner.transform.localPosition = new Vector2(0, -4.4f);
            firstCollider.offset = new Vector2(0, 0);
            firstCollider.size = new Vector2(9, 1);
        }
        else if (GameManager.instance.isUnitTwoActive && GameManager.instance.isUnitThreeActive)
        {
            wall01.SetActive(true);
            wall02.SetActive(true);
            secondSpawner.SetActive(true);
            thirdSpawner.SetActive(true);
        }
        else if (GameManager.instance.isUnitTwoActive && !GameManager.instance.isUnitThreeActive)
        {
            wall01.SetActive(true);
            wall02.SetActive(false);
            secondSpawner.SetActive(true);
            thirdSpawner.SetActive(false);
            wall01.transform.localPosition = new Vector2(2, -5.5f);
            firstSpawner.transform.localPosition = new Vector2(-1.5f, -4.4f);
            secondSpawner.transform.localPosition = new Vector2(3.6f, -4.4f);
            firstCollider.offset = new Vector2(0, 0);
            firstCollider.size = new Vector2(6, 1);
            secondCollider.offset = new Vector2(0, 0);
            secondCollider.size = new Vector2(2.2f, 1);
        }
        else if (!GameManager.instance.isUnitTwoActive && GameManager.instance.isUnitThreeActive)
        {
            wall01.SetActive(true);
            wall02.SetActive(false);
            secondSpawner.SetActive(false);
            thirdSpawner.SetActive(true);
            wall01.transform.localPosition = new Vector2(2, -5.5f);
            firstSpawner.transform.localPosition = new Vector2(-1.5f, -4.4f);
            thirdSpawner.transform.localPosition = new Vector2(3.6f, -4.4f);
            firstCollider.offset = new Vector2(0, 0);
            firstCollider.size = new Vector2(6, 1);
            thirdCollider.offset = new Vector2(0, 0);
            thirdCollider.size = new Vector2(2.2f, 1);
        }

    }
}
