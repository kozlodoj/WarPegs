using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoryUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI goldText;
    [SerializeField]
    private TextMeshProUGUI diamondText;
    private GameObject baseMenu;
    private GameObject store;

    // Start is called before the first frame update
    void Start()
    {
        
        baseMenu = GameObject.Find("Base Menu");
        store = transform.Find("Store").gameObject;
        SetGoldText(GameManager.instance.gold);
        SetDiamondText(GameManager.instance.diamonds);
        ManageEra();
    }

    public void SetGoldText(int amount)
    {
        goldText.SetText(amount.ToString());
    }
    public void SetDiamondText(int amount)
    {
        diamondText.SetText(amount.ToString());
    }
    public void Play()
    {
        GameManager.instance.LevelSelect(6);
    }

    public void BackToMenu()
    {
        GameManager.instance.BackToMenu();
    }
    public void ActivateStore()
    {
        baseMenu.SetActive(false);
        store.SetActive(true);
    }
    public void ActivateBaseMenu()
    {
        store.SetActive(false);
        baseMenu.SetActive(true);
    }

    public void NextEra()
    {
        baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
        baseMenu.transform.Find("Era 2").gameObject.SetActive(true);
        SetGoldText(GameManager.instance.gold);

    }
    private void ManageEra()
    {
        if (GameManager.instance.playerEra == 0)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(true);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(false);
        }
        else if (GameManager.instance.playerEra == 1)
        {
            baseMenu.transform.Find("Era 1").gameObject.SetActive(false);
            baseMenu.transform.Find("Era 2").gameObject.SetActive(true);
        }
    }

}
