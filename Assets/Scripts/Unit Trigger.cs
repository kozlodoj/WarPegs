using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitTrigger : MonoBehaviour
{
    [SerializeField]
    private GameObject wall01;
    [SerializeField]
    private GameObject wall02;
    private GameObject firstSpawner;
    private BoxCollider2D firstCollider;
    private GameObject secondSpawner;
    private BoxCollider2D secondCollider;
    private GameObject thirdSpawner;
    private BoxCollider2D thirdCollider;

    [SerializeField]
    private GameObject era1FirstSpawner;
    [SerializeField]
    private GameObject era1SecondSpawner;
    [SerializeField]
    private GameObject era1ThirdSpawner;
    [SerializeField]
    private GameObject era2FirstSpawner;
    [SerializeField]
    private GameObject era2SecondSpawner;
    [SerializeField]
    private GameObject era2ThirdSpawner;
    [SerializeField]
    private GameObject era3FirstSpawner;
    [SerializeField]
    private GameObject era3SecondSpawner;
    [SerializeField]
    private GameObject era3ThirdSpawner;
    [SerializeField]
    private GameObject era4FirstSpawner;
    [SerializeField]
    private GameObject era4SecondSpawner;
    [SerializeField]
    private GameObject era4ThirdSpawner;
    [SerializeField]
    private GameObject era5FirstSpawner;
    [SerializeField]
    private GameObject era5SecondSpawner;
    [SerializeField]
    private GameObject era5ThirdSpawner;
    [SerializeField]
    private GameObject era6FirstSpawner;
    [SerializeField]
    private GameObject era6SecondSpawner;
    [SerializeField]
    private GameObject era6ThirdSpawner;

    public bool isEvent;

    // Start is called before the first frame update
    void Awake()
    {
        ManageEra();
        firstCollider = firstSpawner.GetComponent<BoxCollider2D>();
        secondCollider = secondSpawner.GetComponent<BoxCollider2D>();
        thirdCollider = thirdSpawner.GetComponent<BoxCollider2D>();
            ManageSpawners();
    }

    private void ManageSpawners()
    {
        if (!isEvent)
        {
            if (!GameManager.instance.isUnitTwoActive && !GameManager.instance.isUnitThreeActive)
            {
                wall01.SetActive(false);
                wall02.SetActive(false);
                secondSpawner.SetActive(false);
                thirdSpawner.SetActive(false);
                firstSpawner.transform.localPosition = new Vector2(0, -4f);
                firstCollider.offset = new Vector2(0, 0);
                firstCollider.size = new Vector2(12, 1);
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
                wall01.transform.localPosition = new Vector2(0, -3.5f);
                firstSpawner.transform.localPosition = new Vector2(-2.8f, -4f);
                secondSpawner.transform.localPosition = new Vector2(2.8f, -4f);
                firstCollider.offset = new Vector2(0, 0);
                firstCollider.size = new Vector2(5.2f, 1);
                secondCollider.offset = new Vector2(0, 0);
                secondCollider.size = new Vector2(5.2f, 1);
            }
            else if (!GameManager.instance.isUnitTwoActive && GameManager.instance.isUnitThreeActive)
            {
                wall01.SetActive(true);
                wall02.SetActive(false);
                secondSpawner.SetActive(false);
                thirdSpawner.SetActive(true);
                wall01.transform.localPosition = new Vector2(2, -3.5f);
                firstSpawner.transform.localPosition = new Vector2(-1.8f, -4f);
                thirdSpawner.transform.localPosition = new Vector2(3.9f, -4f);
                firstCollider.offset = new Vector2(0, 0);
                firstCollider.size = new Vector2(7, 1);
                thirdCollider.offset = new Vector2(0, 0);
                thirdCollider.size = new Vector2(3f, 1);
            }
        }
        else
        {
            if (!EventManager.instance.isUnitTwoActive && !EventManager.instance.isUnitThreeActive)
            {
                wall01.SetActive(false);
                wall02.SetActive(false);
                secondSpawner.SetActive(false);
                thirdSpawner.SetActive(false);
                firstSpawner.transform.localPosition = new Vector2(0, -4f);
                firstCollider.offset = new Vector2(0, 0);
                firstCollider.size = new Vector2(12, 1);
            }
            else if (EventManager.instance.isUnitTwoActive && EventManager.instance.isUnitThreeActive)
            {
                wall01.SetActive(true);
                wall02.SetActive(true);
                secondSpawner.SetActive(true);
                thirdSpawner.SetActive(true);
            }
            else if (EventManager.instance.isUnitTwoActive && !EventManager.instance.isUnitThreeActive)
            {
                wall01.SetActive(true);
                wall02.SetActive(false);
                secondSpawner.SetActive(true);
                thirdSpawner.SetActive(false);
                wall01.transform.localPosition = new Vector2(0, -3.5f);
                firstSpawner.transform.localPosition = new Vector2(-2.8f, -4f);
                secondSpawner.transform.localPosition = new Vector2(2.8f, -4f);
                firstCollider.offset = new Vector2(0, 0);
                firstCollider.size = new Vector2(5.2f, 1);
                secondCollider.offset = new Vector2(0, 0);
                secondCollider.size = new Vector2(5.2f, 1);
            }
            else if (!EventManager.instance.isUnitTwoActive && EventManager.instance.isUnitThreeActive)
            {
                wall01.SetActive(true);
                wall02.SetActive(false);
                secondSpawner.SetActive(false);
                thirdSpawner.SetActive(true);
                wall01.transform.localPosition = new Vector2(2, -3.5f);
                firstSpawner.transform.localPosition = new Vector2(-1.8f, -4f);
                thirdSpawner.transform.localPosition = new Vector2(3.9f, -4f);
                firstCollider.offset = new Vector2(0, 0);
                firstCollider.size = new Vector2(7, 1);
                thirdCollider.offset = new Vector2(0, 0);
                thirdCollider.size = new Vector2(3f, 1);
            }
        }

    }

    private void ManageEra()
    {
        if (!isEvent)
        {
            if (GameManager.instance.playerEra == 0)
            {
                firstSpawner = Instantiate(era1FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era1SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era1ThirdSpawner, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 1)
            {
                firstSpawner = Instantiate(era2FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era2SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era2ThirdSpawner, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 2)
            {
                firstSpawner = Instantiate(era3FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era3SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era3ThirdSpawner, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 3)
            {
                firstSpawner = Instantiate(era4FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era4SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era4ThirdSpawner, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 4)
            {
                firstSpawner = Instantiate(era5FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era5SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era5ThirdSpawner, gameObject.transform);
            }
            else if (GameManager.instance.playerEra == 5)
            {
                firstSpawner = Instantiate(era6FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era6SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era6ThirdSpawner, gameObject.transform);
            }
        }
        else
        {
            if (EventManager.instance.playerEra == 0)
            {
                firstSpawner = Instantiate(era1FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era1SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era1ThirdSpawner, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 1)
            {
                firstSpawner = Instantiate(era2FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era2SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era2ThirdSpawner, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 2)
            {
                firstSpawner = Instantiate(era3FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era3SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era3ThirdSpawner, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 3)
            {
                firstSpawner = Instantiate(era4FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era4SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era4ThirdSpawner, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 4)
            {
                firstSpawner = Instantiate(era5FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era5SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era5ThirdSpawner, gameObject.transform);
            }
            else if (EventManager.instance.playerEra == 5)
            {
                firstSpawner = Instantiate(era6FirstSpawner, gameObject.transform);
                secondSpawner = Instantiate(era6SecondSpawner, gameObject.transform);
                thirdSpawner = Instantiate(era6ThirdSpawner, gameObject.transform);
            }
        }
    }
}
